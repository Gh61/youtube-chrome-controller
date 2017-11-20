///<reference path="../scripts/_references.js" />

(function (window, document) {
	var commands =
	{
		Play: "play",
		Pause: "pause",
		TogglePlay: "playpause",
		Next: "next",
		Previous: "prev",
		Status: "stat"
	};

	var states = {
		Unstarted: -1,
		Ended: 0,
		Playing: 1,
		Paused: 2,
		Buffering: 3,
		VideoCued: 5,
		// ----------------
		0: "Ended",
		1: "Playing",
		2: "Paused",
		3: "Buffering",
		5: "Video cued"
	};
	states[-1] = "Unstarted";

	var self = this;
	self.log = function(text) {
		console.log("[YoutubeController] " + text);
	}

	self.executePageScript = function(fc) {
		var actualCode = "(" + fc + ")();";
		var script = document.createElement("script");
		script.textContent = actualCode;
		(document.head || document.documentElement).appendChild(script);
		script.remove();
	}

	self.executePageScriptAndReturn = function (fc) {
		// insert hidden input for result
		var resultInput = document.createElement("input");
		resultInput.type = "hidden";
		resultInput.id = "content-script-result";
		document.body.appendChild(resultInput);
		
		// execute script and set result to hidden element
		var actualCode = "document.getElementById('content-script-result').value = (" + fc + ")();";
		var script = document.createElement("script");
		script.textContent = actualCode;
		(document.head || document.documentElement).appendChild(script);
		script.remove();

		// get set value
		var result = resultInput.value;
		resultInput.remove();
		return result;
	}

	self.player = {
		// We need to pass through Youtube API functions
		playVideo: function() {
			self.executePageScript(function() {
				document.getElementById("movie_player").playVideo();
			});
		},
		pauseVideo: function() {
			self.executePageScript(function () {
				document.getElementById("movie_player").pauseVideo();
			});
		},
		nextVideo: function() {
			self.executePageScript(function () {
				document.getElementById("movie_player").nextVideo();
			});
		},
		previousVideo: function() {
			self.executePageScript(function () {
				document.getElementById("movie_player").previousVideo();
			});
		},
		getPlayerState: function () {
			/*
			 * -1 - unstarted
			 * 0 - ended
			 * 1 - playing
			 * 2 - paused
			 * 3 - buffering
			 * 5 - video cued
			 */

			return parseInt(self.executePageScriptAndReturn(function() {
				return document.getElementById("movie_player").getPlayerState();
			}));
		}
	};

	self.createTabMessage = function(status) {
		return {
			tabStatus: status
		}
	};
	self.notifyPlayerState = function () {
		var status = states[self.player.getPlayerState()];
		var title = "";
		var titleElem = document.getElementById("watch-headline-title");
		if (titleElem != null) {
			title = titleElem.children[0].children[0].textContent.trim();
		} else {
			titleElem = document.querySelector("h1.title");
			if (titleElem != null) {
				title = titleElem.textContent.trim();
			}
		}

		var message = {
			status: status,
			title: title
		}

		chrome.runtime.sendMessage(message);
	};

	// Listening to commands from background.js
	chrome.extension.onMessage.addListener(
		function (request, sender, sendResponse) {
			var notifyStatusTimeout = 500;

			switch(request.command) {
				case commands.Play:
					self.player.playVideo();
					break;
				case commands.Pause:
					self.player.pauseVideo();
					break;
				case commands.TogglePlay:
					var state = self.player.getPlayerState();
					self.log("PlayerState: " + state);
					if (state === states.Playing) { // playing => pause
						self.player.pauseVideo();
					} else if(state === states.Ended || state === states.Paused) { // paused or ended => play
						self.player.playVideo();
					}
					break;
				case commands.Next:
					self.player.nextVideo();
					notifyStatusTimeout = 1500;
					break;
				case commands.Previous:
					self.player.previousVideo();
					notifyStatusTimeout = 1500;
					break;

				case commands.Status:
					// only request for player status
					notifyStatusTimeout = 0;
					break;
				default:
					self.log("Unknown command '" + request.command + "'.");
					break;
			}

			// After every command, sending player status (after 1s wait)
			setTimeout(self.notifyPlayerState, notifyStatusTimeout);
		}
	);
})(window, document);