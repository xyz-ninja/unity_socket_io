const PORT = 52300;

var io = require('socket.io')(PORT);

console.log("Server running");

io.on('connection', function(socket) {
	console.log("new user connected");

	socket.on('disconnect', function() {
		console.log("user disconnected");
	});
});