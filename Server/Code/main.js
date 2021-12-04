'use strict';
var port = process.env.PORT || 6679
const io = require('socket.io')(port);

var Global = require('./Global')

Global.io = io;

//var database = require('./database');
var version = '1.0';

console.log("====================== Welcome to DarumaLand  server ======================");
console.log("====================== Server is started at Port : " + port + " ======================");

//user
var User = require('./User.js');
console.log ("^^^^^^1") ;
//Socket Event Between unity3d and nodejs
 io.on('connection', function (socket) {
     // socket.emit('CheckVersion', {});

    // socket.on('CheckVersion', function(data)
    // {
    //     if (data.version == version) 
    //         socket.isUpdate = true;
    //     socket.OSVersion = data.OSVersion;    
    // })
    console.log ("^^^^^^2") ;
    User(socket);// connect player
});





