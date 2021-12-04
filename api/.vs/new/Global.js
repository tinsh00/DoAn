'use strict'

var func = require('./function')
var ModelUserMN = require('./ModelUserMN')


module.exports = {
    io: null,
    BettingTime: 15000,
    Wait5000Time: 5000,
    Wait3000Time: 3000,
    Wait2000Time: 2000,
    Wait1500Time: 1500,
    StartTime: 2000,
    DelayTime: 5000,
    Status: { Wait: 0, Prepare: 1, Start: 2, Playing: 3, Finish: 4 },
    playerStatus: { wait: 0, prepare: 1, playing: 2 },
    Notice,
    getUserGold,
    setUserGold
}

function getUserGold(uID, cID) {
    if (cID) {
        let memberModel = ModelMemberMN.GetMemberModel(uID, cID)
        if (memberModel)
            return memberModel.cChips;
    } else {
        let userModel = ModelUserMN.GetUserModel(uID);
        if (userModel) {
            return userModel.userGolds;
        }
    }

    return 0;
}

function setUserGold(uID, value, cID) {
    if (cID) {
        ModelMemberMN.UpdateChip(uID, cID, value);
    } else {
        ModelUserMN.UpdateGold(uID, value);
    }
}

function Notice(socket, message) {
    socket.emit(func.Notice, { message });
}
