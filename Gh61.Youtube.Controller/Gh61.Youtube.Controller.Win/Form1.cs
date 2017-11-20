using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Gh61.Youtube.Controller.Win.Core;
using Gh61.Youtube.Controller.Win.Properties;
using WebSocketSharp.Server;

namespace Gh61.Youtube.Controller.Win
{
	public partial class Form1 : Form
	{
		private bool shown;
		private bool positionSet;
		private bool doubleClickOccured;
		private WebSocketServer server;
		private KeyboardHook kbHook;

		public Form1()
		{
			InitializeComponent();

			// Hide app to tray after start
			HideToTray();
		}

		#region Websocket server & Keyboard hook

		private void Form1_Load(object sender, EventArgs e)
		{
			server = new WebSocketServer(IPAddress.Loopback, 13337);
			server.AddWebSocketService("/controller", () => new PlayerController(OnStatusGet));
			server.Start();

			kbHook = new KeyboardHook();
			kbHook.KeyUp += KbHook_KeyUp;
		}

		private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (server != null)
			{
				await server.Stop();
			}
			kbHook?.Dispose();
		}

		#endregion

		private void OnStatusGet(PlayerStatus status, string title)
		{
			this.InvokeIfNeeded(() =>
			{
				string statusText;

				switch (status)
				{
					case PlayerStatus.Buffering:
					case PlayerStatus.Playing:
						statusText = Resources.Status_Playing;
						this.trayIcon.Icon = Resources.play;
						this.menuItemPlayPause.Image = Resources.pause_19;
						break;
					case PlayerStatus.Paused:
						statusText = Resources.Status_Paused;
						this.trayIcon.Icon = Resources.pause;
						this.menuItemPlayPause.Image = Resources.play_19;
						break;
					default:
						statusText = Resources.Status_Idle;
						this.trayIcon.Icon = Resources.note;
						this.menuItemPlayPause.Image = Resources.play_19;
						break;
				}

				this.lblStatus.SetText(statusText);
				this.menuItemStatus.SetText(statusText);
				this.lblTitle.SetText(title);
				this.menuItemTitle.SetText(title);

				var showTitleAndStatus = statusText != Resources.Status_Idle;
				this.menuItemTitle.Visible = showTitleAndStatus;
				this.menuItemStatus.Visible = showTitleAndStatus;
				this.menuSeparator2.Visible = showTitleAndStatus;

				var trayText = showTitleAndStatus ? $"{statusText}: {title}" : this.Text;
				this.trayIcon.SetText(trayText);
			});
		}

		#region Hide/Show tray

		private void HideToTray()
		{
			shown = false;
			if (this.WindowState != FormWindowState.Minimized) this.WindowState = FormWindowState.Minimized;
			this.ShowInTaskbar = false;
			this.Hide();
		}

		private void ShowFromTray()
		{
			if (this.WindowState != FormWindowState.Normal) this.WindowState = FormWindowState.Normal;
			this.ShowInTaskbar = true;
			if (!positionSet)
			{
				positionSet = true;
				// Set position to Bottom-Right (to tray area)
				var workingArea = Screen.GetWorkingArea(this);
				this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
			}
			else
			{
				this.Show();
			}

			shown = true;
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			if (shown && WindowState == FormWindowState.Minimized)
			{
				HideToTray();
			}
		}

		private void menuItemShow_Click(object sender, EventArgs e)
		{
			ShowFromTray();
		}

		private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (shown) return;

			doubleClickOccured = true;
			ShowFromTray();
		}

		#endregion

		private void trayIcon_MouseClick(object sender, MouseEventArgs e)
		{
			// only react to left button (right is for menu)
			if (e.Button != MouseButtons.Left) return;

			// If is window shown - there's no need to wait
			if (shown)
			{
				PlayPause(sender, e);
				return;
			}

			// I'll wait if the double click not occured
			this.Timeout(SystemInformation.DoubleClickTime, () =>
			{
				if (!doubleClickOccured)
				{
					PlayPause(sender, e);
				}
				doubleClickOccured = false;
			});
		}

		private void KbHook_KeyUp(Keys key, bool shift, bool ctrl, bool alt)
		{
			// global hook for media keys
			switch (key)
			{
				case Keys.MediaPlayPause:
					PlayPause(kbHook, null);
					break;
				case Keys.MediaNextTrack:
					PlayNext(kbHook, null);
					break;
				case Keys.MediaPreviousTrack:
					PlayPrevious(kbHook, null);
					break;
				case Keys.MediaStop:
					Pause(kbHook, null);
					break;
			}
		}

		#region Player Controll events

		private async void PlayPrevious(object sender, EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.GoPrevious);
		}

		private async void PlayPause(object sender, EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.PlayPause);
		}

		private async void Pause(object sender, EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.Pause);
		}

		private async void PlayNext(object sender, EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.GoNext);
		}

		private async void RefreshStatus(object sender, EventArgs e)
		{
			await PlayerController.Broadcast(PlayerCommands.GetStatus);
		}

		#endregion

		private void menuItemExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
