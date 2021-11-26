const router = require('express').Router();
const DDH = require('../model/DDH');
const CTDDH = require('../model/CTDDH');
const User = require('../model/User');
const {DDHValidation} = require('../validation');

//FUNCTION INSERT
router.post('/insert', async (req, res) => {

    //LETS VALIDATOR THE DATA BEFORE WE INSERT DDH
    const {error} = DDHValidation(req.body);
    if(error) return res.status(400).send(error.details[0].message)

    //CHECKING THE DDH'S userID IS ALREADY IN THE DB
    const userID = await User.findOne({_id: req.body.UserId});
    if(!userID) return res.status(401).send('userID not found');

    //CREATE A NEW DDH
    const ddh = new DDH({
        UserId: req.body.UserId,
        TT: req.body.TT
    });
    try {
        res.send(ddh);
        // res.send("Insert successful! \nid: " + ddh._id + "\nUserId: " + ddh.UserId);
        const saveDDH = await ddh.save();
    }
    catch (error) {
        res.status(403).send(error);
    }
});

//FUNCTION DELETE
router.delete('/delete', async (req, res) => {
    //VALIDATE INPUT
    var count = 0;
    var ddh;

    const fNgayDat = new Date(req.body.Ngay_doc_getTime);

    // console.log("date: " + fNgayDat + "|||");

    if(!req.body._id) count = 1;
    if((!req.body.UserId || !fNgayDat) && count === 1) count = 3;

    //FIND DDH WITH ID OR DDH DATA

    if(count === 1) ddh = await DDH.findOne({NgayDat: fNgayDat});
    if(count === 3) return res.status(400).send('Id or enough data please!!!');
    if(count === 0) ddh = await DDH.findOne({_id: req.body._id});

    if(!ddh) return res.status(402).send('The DDH is not found!');

    //FIND IDDDH IN TABLE CTDDH
    const ctddh = CTDDH.findOne({IdDDH: ddh._id});
    if(ctddh) return res.status(401).send('The IdDDH is exist in table ctddh, Delete fail!');
    
    //DELETE
    try{
        ddh.remove();
        res.send(ddh);
        // res.send('Delete successful!!! \n' + ddh._id + ' was deleted');
    }
    catch(err){
        res.send(err);
    }
});

//FUNCTION UPDATE
router.put('/update', async (req, res) => {
    //FIND DDH
    var ddh = await DDH.findOne({_id: req.body._id});
    if(!ddh) return res.status(402).send('The DDH is not found!');

    //CHECKING THE DDH'S userID IS ALREADY IN THE DB
    const userID = await User.findOne({_id: req.body.UserId});
    if(!userID) return res.status(401).send('userID not found');

    //UPDATE DATA FOR THE PRODUCT

    var oldName = ddh.UserId;

    ddh.UserId = req.body.UserId;
    try {
        res.send(ddh);
        // res.send("Update successful!! \nid: " + ddh._id + "\nUserId: " + oldName + '\nUserId became: ' + ddh.UserId);
        const updateDDH = await ddh.save();
    }
    catch (error) {
        res.status(403).send(error);
    }
});

module.exports = router;