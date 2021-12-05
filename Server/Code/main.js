'use strict';
var port = process.env.PORT || 27017
const io = require('socket.io')(port);

var Global = require('./Global')

Global.io = io;


var version = '1.0';

console.log("====================== Welcome to Solder's Avenger ======================");
console.log("====================== Server is started at Port : " + port + " ======================");

//user
var User = require('./User.js');
console.log ("1") ;
//Socket Event Between unity3d and nodejs
 io.on('connection', function (socket) {
    console.log ("2") ;
    User(socket);// connect player
    
   
});
 // socket.emit('CheckVersion', {});

    // socket.on('CheckVersion', function(data)
    // {
    //     if (data.version == version) 
    //         socket.isUpdate = true;
    //     socket.OSVersion = data.OSVersion;    
    // })





