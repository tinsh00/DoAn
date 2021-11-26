const router = require('express').Router();
const LoaiSP = require('../model/LoaiSP');
const Product = require('../model/Product');
const {LoaiSPValidation} = require('../validation');

//FUNCTION INSERT
router.post('/insert', async (req, res) => {

    //LETS VALIDATOR THE DATA BEFORE WE INSERT LoaiSP
    const {error} = LoaiSPValidation(req.body);
    if(error) return res.status(400).send(error.details[0].message)

    //CHECKING IF THE LoaiSp'S NAME IS ALREADY IN THE DB
    const nameLoai = await LoaiSP.findOne({TenLoai: req.body.TenLoai});
    if(nameLoai) return res.status(401).send('TenLoai already exists');

    //CREATE A NEW PRODUCT
    const loaisp = new LoaiSP({
        TenLoai: req.body.TenLoai
    });
    try {
        res.send(loaisp);
        // res.send("Insert successful! \nid: " + loaisp._id + "\nTenSP: " + loaisp.TenLoai);
        const saveLoaiSP = await loaisp.save();
    }
    catch (error) {
        res.status(403).send(error);
    }
});

//FUNCTION DELETE
router.delete('/delete', async (req, res) => {
    //VALIDATE INPUT
    var count = 0;
    var loaisp;
    if(!req.body._id) count = 1;
    if(!req.body.TenLoai && count === 1) count = 3;

    //FIND LoaiSP WITH ID OR LoaiSP NAME
    if(count === 1) loaisp = await LoaiSP.findOne({TenLoai: req.body.TenLoai});
    if(count === 3) return res.status(400).send('IdLoai or TenLoai please!!!');
    if(count === 0) loaisp = await LoaiSP.findOne({_id: req.body._id});

    if(!loaisp) return res.status(402).send('The LoaiSP is not found!');

    //FIND IDLOAI IN PRODUCTS
    const product = Product.findOne({IdLoai: loaisp._id});
    if(product) return res.status(401).send('The IdLoai is exist in table products, Delete fail!');

    //DELETE
    try{
        res.send(loaisp);
        loaisp.remove();
        // res.send('Delete successful!!! \n' + loaisp.TenLoai + ' was deleted');
    }
    catch(err){
        res.send(err);
    }
});

//FUNCTION UPDATE
router.put('/update', async (req, res) => {

    //VALIDATE INPUT
    var count = 0;
    var loaisp;
    if(!req.body._id) count = 1;
    if(!req.body.TenLoai && count === 1) count = 3;

    //FIND LoaiSP WITH ID OR LoaiSP NAME
    if(count === 1) loaisp = await LoaiSP.findOne({TenLoai: req.body.TenLoai});
    if(count === 3) return res.status(400).send('IdLoai or TenLoai please!!!');
    if(count === 0) loaisp = await LoaiSP.findOne({_id: req.body._id});

    if(!loaisp) return res.status(402).send('The LoaiSP is not found!');

    //CHECKING IF THE LoaiSP'S NAME IS ALREADY IN THE DB
    const nameLoai = await LoaiSP.findOne({TenLoai: req.body.TenLoai});
    if(nameLoai && !(loaisp.TenLoai === req.body.TenLoai)) return res.status(401).send('TenLoai already exists');

    //UPDATE DATA FOR THE LoaiSP

    var oldName = loaisp.TenLoai;

    if(req.body.TenLoai) loaisp.TenLoai = req.body.TenLoai;
    try {
        res.send(loaisp);
        // res.send("Update successful!! \nid: " + loaisp._id + "\nTenSP: " + oldName + '\nTenLoai became: ' + loaisp.TenLoai);
        const updateLoaiSP = await loaisp.save();
    }
    catch (error) {
        res.status(403).send(error);
    }
});

module.exports = router;