'use strict'
var database = require('./database.js');
var AppOnStore = database.AppOnStore;

var GoogleStore = false;
var AppleStore = false;

var isMaintain = false;// when serv maintain

CheckStore();

function CheckStore() {
    AppOnStore.findOne({}, function(err, data){
        if(!err){
            if(!data){
                data = new AppOnStore({
                    GoogleStore: false,
                    AppleStore: false})
                data.save();
            }

            GoogleStore = data.GoogleStore;
            AppleStore = data.AppleStore;

            setTimeout(() => {
                CheckStore();
            }, 3600000);
        }
    })
} 

module.exports =  function CheckAvailable(socket, func){

    if(isMaintain) {
        ShowLoginErr(socket, false, func)
        return;
    }

    if(!socket.isUpdate){//not update
        if(!socket.OSVersion){
            ShowLoginErr(socket, false, func);
            return false;
        } 
        
        if(socket.OSVersion.includes('Android')){//android
            ShowLoginErr(socket, GoogleStore, func);
            return false;
        } 
        
        if(socket.OSVersion.includes('Mac OS')){//IOS
            ShowLoginErr(socket, AppleStore, func);
            return false;
        }
    }
    return true;
}


function ShowLoginErr(socket, avaiableOnStore, func) {
    if(avaiableOnStore){
        socket.emit(func, { message: 'Please update new version to play Game.' });
    } else {
        socket.emit(func, { message: 'The Server is maintaining. Please Join later.' });
    }
}
