const PORT = 52300;

let Player = require('./classes/player');

var io = require('socket.io')(PORT);

console.log("Server running");

let players = {};
let sockets = {};

io.on('connection', function(socket) {
	console.log("new user connected");

	let player = new Player(socket);
	let playerID = player.id;
	players[playerID] = player;
	sockets[playerID] = socket;

	socket.emit('register', {id : player.id});
	socket.emit('spawn', player);
	socket.broadcast.emit('spawn', player);

	for (let id in players) {
		if (id != playerID) {
			socket.emit('spawn', players[playerID]);
		}
	}

	socket.on('disconnect', function() {
		console.log("user disconnected");
		delete players[playerID];
		delete sockets[playerID];

		socket.broadcast.emit('userDisconnected', player);
	});
});