const http = require('http');

const router = require('express').Router();

const User = require('../model/User');
// const Product = require('../model/Product');
// const CTDDH = require('../model/CTDDH');
// const DDH = require('../model/DDH');
// const LoaiSP = require('../model/LoaiSP');

router.get('/user', async (req, res) => {
    var users = await User.find({});

    data = '<table border="1" style="border-collapse:collapse" cellspacing="5" cellpadding="15">';
    data += '<tr><th>ID</th><th>Name</th><th>Email</th><th>UserName</th><th>GioiTinh</th><th>Address</th><th>Rule</th></tr>';
    users.forEach( function (item) {
        data += '<tr>';
        data += '<td>' + item._id + '</td>';
        data += '<td>' + item.name + '</td>';
        data += '<td>' + item.email + '</td>';
        data += '<td>' + item.username + '</td>';
        data += '<td>' + item.GioiTinh + '</td>';
        data += '<td>' + item.DiaChi + '</td>';
        data += '<td>' + item.Role + '</td>';
        data += '</tr>';
    });
    data += '</table>';
    res.writeHead(200, {'Content-Type': 'text/html'});
    res.end(data);
});

// router.get('/product', async (req, res) => {
//     var products = await Product.find({});

//     data = '<table border="1" style="border-collapse:collapse" cellspacing="5" cellpadding="15">';
//     data += '<tr><th>ID</th><th>Name</th><th>Price</th><th>Count</th><th>IMG</th></tr>';
//     products.forEach( function (item) {
//         data += '<tr>';
//         data += '<td>' + item._id + '</td>';
//         data += '<td>' + item.TenSP + '</td>';
//         data += '<td>' + item.Gia + '</td>';
//         data += '<td>' + item.Soluong + '</td>';
//         data += '<td>' + item.img + '</td>';
//         data += '</tr>';
//     });
//     data += '</table>';
//     res.writeHead(200, {'Content-Type': 'text/html'});
//     res.end(data);
// });

// router.get('/ctddh', async (req, res) => {
//     var ctddhs = await CTDDH.find({});

//     data = '<table border="1" style="border-collapse:collapse" cellspacing="5" cellpadding="15">';
//     data += '<tr><th>ID</th><th>IdDDH</th><th>IdSP</th><th>Soluong</th><th>DonGia</th></tr>';
//     ctddhs.forEach( function (item) {
//         data += '<tr>';
//         data += '<td>' + item._id + '</td>';
//         data += '<td>' + item.IdDDH + '</td>';
//         data += '<td>' + item.IdSP + '</td>';
//         data += '<td>' + item.Soluong + '</td>';
//         data += '<td>' + item.DonGia + '</td>';
//         data += '</tr>';
//     });
//     data += '</table>';
//     res.writeHead(200, {'Content-Type': 'text/html'});
//     res.end(data);
// });

// router.get('/ddh', async (req, res) => {
//     var ddhs = await DDH.find({});

//     data = '<table border="1" style="border-collapse:collapse" cellspacing="5" cellpadding="15">';
//     data += '<tr><th>ID</th><th>UserId</th><th>NgayDat</th><th>NgayDat.getTime()</th></tr>';
//     ddhs.forEach( function (item) {
//         data += '<tr>';
//         data += '<td>' + item._id + '</td>';
//         data += '<td>' + item.UserId + '</td>';
//         data += '<td>' + item.NgayDat + '</td>';
//         data += '<td>' + item.NgayDat.getTime() + '</td>';
//         data += '</tr>';
//     });
//     data += '</table>';
//     res.writeHead(200, {'Content-Type': 'text/html'});
//     res.end(data);
// });

// router.get('/loaisp', async (req, res) => {
//     var loaisp = await LoaiSP.find({});

//     data = '<table border="1" style="border-collapse:collapse" cellspacing="5" cellpadding="15">';
//     data += '<tr><th>TenLoai</th><th>ID</th></tr>';
//     loaisp.forEach( function (item) {
//         data += '<tr>';
//         data += '<td>' + item.TenLoai + '</td>';
//         data += '<td>' + item._id + '</td>';
//         data += '</tr>';
//     });
//     data += '</table>';
//     res.writeHead(200, {'Content-Type': 'text/html'});
//     res.end(data);
// });

module.exports = router;