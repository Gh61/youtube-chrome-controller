using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Gh61.Youtube.Controller.Win.Core
{
	internal class PlayerController : WebSocketBehavior
	{
		private static readonly IList<PlayerController> chatClients = new List<PlayerController>();
		private readonly Action<PlayerStatus, string> onStatusGet;

		public PlayerController(Action<PlayerStatus, string> onStatusGet)
		{
			this.onStatusGet = onStatusGet;
		}

		/// <summary>
		/// Sends command (<see cref="PlayerCommands"/>) to (all) connected player(s).
		/// </summary>
		public static async Task Broadcast(string command)
		{
			IList<PlayerController> clients;
			lock (chatClients)
			{
				clients = chatClients.ToList(); // copy whole list
			}

			foreach (var client in clients)
			{
				await client.Send(command);
			}
		}

		#region Connecting

		/// <summary>
		/// Called when the WebSocket connection used in the current session has been established.
		/// </summary>
		protected override async Task OnOpen()
		{
			lock (chatClients)
			{
				chatClients.Add(this);
			}
			Debug.WriteLine($"[WS] Client {this.Id} connected.");

			await this.Send(PlayerCommands.GetStatus);
		}

		/// <summary>
		/// Called when the <see cref="T:WebSocketSharp.WebSocket" /> used in the current session gets an error.
		/// </summary>
		/// <param name="e">
		/// A <see cref="T:WebSocketSharp.ErrorEventArgs" /> that represents the event data passed to
		/// a <see cref="!:WebSocket.OnError" /> event.
		/// </param>
		protected override Task OnError(ErrorEventArgs e)
		{
			Debug.WriteLine("[WS] Client {0} ERROR: {1}", this.Id, e.Message);

			return base.OnError(e);
		}

		/// <summary>
		/// Called when the WebSocket connection used in the current session has been closed.
		/// </summary>
		/// <param name="e">
		/// A <see cref="T:WebSocketSharp.CloseEventArgs" /> that represents the event data passed to
		/// a <see cref="!:WebSocket.OnClose" /> event.
		/// </param>
		protected override Task OnClose(CloseEventArgs e)
		{
			lock (chatClients)
			{
				chatClients.Remove(this);
			}

			Debug.WriteLine($"[WS] Client {this.Id} disconnected.");

			return base.OnClose(e);
		}

		#endregion

		/// <summary>
		/// Called when the <see cref="T:WebSocketSharp.WebSocket" /> used in the current session receives a message.
		/// </summary>
		/// <param name="e">
		/// A <see cref="T:WebSocketSharp.MessageEventArgs" /> that represents the event data passed to
		/// a <see cref="!:WebSocket.OnMessage" /> event.
		/// </param>
		protected override async Task OnMessage(MessageEventArgs e)
		{
			var text = await e.Text.ReadToEndAsync() ?? string.Empty;

			Debug.WriteLine($"[WS] Message from {this.Id}: {text}");

			var splited = text.Split(':');
			var function = splited[0];
			var data = splited.Length > 1 ? splited[1] : string.Empty;

			switch (function)
			{
				// Player is reporting current status
				case Messages.Status:
					var states = data.Split(';'); // data for example: "Playing;Artist - Title"
					PlayerStatus status;
					if (!Enum.TryParse(states[0].Replace(" ", ""), true, out status))
					{
						status = PlayerStatus.Unstarted;
					}
					onStatusGet(status, states[1]);
					break;
			}
		}

		/// <summary>
		/// Messages that commes from chrome extension.
		/// </summary>
		private static class Messages
		{
			/// <summary>
			/// Message with actual player status.
			/// </summary>
			public const string Status = "STATUS";
		}
	}
}
