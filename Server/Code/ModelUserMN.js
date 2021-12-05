'use strict'


var ModelMN = require('./ModelMN');
var SocketMN = require('./SocketMN');
var func = require('./function')

var ListModelUser = {};

var UpdateUserGold = 'UpdateUserGold';
var UpdateUserGem = 'UpdateUserGem';

class ModelUserMN extends ModelMN {
    constructor(user) {
        super(database.users, user);
    }


    UpdateSocketID(socketID) {
        this.model.socketID = socketID;
        this.Update({ socketID })
    }


    Update(data) {
        database.users.updateOne({ uID: this.model.uID }, data, function (err) {
            if (err) {
                console.log('err update user ' + data, err);
            }
        })

    }
}


module.exports = {
    SetUserModel,
    GetUserModel,
    RemoveUserModel,
    UpdateUser,
    UpdateSocketID,
    UpdateFlag,
    SetGold,
    UpdateGold,
    UpdateGem,
    UpdateEmail,
    UpdatePass,
    UpdateAvatar,
    UpdateUserName
}



function UpdateUserName(uID, userName) {
    let modelMN = ListModelUser[uID];
    if (modelMN) {
        modelMN.model.userName = userName;
        modelMN.Update({ userName });
    }
}

function UpdateAvatar(userModel) {
    if(userModel.userAvatar == userModel.uID) return;

    let modelMN = ListModelUser[userModel.uID];
    if(!modelMN){//user offline
        userModel.userAvatar = userModel.uID;
        userModel.save();        
    } else {
        modelMN.model.userAvatar = modelMN.model.uID;
        modelMN.Update({ userAvatar: modelMN.model.uID });
    }
}

function SetGold(uID, value) {
    let modelMN = ListModelUser[uID];
    if (modelMN) {
        modelMN.model.userGolds = value;
        modelMN.Save();
    }
}

function UpdatePass(uID, pass) {
    let modelMN = ListModelUser[uID];
    if (modelMN) {
        modelMN.model.userPass = pass;
        modelMN.Update({ userPass: pass });
    }
}


function SetUserModel(user) {
    let modelMN = ListModelUser[user.uID];
    if (!modelMN)
        modelMN = new ModelUserMN(user);
    ListModelUser[user.uID] = modelMN;
    return modelMN;
}

function GetUserModel(uID) {
    if (ListModelUser[uID]) return ListModelUser[uID].model;
}

function RemoveUserModel(uID) {
    delete ListModelUser[uID];
}

function UpdateUser(user) {
    let modelUserMN = ListModelUser[user.uID];
    if (!modelUserMN) {
        modelUserMN = SetUserModel(user);
    }
    modelUserMN.Save();

}

function UpdateSocketID(uID, socketID = null) {
    let modelMN = ListModelUser[uID];
    if (modelMN) {
        modelMN.UpdateSocketID(socketID);
    }
}

function UpdateFlag(uID, flag) {
    let modelMN = ListModelUser[uID];
    if (modelMN) {
        modelMN.model.userFlag = flag;
        modelMN.Update({ userFlag: flag });
    }
}

function UpdateGold(uID, value) {
    let modelMN = ListModelUser[uID];
    if (modelMN) {
        modelMN.model.userEnergys += value;
        modelMN.Save();

        let socket = SocketMN.getSocket(uID);
        if (socket) {
            socket.emit(UpdateUserGold, { value: modelMN.model.userEnergys });
        }
    } else {
        database.users.findOne({ uID }, function (err, user) {
            if (user) {
                user.userEnergys += value;
                user.save();
            }
        })
    }
}

function UpdateGem(uID, value){
    let modelMN = ListModelUser[uID];
    if (modelMN) {
        modelMN.model.userChips += value;
        modelMN.Save();

        let socket = SocketMN.getSocket(uID);
        if (socket) {
            socket.emit(UpdateUserGem, { value: modelMN.model.userChips });
        }
    }
}

function UpdateEmail(uID, email) {
    let modelMN = ListModelUser[uID];
    if (modelMN) {
        modelMN.model.userEmail = email;
        modelMN.Update({ userEmail: email });
    }
}