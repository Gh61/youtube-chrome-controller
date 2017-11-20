using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gh61.Youtube.Controller.Win.Core
{
	internal class KeyboardHook : IDisposable
	{
		// credits: https://stackoverflow.com/a/34290332/1341409 (edited solution)

		public delegate void LocalKeyEventHandler(Keys key, bool shift, bool ctrl, bool alt);
		public event LocalKeyEventHandler KeyDown;
		public event LocalKeyEventHandler KeyUp;

		#region WIN_API

		private enum KeyEvents
		{
			KeyDown = 0x0100,
			KeyUp = 0x0101,
			SKeyDown = 0x0104,
			SKeyUp = 0x0105
		}

		private delegate int CallbackDelegate(int code, int w, int l);

		[DllImport("user32", CallingConvention = CallingConvention.StdCall)]
		private static extern int SetWindowsHookEx(int idHook, CallbackDelegate lpfn, int hInstance, int threadId);

		[DllImport("user32", CallingConvention = CallingConvention.StdCall)]
		private static extern bool UnhookWindowsHookEx(int idHook);

		[DllImport("user32", CallingConvention = CallingConvention.StdCall)]
		private static extern int CallNextHookEx(int idHook, int nCode, int wParam, int lParam);

		[DllImport("user32.dll")]
		private static extern short GetKeyState(Keys nVirtKey);

		#endregion

		// ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
		private readonly CallbackDelegate theHookCb; // must be here to prevent GC from collecting
		private readonly int hookId;

		public KeyboardHook()
		{
			theHookCb = KeybHookProc;
			hookId = SetWindowsHookEx(
				13, // WH_KEYBOARD_LL
				theHookCb,
				0, // 0 for local hook. eller hwnd til user32 for global
				0); // 0 for global hook. eller thread for hooken

		}

		private int KeybHookProc(int code, int w, int l)
		{
			if (code < 0)
			{
				return CallNextHookEx(hookId, code, w, l);
			}
			try
			{
				var kEvent = (KeyEvents)w;
				var vkCode = Marshal.ReadInt32((IntPtr)l);

				switch (kEvent)
				{
					case KeyEvents.KeyDown:
					case KeyEvents.SKeyDown:
						KeyDown?.Invoke((Keys)vkCode, GetShiftPressed(), GetCtrlPressed(), GetAltPressed());
						break;
					case KeyEvents.KeyUp:
					case KeyEvents.SKeyUp:
						KeyUp?.Invoke((Keys)vkCode, GetShiftPressed(), GetCtrlPressed(), GetAltPressed());
						break;
				}
			}
			catch (Exception)
			{
				//Ignore all errors...
			}

			return CallNextHookEx(hookId, code, w, l);

		}

		public static bool GetCapslock()
		{
			return Convert.ToBoolean(GetKeyState(Keys.CapsLock)) & true;
		}

		public static bool GetNumlock()
		{
			return Convert.ToBoolean(GetKeyState(Keys.NumLock)) & true;
		}

		public static bool GetScrollLock()
		{
			return Convert.ToBoolean(GetKeyState(Keys.Scroll)) & true;
		}

		public static bool GetShiftPressed()
		{
			int state = GetKeyState(Keys.ShiftKey);
			if (state > 1 || state < -1) return true;
			return false;
		}

		public static bool GetCtrlPressed()
		{
			int state = GetKeyState(Keys.ControlKey);
			if (state > 1 || state < -1) return true;
			return false;
		}

		public static bool GetAltPressed()
		{
			int state = GetKeyState(Keys.Menu);
			if (state > 1 || state < -1) return true;
			return false;
		}

		#region IDisposable pattern

		private bool isFinalized;
		~KeyboardHook()
		{
			if (!isFinalized)
			{
				UnhookWindowsHookEx(hookId);
				isFinalized = true;
			}
		}
		public void Dispose()
		{
			if (!isFinalized)
			{
				UnhookWindowsHookEx(hookId);
				isFinalized = true;
			}
		}

		#endregion
	}
}
