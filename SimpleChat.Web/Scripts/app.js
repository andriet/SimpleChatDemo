﻿var ChatMessageModel = function (name, timestamp, text) {
    var self = this;
    self.name = name;
    self.timestamp = Date.now();
    self.text = text;
}