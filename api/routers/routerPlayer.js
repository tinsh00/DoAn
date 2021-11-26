const router = require('express').Router();
const Player = require('../model/Player');
const {RegisterValidation, LoginValidation} = require('../validation');
const bcrypt = require('bcryptjs');
const jwt = require('jsonwebtoken');
const Boghohwa = require('../model/boghohwaKorean');

//FUNCTION UPDATE
router.put('/update', async (req, res) => {
    //UPDATE DATA FOR THE Player
    
    var player;
    player = await Player.findOne({userEmail: req.body.userEmail});
    if(!player) return res.status(402).send('The Player is not found!');

    if(req.body.level) player.level = req.body.level;
    if(req.body.coin) player.coin = req.body.coin;
    if(req.body.currentExp) player.currentExp = req.body.currentExp;
    if(req.body.missionSuccess) player.missionSuccess = req.body.missionSuccess;
    
    try {
        // res.send("Update successful!! \nid: " + product._id + "\nTenSP: " + oldName + '\nTenSP became: ' + product.TenSP);
        res.send(player);
        const updatePlayer = await player.save();
    }
    catch (error) {
        res.status(403).send(error);
    }
});
module.exports = router;