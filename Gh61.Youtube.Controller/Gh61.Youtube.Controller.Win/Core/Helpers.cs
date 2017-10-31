using System;
using System.Windows.Forms;

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
	}
}
