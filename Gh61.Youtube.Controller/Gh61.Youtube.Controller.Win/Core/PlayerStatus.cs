namespace Gh61.Youtube.Controller.Win.Core
{
	/*
	var states = {
		0: "Ended",
		1: "Playing",
		2: "Paused",
		3: "Buffering",
		5: "Video cued"
	};
	states[-1] = "Unstarted";
	*/

	/// <summary>
	/// Possible states of player.
	/// </summary>
	public enum PlayerStatus
	{
		Unstarted = -1,
		Ended = 0,
		Playing = 1,
		Paused = 2,
		Buffering = 3,
		VideoCued = 5,
	}
}
