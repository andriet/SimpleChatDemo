var ChatMessageModel = function (name, text) {
    var self = this;
    self.name = name;
    self.timeStamp = moment().format('LLL');
    self.text = text;
}