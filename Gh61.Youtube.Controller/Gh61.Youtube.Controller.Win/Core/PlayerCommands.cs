namespace Gh61.Youtube.Controller.Win.Core
{
	/// <summary>
	/// Commands that can be used to control chrome extension => player.
	/// </summary>
	public static class PlayerCommands
	{
		/// <summary>
		/// Command to request current status of Player.
		/// </summary>
		public const string GetStatus = "GetStatus";

		/// <summary>
		/// Command to toggle playing or pased state of Player.
		/// </summary>
		public const string PlayPause = "PlayPause";

		/// <summary>
		/// Command to go to next video in Player.
		/// </summary>
		public const string GoNext = "GoNext";

		/// <summary>
		/// Command to go to previous video in Player.
		/// </summary>
		public const string GoPrevious = "GoPrev";
	}
}
