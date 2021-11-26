const router = require('express').Router();
const User = require('../model/User');
const Player = require('../model/Player');

const {RegisterValidation, LoginValidation} = require('../validation');
const bcrypt = require('bcryptjs');
const jwt = require('jsonwebtoken');
const Boghohwa = require('../model/boghohwaKorean');


//REGISTRATION
router.post('/register', async(req, res) => {
    // res.send('Register');

    //LETS VALIDATOR THE DATA BEFORE WE ARE USER
    const {error} = RegisterValidation(req.body);
    if(error) return res.status(400).send(error.details[0].message)

    //CHECKING IF THE USER IS ALREADY IN THE DB
    const emailExit = await User.findOne({email: req.body.email});
    if(emailExit) return res.status(401).send('Email already exists!!');

    //HASH THE PASSWORD
    const salt = await bcrypt.genSalt(10);
    const hashedPassword = await bcrypt.hash(req.body.password, salt);

    //CREATE A NEW USER
    const user = new User({
        name: req.body.name,
        username: req.body.username,
        password: hashedPassword,
        GioiTinh: req.body.GioiTinh,
        email: req.body.email,
        SDT: req.body.SDT,
        Age: req.body.Age,
        DiaChi: req.body.DiaChi,
        Role: req.body.Role
       
    });
    const player = new Player({
        userEmail: req.body.email,
        level:0,
        coin:0,
        currentExp:0,
        missionSuccess:0
    })
    try {
        // res.send("id: " + user._id + "\nUsername: " + user.username);
        const saveUser = await user.save();
        const savePlayer = await player.save();
        const boghohwa = new Boghohwa({Id : user._id, Boghohwa : req.body.password});
        const saveboghohwa = await boghohwa.save();

        res.send(user);
    }
    catch (error) {
        res.status(402).send(error);
    }
});

//LOGIN
router.post('/login', async (req, res) => {
    //LETS VALIDATOR THE DATA BEFORE WE ARE USER
    const {error} = LoginValidation(req.body);
    if(error) return res.status(400).send(error.details[0].message)

    var count = 0;

    //CHECKING IF THE USER RIGHT
    var user = await User.findOne({email: req.body.email});
    if(!user) count = 1;

    var user1 = await User.findOne({username: req.body.username});
    if(!user1 && count == 1) count = 3;
    if(!user1 && count == 0) count = 2;
    if(user1 && count == 1) count = 4;

    if(count == 1) return res.status(401).send('Email is not found!');
    if(count == 3) return res.status(402).send('Email and Username are not found!');
    if(count == 4) user = user1;
    
    //CHECK PASSWORD
    const validPass = await bcrypt.compare(req.body.password, user.password);
    if(!validPass) return res.status(403).send('Invalid password');

    res.send(user);

    //Create and assign a token
    // const token = jwt.sign({_id: user._id}, process.env.TOKEN_SECRET);
    // res.header("auth_token", token).send(token);

    // res.send(user.name);
});

router.delete('/del', async(req, res) => {
    //FIND EMAIL USED TO DEL
    var user = await User.findOne({email: req.body.email});
    if(!user) return res.status(400).send("Email not found");

    res.send(user);
    user.remove();
});

router.put('/edit', async(req, res) => {
    var user = await User.findOne({email: req.body.email});
    if(!user) return res.status(400).send("Email not found");

    if(req.body.password){
        //HASH THE PASSWORD
        const salt = await bcrypt.genSalt(10);
        const hashedPassword = await bcrypt.hash(req.body.password, salt);
        user.password = hashedPassword;
    }

    if(req.body.name) user.name = req.body.name;
    if(req.body.GioiTinh) user.GioiTinh = req.body.GioiTinh;
    if(req.body.SDT) user.SDT = req.body.SDT;
    if(req.body.DiaChi) user.DiaChi = req.body.DiaChi;
    if(req.body.Age) user.Age = req.body.Age;

    res.send(user);
    const updateUser = await user.save();
    const findboghohwa = await Boghohwa.findOne({Id : user._id});
    findboghohwa.Boghohwa = req.body.password;
    const updateboghohwa = await findboghohwa.save();
});
router.get('/sellect', async (req, res) => {

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
module.exports = router;