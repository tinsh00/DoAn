const mongooes = require('mongoose');

const loaiSPSchema = new mongooes.Schema({
    TenLoai: {
        type: String,
        required: true
    },
    date: {
        type: Date,
        default: Date.now
    }
});

module.exports = mongooes.model('LoaiSP', loaiSPSchema);