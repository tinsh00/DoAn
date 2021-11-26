const mongooes = require('mongoose');

const playerSchema = new mongooes.Schema({
    level: {
        type: Number,
        required: true

    },
    coin: {
        type: Number,
        required: true

    },
    currentExp:
    {
        type: Number,
        required: true

    },
    missionSuccess:{
    type: Number,
    required: true
    
    },
    userEmail: {
        type: String,
        required: true,
        min: 6,
        max: 255
    }
});

module.exports = mongooes.model('Player', playerSchema);