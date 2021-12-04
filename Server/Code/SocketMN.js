'use strict'

var listSocket = {};//uID : socket

module.exports = {
    addSocket,
    deleteSocket,
    getSocket,
}

function addSocket(socket) {
    listSocket[socket.uID] = socket;
}

function deleteSocket(uID) {
    delete listSocket[uID];
}

function getSocket(uID) {
    return listSocket[uID];
}