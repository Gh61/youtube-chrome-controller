///<reference path="../scripts/_references.js" />

var BG = (function () {
	var self = this;
	self.log = function(obj) {
		console.log(obj);
	}

	self.sendCommand = function (commandName) {
		// I am sending command to all tabs in all windows
		chrome.windows.getAll({
			populate: true
		}, function (windows) {
			for (var w = 0; w < windows.length; w++) {
				for (var i = 0; i < windows[w].tabs.length; i++) {
					var tab = windows[w].tabs[i];
					if (tab.url.indexOf("youtube") > -1) {
						var request = {
							command: commandName
						};
						chrome.tabs.sendMessage(tab.id, request);
					}
				}
			}
		});
	}

	// Listening to messages from tab(s)
	chrome.extension.onMessage.addListener(
		function(request, sender, sendResponse) {
			self.log("Message accepted:");
			self.log(JSON.stringify(request));
		}
	);

	return self;
})();