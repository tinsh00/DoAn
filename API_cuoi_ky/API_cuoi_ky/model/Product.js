const mongooes = require('mongoose');

const  productSchema = new mongooes.Schema({
    TenSP: {
        type: String,
        required: true,
        max: 100
    },
    Gia: {
        type: Number,
        required: true,
    },
    Soluong: {
        type: Number,
        required: true
    },
    IdLoai: {
        type: String,
        required: true
    },
    img: {
        type: String,
        required: false,
    },
    date: {
        type: Date,
        default: Date.now
    }
});

module.exports = mongooes.model('Product', productSchema);