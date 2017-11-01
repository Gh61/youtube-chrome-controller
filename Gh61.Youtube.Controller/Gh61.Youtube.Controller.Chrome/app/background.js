///<reference path="../scripts/_references.js" />

var BG = (function () {
	var commands = {
		"GetStatus": "stat",
		"PlayPause": "playpause",
		"GoNext": "next",
		"GoPrev" : "prev"
	}

	var self = this;
	self.websocket = null;
	self.log = function(obj) {
		console.log(obj);
	}

	self.sendCommand = function (commandName) {
		var result = false;
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
						result = true;
					}
				}
			}
		});

		return result;
	};

	self.tryConnectWebsocket = function() {
		self.websocket = new WebSocket("ws://127.0.0.1:13337/controller");
		self.websocket.onopen = function (evt) {
			console.log("[WS] Connected.");
		};
		self.websocket.onclose = function (evt) {
			console.log("[WS] Disconnected.");
			self.websocket = null;
		};
		self.websocket.onmessage = function (evt) {
			self.log("[WS] " + evt.data);

			var result = commands[evt.data];
			if (result) {
				if (typeof result === "string") {
					self.sendCommand(result);
				}
			}
		};

	};

	self.setStatus = function(status, title) {
		switch (status) {
			case "Buffering":
			case "Playing":
				chrome.browserAction.setIcon({
					path: "img/play_19.png"
				});
				break;
			case "Paused":
				chrome.browserAction.setIcon({
					path: "img/pause_19.png"
				});
				break;
			default:
				chrome.browserAction.setIcon({
					path: "img/note_19.png"
				});
				break;
		}

		if (self.websocket != null) {
			self.websocket.send("STATUS:" + status + ";" + title);
		}
	};

	// Listening to messages from tab(s)
	chrome.extension.onMessage.addListener(
		function(request, sender, sendResponse) {
			self.log("Message accepted:");
			self.log(JSON.stringify(request));

			if (request.status) {
				self.setStatus(request.status, request.title);
			}
		}
	);

	setInterval(function () {
		if (!self.sendCommand(commands.GetStatus)) {
			self.setStatus("...", "...");
		}

		if (self.websocket == null) {
			self.tryConnectWebsocket();
		}
	},
	10000); // every 10 seconds checking player status and trying to connect to WS
	

	return self;
})();