let shortID = require('shortid');

module.exports = class Player {
	constructor(socket) {
		this.socket = socket;
		this.username = "";
		this.id = shortID.generate();
	}
};