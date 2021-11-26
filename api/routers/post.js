const router = require('express').Router();
const User = require('../model/User');
const verify = require('./verifyToken');

router.get('/', verify, async (req, res) => {
    // res.json({
    //     post: {
    //         title: 'my first post',
    //         desciption: 'random data you should access'
    //     }
    // });

    // res.send(req.user);

    const findUser = await User.findById(req.user._id);
    if(findUser) return res.send(findUser);
});

module.exports = router;