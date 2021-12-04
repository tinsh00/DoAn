'use strict';
var database = require('./database.js');
var bcrypt = require('bcryptjs');
var nodemailer = require('nodemailer');
var shortId = require('shortid');

var utility = require('./utility.js');
var fs = require('fs');

var randomize = require('randomatic');
var func = require('./function.js')
var Global = require('./Global')
var SocketMN = require('./SocketMN')

var ModelUserMN = require('./ModelUserMN');
const { LoadHouseInMap } = require('./function.js');

var users = database.users;
var avatarItems = database.avatarItems ;
var darumaItems = database.darumaItems ;
var houseItems = database.houseItems ;
var houseItemInMaps = database.houseItemInMaps ;

function NewUser(uID, userName) {
    var user = new users(
        {
            uID, userName, userCoin: 0, userLevel: 0, userCurrentExp:0,
            registerDay: utility.GetTimeNow()
        });

    database.saveModel(users, user);

    return user;
}

function NewAvatarItem (userName , HairItem , FaceItem ,    BeardItem , SongItem , GlassItem , clothesItem) {
    var avatarItem = new avatarItems (
    {
        userName  , HairItem, FaceItem ,    BeardItem , SongItem , GlassItem , clothesItem
    }) ;
    database.saveModel (avatarItems , avatarItem) ;
    return avatarItem ;
}

function NewHouseItem (userName , houseName , housePrice , houseSprite)
{
    var houseItem = new houseItems ({
        userName , houseName , housePrice , houseSprite
    }) ;
    database.saveModel (houseItems , houseItem) ;
    return houseItem ;
}

function NewBuildingInMap (userName , idLandSlot , spriteHouse) {
    var newHouse = new houseItemInMaps ({
        userName , idLandSlot , spriteHouse
    }) ;
    database.saveModel (houseItemInMaps , newHouse) ;
    return newHouse ;
}
module.exports = User;

function User(socket) {
    console.log ("^^^^^^3") ;



    //===============Login===============
    socket.on(func.UserLogin, function (data) {
        UserLogin(socket, data);
    });
    console.log ("^^^^^^4") ;
    //===============Guest_login===============
    socket.on(func.GuestLogin, function (data) {
        GuestLogin(socket, data);
    });
    //===============Facebook_login===============
    
    
    socket.on(func.LoadItemAvatarEquiped, function (data) {
        LoadItemAvatarEquiped(socket, data);
    });

    socket.on (func.UpdateItemEquipdedHair , function (data){
   
        UpdateItemEquipdedHair (socket , data) ;
    });

    socket.on (func.UpdateItemEquipdedFace , function (data){
       
        UpdateItemEquipdedFace (socket , data) ;
    });

    socket.on (func.LoadListDaruma , function (data){
      
        LoadListDaruma (socket , data) ;
    });


    socket.on (func.LoadListHouse , function (data){
      
        LoadListHouse (socket , data) ;
    });

    socket.on (func.LoadHouseBought , function (data){
        LoadHouseBought (socket , data) ;
    })

    socket.on (func.LoadHouseInMap , function (data){
        LoadHouseInMaps (socket,data) ;
    })
    
    socket.on (func.UpdataSprBuildingInMap , function (data){
        UpdataSprBuildingInMaps (socket , data) ;
    })

    socket.on (func.DeleteBuildingInMap , function (data){
        DeleteBuildingInMaps (socket , data) ;
    })

    socket.on (func.AddHouseBought , function (data){
        AddHouseItemBought (socket, data) ;
    })
    
}



function DeleteSocket(socket) {
    socket.removeAllListeners();
    SocketMN.deleteSocket(socket.uID);

    User(socket);
}




function OnLogin(socket, user) {
    console.log(user.userName);
    
    socket.removeAllListeners();
    User(socket);
    socket.uID = user.uID;
    SocketMN.addSocket(socket);

    ModelUserMN.SetUserModel(user);
    ModelUserMN.UpdateSocketID(user.uID, socket.id);
    ModelUserMN.UpdateGold(user.uID, 0);
    ModelUserMN.UpdateGem(user.uID, 0);

    //handleservercrashnode

    
}






function UserLogin(socket, data) {
    users.findOne({ userName: data.userInput }, function (err, user) {
        if (err) {
            console.log("error : " + err);
            return
        }

        if (user) {
            if (bcrypt.compareSync(data.userPass, user.userPass)) {
                let sk = SocketMN.getSocket(user.uID)
                if (sk != null) {
                    sk.emit(func.UserLogOut);
                    Global.Notice(sk, 'You are loging in another device.');
                    DeleteSocket(sk);
                }

                socket.emit(func.LoginSucceed, user);

                OnLogin(socket, user);
            } else {
                Global.Notice(socket, 'Wrong user name or password.');
            }
        } else {
            Global.Notice(socket, 'The account does not exist. Please create an account.');
        }
    });
}

function GuestLogin(socket, data) {
    users.findOne({ userName: data.userName }, function (err, user) {
        console.log ("^^^^^^5") ;
        if (err) {
            console.log("error : " + err);
            return
        }
        if (user === null) {

            console.log ("Chua login ***") ;
            createGuest(socket, data);
        } else {
            console.log ("Da login ***") ;
            let sk = SocketMN.getSocket(user.uID);
            if (sk) {
                sk.emit(func.UserLogOut);
                Global.Notice(sk, 'You are loging in another device.');
                DeleteSocket(sk);
            }

                var id = shortId.generate();
                NewUser(id, data.userName);
                OnLogin(socket, user);
                socket.emit(func.LoginSucceed, user);
    
        }

    });
}

