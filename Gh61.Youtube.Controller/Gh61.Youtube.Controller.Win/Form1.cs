using System.Net;
using System.Windows.Forms;
using Gh61.Youtube.Controller.Win.Core;
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

		private void Form1_Load(object sender, System.EventArgs e)
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

		private void OnStatusGet(string status, string title)
		{
			this.InvokeIfNeeded(() =>
			{
				this.lblStatus.Text = status;
				this.lblTitle.Text = title;
			});
		}

		private async void btnPlayPause_Click(object sender, System.EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.PlayPause);
		}

		private async void btnRefresh_Click(object sender, System.EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.GetStatus);
		}

		private async void btnPrev_Click(object sender, System.EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.GoPrevious);
		}

		private async void btnNext_Click(object sender, System.EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.GoNext);
		}
	}
}
