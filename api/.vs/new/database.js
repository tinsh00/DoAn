'use strict';
const Mongoose = require("mongoose");

Mongoose.Promise = global.Promise;

const uri = 'mongodb://localhost:3000/';
var Models = {};

var UserSchema = Mongoose.Schema({
    uID: String,
    userName: String,
    
    userEnergys: Number,
    userChips: Number,
   
    socketID: String,
    
});