function createGuest(socket, data) {
    var uID = randomize('0', 7);
    users.findOne({ uID }, function (err, user) {
        if (!err) {
            if (!user) {
                console.log ("^^^^^^7") ;
                let newUser = NewUser(uID, data.userName);
                OnLogin(socket, newUser);
                socket.emit(func.LoginSucceed, newUser);
            } else createGuest(socket, data);
        } else console.log('err create guest', err)

    })
}


function LoadItemAvatarEquiped (socket , data) {

    avatarItems.findOne({ userName: data.userName }, function (err, item) {
        console.log ("load item") ;
        if (err) {
            console.log("error : " + err);
            return
        }
        if (item === null) {

            console.log ("no item") ;
            createGuest(socket, data);
        } else {
            console.log ("Has item") ;
            
            
                 User (socket) ;
                 socket.emit(func.LoadItemAvatarEquipedSucces, item);
    
        }

    });

  

}

function UpdateItemEquipdedHair (socket , data) {
    console.log ("Into updata avatar forst") ;    
    avatarItems.findOne ({userName : data.userName} ,  function (err , item) {
        console.log ("Into updata avatar") ;    
        if (err)
        {
            console.log ("Error : " + err );
            return ;
        }

        if (item == null)
        {
            NewAvatarItem (data.userName , data.HairItem , data.FaceItem ,data.BeardItem , data.SongItem , data.GlassItem , data.clothesItem) ;
            User (socket) ;
        }
        else 
        {
                item.HairItem = data.HairItem ;
               
                item.save () ;
                User (socket) ;
        }
    }) ;
}

function UpdateItemEquipdedFace (socket , data) {
    console.log ("Into updata avatar forst") ;    
    avatarItems.findOne ({userName : data.userName} ,  function (err , item) {
        console.log ("Into updata avatar") ;    
        if (err)
        {
            console.log ("Error : " + err );
            return ;
        }

        if (item == null)
        {
            NewAvatarItem (data.userName , data.HairItem , data.FaceItem ,data.BeardItem , data.SongItem , data.GlassItem , data.clothesItem) ;
            User (socket) ;
        }
        else 
        {
                
                item.FaceItem = data.FaceItem ;
                item.save () ;
                User (socket) ;
        }
    }) ;
}

function LoadListDaruma (socket , data) {
    
    
        darumaItems.find({ userName: data.userName },  function (err, mbs) {
            if (err) {
                console.log(err);
                return;
            }
           
            socket.emit(func.LoadListDaruma, { list: mbs });        
        } ) ;
   
}

function LoadHouseBought (socket , data) {
    houseItems.find ({userName  :data.userName } , function (err , mbs){
        if (err)
        {
            console.log (err) ;
            return ;
        }

        socket.emit (func.LoadHouseBought , {list : mbs}) ;

    })
}

function LoadHouseInMaps (socket , data) {
    houseItemInMaps.find ({userName  :data.userName } , function (err , mbs){
        if (err)
        {
            console.log (err) ;
            return ;
        }
        socket.emit (func.LoadHouseInMap , {list : mbs}) ;

    })
}

function UpdataSprBuildingInMaps (socket , data) {
    console.log ("into updatae house") ;
    houseItemInMaps.findOne ({idLandSlot : data.idLandSlot} ,  function (err , item) {
       
        if (err)
        {
            console.log ("Error : " + err );
            return ;
        }

        if (item == null)
        {
            NewBuildingInMap (data.userName , data.idLandSlot , data.spriteHouse) ;
            console.log ("add success") ;
        }
        else 
        {
               
                item.spriteHouse = data.spriteHouse ;
                item.save () ;
               console.log ("update succe3s") ;
        }
        
    }) ;
}

function DeleteBuildingInMaps (socket , data) {
    
    houseItemInMaps.findOne ({idLandSlot : data.idLandSlot} ,  function (err , item) {
       
        if (err)
        {
            console.log ("Error : " + err );
            return ;
        }

        
                
           database.deleteOne (houseItemInMaps , item) ;    
        
        
    }) ;
}


function AddHouseItemBought (socket , data) {
    console.log ("House Sprite " + data.houseSprite) ;
    houseItems.findOne ({houseSprite : data.houseSprite} ,  function (err , item) {
        console.log ("Into updata avatar") ;    
        if (err)
        {
            console.log ("Error : " + err );
            return ;
        }

        if (item == null)
        {
            NewHouseItem (data.userName , data.houseName , data.housePrice , data.houseSprite) ;
            
        }
       
    }) ;
}

resetUser();

function resetUser() {
    setTimeout(() => {
        users.find({}, function (err, Users) {
            if (!err) {
                if (Users) {
                    for (let user of Users) {
                        if (user.socketID) {
                            let socket = SocketMN.getSocket(user.uID);
                            if (!socket) {
                                user.socketID = null;
                                ModelUserMN.UpdateUser(user);
                            }
                        }

                    }
                }

            } else console.log(err)
        })
    }, 3000);
}
