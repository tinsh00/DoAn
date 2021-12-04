'use strict'

class TimerControl{
    constructor(){
        this.listTimer = [];
        this.running = false;
    }

    AddTimer(timer){
        this.listTimer.push(timer);
        if(!this.running) {
            this.running = true;
            this.Run();
        }
    }

    RemoveTimer(timer){
        this.listTimer = this.listTimer.filter(t=> t && t != timer);

        this.CheckStop();
    }

    CheckStop(){
        if(this.listTimer.length == 0){
            clearTimeout(this.handle);
            this.running = false;
        }
    }

    Run() {
        this.handle = setTimeout(() => {
            this.DoWork();
            this.Run();
        }, 1000 - new Date().getUTCMilliseconds());
    }

    DoWork(){
        for(let timer of this.listTimer)
            timer.DoWork();

    }
}

var timerControl = new TimerControl();

module.exports = class timer {
    constructor(func, time) {
        this.func = func;
        this.time = time;
        this.endTime = null;
        this.running = false;
    }

    Start() {
        if (this.running) return;
        this.setEndTime();
        this.running = true
        timerControl.AddTimer(this);
    }

    setEndTime(){        
        if(this.leftTime > 0) {
            this.endTime = new Date();
            this.endTime.setUTCMilliseconds(this.endTime.getUTCMilliseconds() + this.leftTime);
            this.leftTime = 0;
        } else {
            this.endTime = new Date();
            this.endTime.setUTCMilliseconds(this.endTime.getUTCMilliseconds() +  this.time);
        }
    }

    DoWork() {//do every second
        if(this.endTime - new Date() <= 0){
            this.setEndTime();
            this.func();
        }
    }

    Stop() {
        if(this.running){
            timerControl.RemoveTimer(this);
            this.running = false;
            this.leftTime = this.endTime - new Date();

            if(this.leftTime < 0){
                this.func();
                this.leftTime = 0;
            }
        }
    }

    Destroy(){
        if(this.running){
            timerControl.RemoveTimer(this);
        }
    }
}
