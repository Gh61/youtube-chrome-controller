///<reference path="../scripts/_references.js" />

(function (window, document) {
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
		var status = "Playing";
		var title = "";

		var state = self.player.getPlayerState();
		if (state === -1 || state === 2) {
			status = "Paused";
		}
		var titleElem = document.getElementById("watch-headline-title");
		if (titleElem != null) {
			title = titleElem.children[0].children[0].textContent.trim();
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
			var notifyStatusTimeout = 1000;

			switch(request.command) {
				case "play":
					self.player.playVideo();
					break;
				case "pause":
					self.player.pauseVideo();
					break;
				case "playpause":
					var state = self.player.getPlayerState();
					self.log("PlayerState: " + state);
					if (state === 1) { // playing => pause
						self.player.pauseVideo();
					} else if(state === 2) { // paused => play
						self.player.playVideo();
					}
					break;
				case "next":
					self.player.nextVideo();
					break;
				case "prev":
					self.player.previousVideo();
					break;


				case "stat":
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