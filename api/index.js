const express = require('express');
const app = express();

const mongooes = require('mongoose');

const dotenv = require('dotenv');
dotenv.config();


//Import Router
const userRouter = require('./routers/routerUser');
const playerRouter = require('./routers/routerPlayer');

//const authRouter = require('./routers/auth');
// const postRouter = require('./routers/post');

// const testRouter = require('./routers/test');

//const selectRouter = require('./routers/select');

// const productRouter = require('./routers/ins_del_upd_product');
// const ctddhRouter = require('./routers/ins_del_upd_ctddh');
// const ddhRouter = require('./routers/ins_del_upd_ddh');
// const loaispRouter = require('./routers/ins_del_upd_loaisp');

// const saveIMG_router = require('./routers/saveIMG');

// const supportAPI = require('./routers/supportAPI');

//Connect to DB
mongooes.connect(process.env.DB_CONNECT, { useNewUrlParser: true, useUnifiedTopology: true }, () => {
    console.log('Connected to DB!!!');
});

//Middleware
app.use(express.json());
app.use(function (req, res, next) {
    res.header("Access-Control-Allow-Methods", "*");
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
});
//Router Middlewares

app.use('/api/user', userRouter);
app.use('/api/player', playerRouter);

//app.use('/api/user', authRouter);
// app.use('/api/posts', postRouter);
//app.use('/api/select', selectRouter);

//app.use('/table/select', testRouter);

// app.use('/api/product', productRouter);
// app.use('/api/ctddh', ctddhRouter);
// app.use('/api/ddh', ddhRouter);
// app.use('/api/loaisp', loaispRouter);

// app.use('/api/saveIMG', saveIMG_router);

// app.use('/api/support', supportAPI);

app.listen(process.env.PORT || 3000, () => console.log('Server up and running'));