var io = require('socket.io')(process.env.PORT|| 4567);

console.log("Server has started");

io.on('connection', function(socket) {

    console.log('Client connected.');

    // Disconnect listener
    socket.on('disconnect', function() {
        console.log('Client disconnected.');
    });
});