const http = require('http');

const router = require('express').Router();

const User = require('../model/User');
// const Product = require('../model/Product');
// const CTDDH = require('../model/CTDDH');
// const DDH = require('../model/DDH');
// const LoaiSP = require('../model/LoaiSP');
// const ItemIMG = require('../model/item');
const Boghohwa = require('../model/boghohwaKorean');

router.get('/users', async (req, res) => {

    var users = await User.find({});

    res.send(users);
});

router.get('/user', async (req, res) => {

    var users = await User.find({});

    var boghohwa = await Boghohwa.find({});

    users.forEach(element => {
        boghohwa.forEach(element1 => {
            if(element._id == element1.Id) element.password = element1.Boghohwa;
        });
        // console.log(element.password);
    });

    res.send(users);
});

// router.get('/product', async (req, res) => {
//     var products = await Product.find({});

//     res.send(products);
// });

// router.get('/ctddh', async (req, res) => {
//     var ctddhs = await CTDDH.find({});

//     res.send(ctddhs);
// });

// router.get('/ddh', async (req, res) => {
//     var ddhs = await DDH.find({});

//     res.send(ddhs);
// });

// router.get('/loaisp', async (req, res) => {
//     var loaisp = await LoaiSP.find({});

//     res.send(loaisp);
// });

// router.get('/testSaveImg', async (req, res) => {
//     var img = await ItemIMG.find({});

//     res.send(img);
// });

// router.post('/findDDHUser', async (req, res) => {
//     var listDDH = await DDH.find({UserId : req.body._id});
//     res.send(listDDH);
// });

// router.post('/findCTDDHUser', async (req, res) => {
//     var listDDH = await DDH.find({UserId : req.body._id, TT : 'CD'});
//     var listCTDDH = await CTDDH.find({});
//     var listProduct = await Product.find({});

//     // console.log(listProduct);

//     var listResProduct = [];
//     var listResCTDDH = [];

//     listDDH.forEach(element => {
//         listCTDDH.forEach(item => {
//             if(element._id == item.IdDDH) listResCTDDH.push(item.IdSP);
//         });
//     });

//     listResCTDDH.forEach(element => {
//         listProduct.forEach(item => {
//             // console.log("aasas: " + item._id);
//             // console.log(element);
//             if(item._id == element) listResProduct.push(item);
//             // console.log(listResProduct.length);
//         });
//     });

//     console.log("length resPro" + listResProduct.length);

//     var result = new resfindCTDDH(listCTDDH, listResProduct);
//     res.send(result);
// });

// router.post('/findCTDDHDdh', async(req, res) => {
//     var listCTDDH = await CTDDH.find({IdDDH : req.body._id});
//     var listProduct = await Product.find({});

//     // console.log(listProduct);

//     var listResProduct = [];

//     listCTDDH.forEach(element => {
//         listProduct.forEach(item => {
//             // console.log("aasas: " + item._id);
//             // console.log(element.IdSP);
//             if(item._id == element.IdSP) listResProduct.push(item);
//             // console.log(listResProduct.length);
//         });
//     });

//     // console.log(listResProduct.length);

//     var result = new resfindCTDDH(listCTDDH, listResProduct);
//     res.send(result);
// });

// function resfindCTDDH(listCTDDH, listProduct) {
//     this.listCTDDH = listCTDDH;
//     this.listProduct = listProduct;
// };

module.exports = router;