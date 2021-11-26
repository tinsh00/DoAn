const router = require('express').Router();
const Product = require('../model/Product');
const CTDDH = require('../model/CTDDH');
const LoaiSP = require('../model/LoaiSP');
const {ProductValidation} = require('../validation');

//FUNCTION INSERT
router.post('/insert', async (req, res) => {

    //LETS VALIDATOR THE DATA BEFORE WE INSERT PRODUCT
    const {error} = ProductValidation(req.body);
    if(error) return res.status(400).send(error.details[0].message)

    //CHECKING IF THE PRODUCT'S NAME IS ALREADY IN THE DB
    const nameProduct = await Product.findOne({TenSP: req.body.TenSP});
    if(nameProduct) return res.status(401).send('TenSP already exists');

    //CHECKING IF THE PRODUCT'S IDLoai IS ALREADY IN THE DB
    if(req.body.IdLoai){
        const IdLoaiProduct = await LoaiSP.findOne({TenLoai: req.body.IdLoai});
        if(!IdLoaiProduct) return res.status(401).send('IdLoai not found');
    }

    //CREATE A NEW PRODUCT
    const product = new Product({
        TenSP: req.body.TenSP,
        Gia: req.body.Gia,
        Soluong: req.body.Soluong,
        IdLoai: req.body.IdLoai,
        img: req.body.img
    });
    try {
        res.send(product);
        // res.send("Insert successful! \nid: " + product._id + "\nTenSP: " + product.TenSP);
        const saveProduct = await product.save();
    }
    catch (error) {
        res.status(403).send(error);
    }
});

//FUNCTION DELETE
router.delete('/delete', async (req, res) => {
    //VALIDATE INPUT
    var count = 0;
    var product;
    if(!req.body._id) count = 1;
    if(!req.body.TenSP && count === 1) count = 3;

    //FIND PRODUCT WITH ID OR PRODUCT NAME
    if(count === 1) product = await Product.findOne({TenSP: req.body.TenSP});
    if(count === 3) return res.status(400).send('IdProduct or NameProduct please!!!');
    if(count === 0) product = await Product.findOne({_id: req.body._id});

    if(!product) return res.status(402).send('The Product is not found!');

    //FIND IDDDH IN TABLE CTDDH
    const ctddh = CTDDH.findOne({IdSP: product._id});
    if(ctddh) return res.status(401).send('The IdSP is exist in table ctddh, Delete fail!');

    //DELETE
    try{
        product.remove();
        res.send(product);
        // res.send('Delete successful!!! \n' + product.TenSP + ' was deleted');
    }
    catch(err){
        res.send(err);
    }
});

//FUNCTION UPDATE
router.put('/update', async (req, res) => {

    //VALIDATE INPUT
    var count = 0;
    var product;
    if(!req.body._id) count = 1;
    if(!req.body.TenSP && count === 1) count = 3;

    //FIND PRODUCT WITH ID OR PRODUCT NAME
    if(count === 1) product = await Product.findOne({TenSP: req.body.TenSP});
    if(count === 3) return res.status(400).send('IdProduct or NameProduct please!!!');
    if(count === 0) product = await Product.findOne({_id: req.body._id});

    if(!product) return res.status(402).send('The Product is not found!');

    //CHECKING IF THE PRODUCT'S NAME IS ALREADY IN THE DB
    const nameProduct = await Product.findOne({TenSP: req.body.TenSP});
    if(nameProduct && !(product.TenSP === req.body.TenSP)) return res.status(401).send('TenSP already exists');

    //CHECKING IF THE PRODUCT'S IDLoai IS ALREADY IN THE DB
    if(req.body.IdLoai){
        const IdLoaiProduct = await LoaiSP.findOne({TenLoai: req.body.IdLoai});
        if(!IdLoaiProduct) return res.status(401).send('IdLoai not found');
    }

    //UPDATE DATA FOR THE PRODUCT

    var oldName = product.TenSP;

    if(req.body.TenSP) product.TenSP = req.body.TenSP;
    if(req.body.Gia) product.Gia = req.body.Gia;
    if(req.body.Soluong) product.Soluong = req.body.Soluong;
    if(req.body.IdLoai) product.IdLoai = req.body.IdLoai;
    if(req.body.img) product.img = req.body.img;
    try {
        res.send(product);
        // res.send("Update successful!! \nid: " + product._id + "\nTenSP: " + oldName + '\nTenSP became: ' + product.TenSP);
        const updateProduct = await product.save();
    }
    catch (error) {
        res.status(403).send(error);
    }
});

module.exports = router;