using System;
using System.Windows.Forms;
using Tim = System.Timers.Timer;

namespace Gh61.Youtube.Controller.Win.Core
{
	internal static class Helpers
	{
		/// <summary>
		/// Executes action (and call Invoke on this control if needed).
		/// </summary>
		public static void InvokeIfNeeded(this Control control, Action action)
		{
			if (control.InvokeRequired)
			{
				control.Invoke(action);
				return;
			}

			action();
		}

		/// <summary>
		/// Waits for given time in milliseconds, then firing given action (with Invoke).
		/// </summary>
		public static void Timeout(this Control control, int milliseconds, Action action)
		{
			Tim t = new Tim();
			t.Interval = milliseconds; //In milliseconds here
			t.AutoReset = false; //Stops it from repeating
			t.Elapsed += (sender, args) =>
			{
				control.InvokeIfNeeded(action);
			};
			t.Start();
		}
	}
}
