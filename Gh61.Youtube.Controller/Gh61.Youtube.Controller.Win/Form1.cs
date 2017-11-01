using System;
using System.Net;
using System.Windows.Forms;
using Gh61.Youtube.Controller.Win.Core;
using Gh61.Youtube.Controller.Win.Properties;
using WebSocketSharp.Server;

namespace Gh61.Youtube.Controller.Win
{
	public partial class Form1 : Form
	{
		private WebSocketServer server;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			server = new WebSocketServer(IPAddress.Loopback, 13337);
			server.AddWebSocketService("/controller", () => new PlayerController(OnStatusGet));
			server.Start();
		}

		private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (server != null)
			{
				await server.Stop();
			}
		}

		private void OnStatusGet(PlayerStatus status, string title)
		{
			this.InvokeIfNeeded(() =>
			{
				switch (status)
				{
					case PlayerStatus.Buffering:
					case PlayerStatus.Playing:
						this.lblStatus.Text = Resources.Status_Playing;
						this.trayIcon.Icon = Resources.play;
						break;
					case PlayerStatus.Paused:
						this.lblStatus.Text = Resources.Status_Paused;
						this.trayIcon.Icon = Resources.pause;
						break;
					default:
						this.lblStatus.Text = Resources.Status_Idle;
						this.trayIcon.Icon = Resources.note;
						break;
				}

				this.lblTitle.Text = title;
			});
		}

		private async void btnPlayPause_Click(object sender, EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.PlayPause);
		}

		private async void btnRefresh_Click(object sender, EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.GetStatus);
		}

		private async void btnPrev_Click(object sender, EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.GoPrevious);
		}

		private async void btnNext_Click(object sender, EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.GoNext);
		}

		private async void trayIcon_Click(object sender, EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.PlayPause);
		}

		private async void trayIcon_DoubleClick(object sender, EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.GoNext);
		}
	}
}
