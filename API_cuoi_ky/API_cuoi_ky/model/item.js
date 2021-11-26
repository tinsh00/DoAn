const mongooes = require('mongoose');

const userSchema = new mongooes.Schema({
    name: {
        type: String,
        required: true,
        min: 6,
        max: 50
    },
    img: {
        type: [],
        required: true
    }
 });
 
 module.exports = mongooes.model('IMG', userSchema);