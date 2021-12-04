'use strict';

var crypto = require('crypto');

class utility {       

    static Add2Array(arr1, arr2) {
        let arr = []
        for (let item of arr1)
            arr.push(item);
        for (let item of arr2)
            arr.push(item)

        return arr;
    }
    //return time now utc
    static GetTimeNow() {
        //time now
        let _timer2 = new Date();
        let _TimeNow = {
            years: _timer2.getUTCFullYear(),
            months: _timer2.getUTCMonth() + 1,
            days: _timer2.getUTCDate(),
            hours: _timer2.getUTCHours(),
            minutes: _timer2.getUTCMinutes(),
            seconds: _timer2.getUTCSeconds(),
            milliseconds: _timer2.getUTCMilliseconds()
        };
        return _TimeNow;
    }

    // retun date object utc
    static GetDateNow() {
        let time = new Date();

        return {
            years: time.getUTCFullYear(),
            months: time.getUTCMonth() + 1,
            days: time.getUTCDate()
        }
    }

    //input date time, return time objec utc
    static GetTime(datetime) {
        if(!datetime) return null;
        
        let _TimeNow = {
            years: datetime.getUTCFullYear(),
            months: datetime.getUTCMonth() + 1,
            days: datetime.getUTCDate(),
            hours: datetime.getUTCHours(),
            minutes: datetime.getUTCMinutes(),
            seconds: datetime.getUTCSeconds()
        };
        return _TimeNow;
    }

    // input time object, return date time utc 
    static GetTimeDate(time) {
        let timedate = new Date();
        timedate.setUTCHours(time.hours, time.minutes, time.seconds);
        return timedate;
    }

    //input time object, return day time utc
    static GetDayDate(time) {
        let day = this.GetTimeDate(time);
        day.setUTCFullYear(time.years, time.months - 1, time.days);
        return day;
    }

    static GetShortDate() {
        let time = new Date();
        return (time.getUTCMonth() + 1) + '-' + time.getUTCDate() + '-' + time.getUTCFullYear();
    }

    static GetDayString() {
        let time = new Date();
        return this.numberformat(time.getUTCMonth() + 1) + '-' + this.numberformat(time.getUTCDate()) + '-' + this.numberformat(time.getUTCFullYear());
    }

    static GetYesterdayString() {
        let time = new Date();
        time.setUTCDate(time.getUTCDate() - 1);
        return this.numberformat(time.getUTCMonth() + 1) + '-' + this.numberformat(time.getUTCDate()) + '-' + this.numberformat(time.getUTCFullYear());
    }

    static GetTimeString(time) {
        return this.numberformat(time.hours) + ':' + this.numberformat(time.minutes) + ':' + this.numberformat(time.seconds);
    }

    static ToUTCTime(time) {
        let date = new Date(time);
        date.setUTCFullYear(date.getFullYear(), date.getMonth(), date.getDate())
        date.setUTCHours(date.getHours(), date.getMinutes(), date.getMilliseconds());

        return date;
    }

    static numberformat(number) {
        if (number * 1 < 10) return '0' + number;
        return number;
    }

    static EndAfterHour(value) {
        //time now
        let _timer2 = new Date();
        let _TimeNow = {
            years: _timer2.getFullYear(),
            months: _timer2.getMonth() + 1,
            days: _timer2.getDate(),
            hours: value + _timer2.getHours(),
            minutes: _timer2.getMinutes(),
            seconds: _timer2.getSeconds(),
            milliseconds: _timer2.getMilliseconds()
        };
        return _TimeNow;
    }
    static AddDay(infos, value) {
        //time now
        var result = new Date(infos.end.years, infos.end.months - 1, infos.end.days, infos.end.hours, infos.end.minutes, infos.end.seconds, infos.end.milliseconds);
        result.setDate(result.getDate() + value);
        infos.end.years = result.getFullYear();
        infos.end.months = result.getMonth() + 1;
        infos.end.hours = result.getHours();
        infos.end.days = result.getDate();
        return infos;
    }
    static EndDay(value) {
        //time now
        let _timer2 = new Date();
        _timer2.setDate(_timer2.getDate() + value);
        let _TimeNow = {
            years: _timer2.getFullYear(),
            months: _timer2.getMonth() + 1,
            days: _timer2.getDate(),
            hours: _timer2.getHours(),
            minutes: _timer2.getMinutes(),
            seconds: _timer2.getSeconds(),
            milliseconds: _timer2.getMilliseconds()
        };
        return _TimeNow;
    }

    static getRandom(max) {
        return Math.random() * max;
    }

    static getRandomInt(max) {//include max
        return Math.round(this.getRandom(max));
    }

    static GetRandomTime(max) {//max is second, return milisecond
        return this.getRandomInt(max * 1000);
    }

    static GetRandomRange(min, max) {//second
        let value = this.getRandom(max - min);
        value += min;
        if (value < min) return min;

        return value;
    }

    static GetIRandomRange(min, max) {//second
        return Math.round(this.GetRandomRange(min, max));
    }

    static getTomorrowTime() {
        let time = new Date();
        time.setUTCHours(24, 0, 0);
        return time;
    }


    static removeItem(arr, item) {
        let isRemove = false;
        for (let i = 0; i < arr.length; i++) {
            if (arr[i] === item) {
                arr.splice(i, 1);
                isRemove = true;
            }
        }
        return isRemove;
    }

    
    static log(notice, message) {
        if (message)
            console.log(notice, message);
        else console.log(notice);
    }

    static getsum(arr, elm) {
        return arr.reduce(function (a, b) {
            return a + b[elm];
        }, 0);
    }
}

module.exports = utility;