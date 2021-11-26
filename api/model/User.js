const mongooes = require('mongoose');

const userSchema = new mongooes.Schema({
   name: {
       type: String,
       required: true,
       min: 6,
       max: 50
   },
   username: {
       type: String,
       required: true,
       max: 20
   },
   password: {
    type: String,
    required: true,
    max: 50,
    min: 6
    },
    GioiTinh: {
        type: Boolean,
        default: true
    },
   email: {
       type: String,
       required: true,
       min: 6,
       max: 255
   },
   SDT: {
       type: String,
       required: true,
       max: 50
   },
   Age: {
    type: Number

    },
   DiaChi: {
        type: String,
        required: true,
        max: 50
   },
   Role: {
       type: String,
       required: true,
       max: 10
   },
   date: {
       type: Date,
       default: Date.now
   }
});

module.exports = mongooes.model('User', userSchema);