const router = require('express').Router();
const CTDDH = require('../model/CTDDH');
const DDH = require('../model/DDH');
const Product = require('../model/Product');
const {CTDDHValidation} = require('../validation');

//FUNCTION INSERT
router.post('/insert', async (req, res) => {

    //LETS VALIDATOR THE DATA BEFORE WE INSERT PRODUCT
    const {error} = CTDDHValidation(req.body);
    if(error) return res.status(400).send(error.details[0].message)

    //CHECK IdDDH AND IDSP IN TABLE DDH AND TABLE PRODUCT
    const findDDH = await DDH.findOne({_id: req.body.IdDDH});
    if(!findDDH) return res.status(401).send('IdDDH is not found');
    const findProduct = await Product.findOne({_id: req.body.IdSP});
    if(!findProduct) return res.status(401).send('IDSP is not found');

    //CHECKING IF the CTDDH with IdDDH and IdSP already IN THE DB
    const findCTDDH = await CTDDH.findOne({IdDDH: req.body.IdDDH, IdSP: req.body.IdSP});
    if(findCTDDH) return res.status(401).send('CTDDH with IdDDH and IdSP already exists');

    //CREATE A NEW CTDDH
    const ctddh = new CTDDH({
        IdDDH: req.body.IdDDH,
        IdSP: req.body.IdSP,
        Soluong: req.body.Soluong,
        DonGia: req.body.DonGia
    });
    try {
        res.send(ctddh);
        // res.send("Insert successful! \nid: " + ctddh._id + "\nData: " + ctddh.IdDDH + ctddh.IdSP);
        const savectddh = await ctddh.save();
    }
    catch (error) {
        res.status(403).send(error);
    }
});

//FUNCTION DELETE
router.delete('/delete', async (req, res) => {
    //VALIDATE INPUT
    var count = 0;
    var ctddh;
    if(!req.body._id) count = 1;
    if((!req.body.IdDDH || !req.body.IdSP) && count === 1) count = 3;

    //FIND CTDDH WITH ID OR IDDDH AND IDSP
    if(count === 1) ctddh = await CTDDH.findOne({IdDDH: req.body.IdDDH, IdSP: req.body.IdSP});
    if(count === 3) return res.status(400).send('Information please!!!');
    if(count === 0) ctddh = await CTDDH.findOne({_id: req.body._id});

    if(!ctddh) return res.status(402).send('The CTDDH is not found!');

    //DELETE
    try{
        ctddh.remove();
        res.send(ctddh);
        // res.send('Delete successful!!! \n' + ctddh._id + ' was deleted');
    }
    catch(err){
        res.send(err);
    }
});

//FUNCTION UPDATE
router.put('/update', async (req, res) => {

    //VALIDATE INPUT
    var count = 0;
    var ctddh;
    if(!req.body._id) count = 1;
    if((!req.body.IdDDH || !req.body.IdSP) && count === 1) count = 3;

    //FIND CTDDH WITH ID OR IDDDH AND IDSP
    if(count === 1) ctddh = await CTDDH.findOne({IdDDH: req.body.IdDDH, IdSP: req.body.IdSP});
    if(count === 3) return res.status(400).send('Information please!!!');
    if(count === 0) ctddh = await CTDDH.findOne({_id: req.body._id});

    if(!ctddh) return res.status(402).send('The CTDDH is not found!');

    //CHECK IdDDH AND IDSP IN TABLE DDH AND TABLE PRODUCT
    const findDDH = await DDH.findOne({_id: req.body.IdDDH});
    if(!findDDH) return res.status(401).send('IdDDH is not found');
    const findProduct = await Product.findOne({_id: req.body.IdSP});
    if(!findProduct) return res.status(401).send('IDSP is not found');

    //CHECKING IF THE CTDDH'S IDDDH AND IDSP ARE ALREADY IN THE DB
    const FINDctddh = await CTDDH.findOne({IdDDH: req.body.IdDDH, IdSP: req.body.IdSP});
    if(FINDctddh && !(ctddh.IdDDH === req.body.IdDDH && ctddh.IdSP === req.body.IdSP)) return res.status(401).send('IDDDH AND IDSP already exists');

    //UPDATE DATA FOR THE PRODUCT

    if(req.body.IdDDH) ctddh.IdDDH = req.body.IdDDH;
    if(req.body.IdSP) ctddh.IdSP = req.body.IdSP;
    if(req.body.Soluong) ctddh.Soluong = req.body.Soluong;
    if(req.body.DonGia) ctddh.DonGia = req.body.DonGia;
    try {
        res.send(ctddh);
        // res.send("Update successful!! \nid: " + ctddh._id);
        const updateCTDDH = await ctddh.save();
    }
    catch (error) {
        res.status(403).send(error);
    }
});

module.exports = router;