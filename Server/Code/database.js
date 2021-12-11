
'use strict';
const Mongoose = require("mongoose");

Mongoose.Promise = global.Promise;
const uri = 'mongodb+srv://tinsh00:thanhtin99@dbaiqlbsx.vsetj.mongodb.net/Game?retryWrites=true&w=majority';

var Models = {};

var UserSchema = Mongoose.Schema({
    uID: String,
    userName: String,
    
    userLevel: Number,
    userCoin: Number,
    userCurrentExp:Number,
   
    socketID: String,
    registerDay: {}
});


// var AvatarItemEuipSchema = Mongoose.Schema ({
//     userName : String ,
//     HairItem  : Number ,
//     FaceItem : Number ,
//     GlassItem : Number , 
//     SongItem : Number ,
//     BeardItem : Number ,
//     clothesItem : Number ,
//     registerDay : {}
// });


// var DarumaSchema = Mongoose.Schema ({
//     userName : String ,
//     darumaName : String ,
//     darumaLevel : Number ,  
//     darumaCurrentExp : Number ,
//     darumaSprite : Number , 
//     spriteBG : Number ,
//     spriteName : Number ,
// });

// var HouseItemSchema = Mongoose.Schema  ({
//     userName : String ,
//     houseName   : String , 
//     housePrice : Number ,
//     houseSprite : Number ,

// }) ;

// var HouseItemInMap = Mongoose.Schema ({
//     userName : String ,
//     idLandSlot : String ,
//     spriteHouse : Number ,
// })
var database = {
    Mongoose,
    connect: function () {
        Mongoose.connect(uri,{ useUnifiedTopology: true, useNewUrlParser: true, useCreateIndex: true }, function (err, db) {
            if (!err) {
                console.log('connected database', uri);
                Mongoose.set('useFindAndModify', false);
            } else console.log('err database', err)
        });
    },
    users: Mongoose.model('Users', UserSchema),
    //avatarItems : Mongoose.model ("AvatarItems" , AvatarItemEuipSchema) ,
    //darumaItems : Mongoose.model ("DarumaItems" , DarumaSchema) ,
    //houseItems  : Mongoose.model ("houseItems" , HouseItemSchema) ,
    //houseItemInMaps  : Mongoose.model ("HouseItemInMaps" , HouseItemInMap) ,
    ModelHand,
    ModelTable,
    findOneAndUpdate,

    deleteOne,
    deleteMany,
    saveModel,
    pushItem,
    updateModel
};

module.exports = database;

function updateModel(Model, condition, data) {
    Model.updateOne(condition, data, function (err) {
        if (err) console.log('err update model', Model, err)
    })
}

function pushItem(Model, condition, data, model) {
    Model.updateOne(condition, data, function (err, result) {
        if (err) {
            console.log('err pushItem ' + Model.modelName, err)
        } else {
            if (result.n == 0) {
                saveModel(Model, model);
            }
        }
    })
}

function saveModel(Model, model) {
    model.save(function (err) {
        if (err) console.log('saveModel err ' + Model.modelName, err);
    })
}



function deleteMany(Model, condition) {
    Model.deleteMany(condition, function (err) {
        if (err) console.log('delte many ' + Model.modelName, err)
    })

}

function deleteOne(Model, condition) {
    Model.deleteOne(condition, function (err) {
        if (err) console.log('delete one ' + Model.modelName, err);
    })

}


function findOneAndUpdate(Model, model, isQueue) {
    if (!Models[model._id]) {
        Models[model._id] = [];
    }
    let listModel = Models[model._id];

    if (!isQueue) {
        listModel.push({ Model, model })
        model.__v++;

        if (listModel.length > 1) return;
    }

    Model.findOneAndUpdate({ _id: model._id }, model, { upsert: true, new: true }, function (err, newModel) {
        if (err) console.log('findOneAndUpdate database', err);
        else {
            listModel.shift();//remove first model
            if (listModel.length > 0) {// if has queue, check next model
                while (listModel.length > 0) {
                    let tempModel = listModel[0].model;
                    if (compare(newModel, tempModel)) {// if equal remove
                        listModel.shift();
                    } else {// not equal, need to save
                        findOneAndUpdate(listModel[0].Model, tempModel, true);
                        break;
                    }
                }
            } else
                delete Models[model._id];
        }

    })
}

// return true if equal, else false
function compare(model1, model2) {
    for (let item in model1) {
        if (model1[item] != model2[item]) return false;
    }
    return true;
}

Init();

function Init() {
    database.connect();
   
    // var User1 = new database.users({
    //     userName:"tin1",
    //     userLevel:1,

    //     userCoin:3,
    //     userCurrentExp:1,    
    // })
    // User1.save();
    // console.log ("tin") ;
    // var item = new database.avatarItemEquip ({
    //     userName : "guestTeo" ,
    //     HairItem : 1 ,
    //     FaceItem : 2 ,
    //     BeardItem :6 ,
    //     GlassItem : 7,
    //     clothesItem : 10 ,
    //     SongItem  : 15
    // })
    // item.save () ;

    
}

//reset all socket id of user


function ModelHand(tbID, table, Hand) {
    let listHand = [];
    if (Hand) listHand.push(Hand);
    let model = new database.handHistory({ tbID, table, listHand });
    return model;
}

function ModelTable(tbID, tbName, tbBlind, tbAmount, cID) {
    let table = new database.tables({
        tbID,
        tbBlind,
        tbAmount,
        cID,
        tbFull: false,
        tbName,
        numberPlayer: 0
    });
    return table;
}
