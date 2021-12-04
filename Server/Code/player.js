'use strict'
var database = require('./database.js')
var utility = require('./utility.js')
var Global = require('./Global')
var ModelUserMN = require('./ModelUserMN')

class RealTime {
    constructor(player) {
        this.uID = player.uID;
        this.userName = player.userName;
        this.buying = player.buying;
        this.Win = player.tbGold - player.buying;
    }
}

module.exports = class Player {
    constructor(user) {
        this.uID = user.uID, this.userName = user.userName, this.userAvatar = user.userAvatar,
            this.tbGold = 0, this.position = -1;
        this.listDominos = [], this.status = Global.playerStatus.wait;
        this.TopUpValue = 0;
        this.isBetting = false;
        this.buying = 0;
        this.Win = 0;
        this.ExitNextHand = false;
    }

    static Create(socket) {
        let user = ModelUserMN.GetUserModel(socket.uID)
        if (user)
            socket.player = new Player(user);
    }

    setBettingStatus(bet) {//true or false
        this.isBetting = bet;
    }

    setStatus(status) {
        this.status = status;
    }

    isPlaying() {
        return this.status == Global.playerStatus.playing;
    }

    data() {
        return {
            uID: this.uID,
            userName: this.userName,
            userAvatar: this.userAvatar,
            tbGold: this.tbGold,
            position: this.position,
            status: this.status,
            list: this.listDominos,
            isBetting: this.isBetting
        }
    }

    FinishData() {
        return {
            uID: this.uID,
            userName: this.userName,
            list: this.listDominos,
            userAvatar: this.userAvatar,
            Win: this.Win
        }
    }

    CalculateScore() {
        for (let domino of this.listDominos) {
            this.Win -= Dominos.GetValue(domino);
        }

    }

    UpdateTbGold(value) {
        this.tbGold += value;
    }



    NoBet(TopValue, BotValue) {
        for (let domino of this.listDominos) {
            if (domino.TopValue == TopValue || domino.TopValue == BotValue
                || domino.BotValue == TopValue || domino.BotValue == BotValue) return false;
        }
        return true;
    }

    getRealTime() {
        return new RealTime(this);
    }

    Reset() {
        this.setStatus(Global.playerStatus.wait)
        this.listDominos = [];
        this.Win = 0;
    }

    endBet() {
        this.isBetting = false;
    }

}
