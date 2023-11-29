let shortID = require('shortid');

class Player {
	constructor(socket) {
		this.socket = socket;
		this.username = "";
		this.id = shortID.generate();
	}
}


module.exports = Player;