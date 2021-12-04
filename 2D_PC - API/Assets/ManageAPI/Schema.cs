using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class extendClass
{
    public static void GetField(this JSONObject ob, ref int var, Schema s)
    {
        ob.GetField(ref var, s.ToString());
    }

    public static void GetField(this JSONObject ob, ref string var, Schema s)
    {
        ob.GetField(ref var, s.ToString());
    }

    public static string GetStrField(this JSONObject ob, Schema s)
    {
        JSONObject o = ob.GetField(s);
        if (o != null)
            return o.str;

        return null;
    }

    public static void GetField(this JSONObject ob, ref bool var, Schema s)
    {
        ob.GetField(ref var, s.ToString());
    }

    public static void GetField(this JSONObject ob, ref float var, Schema s)
    {
        ob.GetField(ref var, s.ToString());
    }

    public static JSONObject GetField(this JSONObject ob, Schema s)
    {
        return ob.GetField(s.ToString());
    }

    public static void GetField(this JSONObject ob, ref long var, Schema s)
    {
        float fval = 0;
        ob.GetField(ref fval, s.ToString());

        var = (long)fval;
    }

    public static void AddField(this JSONObject ob, Schema s, int var)
    {
        ob.AddField(s.ToString(), var);
    }

    public static void AddField(this JSONObject ob, Schema s, string var)
    {
        ob.AddField(s.ToString(), var);
    }

    public static void AddField(this JSONObject ob, Schema s, float var)
    {
        ob.AddField(s.ToString(), var);
    }

    public static void AddField(this JSONObject ob, Schema s, bool var)
    {
        ob.AddField(s.ToString(), var);
    }

    public static void AddField(this JSONObject ob, Schema s, JSONObject var)
    {
        ob.AddField(s.ToString(), var);
    }


    public static void SetField(this JSONObject ob, Schema s, float var)
    {
        ob.SetField(s.ToString(), var);
    }

    public static void SetField(this JSONObject ob, Schema s, JSONObject var)
    {
        ob.SetField(s.ToString(), var);
    }



    public static void RemoveField(this JSONObject ob, Schema s)
    {
        ob.RemoveField(s.ToString());
    }
}
public enum Schema
{
    uID,
    userName,
    userEmail,
    userPass,
    userChips,
    userEnergys,
    PlayerStatus,
    userAvatar,
    userPlaying,
    uAvatar,
    timeBet,
    currBet,
    status,
    value,
    code,
    message,
    chain_id,
    id,
    method,
    address,
    result,
    type,
    action,
    money,
    dateFrom,
    dateTo,
    years,
    months,
    days,
    hours,
    minutes,
    seconds,
    uName,
    Amount,
    ID,
    sName,
    sAvatar,
    Contents,
    milliseconds,
    version,
    OSVersion,
    HairItem,
    FaceItem,
    SongItem, 
    BeardItem ,
    clothesItem ,
    GlassItem ,
    darumaName ,
    darumaLevel , 
    darumaSprite ,
    list,
    spriteBG ,
    spriteName,
    houseName ,
    houseSprite ,
    housePrice ,
    idLandSlot,
    spriteHouse,
}

public enum Function
{
    
    
    connect,
    disconnect,
    reconnect,
    UserReconnect,
    UserLogOut,
    ExitGame,
   
    UserRegister,
    UserLogin,
    RegisterSucceed,
    
    LoginSucceed,
    UserChangePassword,
    UpdatedNewPassword,
    GuestLogin,
    UserForgetPassword,
    
    CheckVersion,
    
    Playing,
    UpdateUserName,
    LoadRegister,
    
    UpdateUserEnergy,
    UpdateUserChip,
 
    ChangePassword,
    LoadItemAvatarEquiped ,
    LoadItemAvatarEquipedSucces ,
    Notice ,
    UpdateItemEquipdedHair ,
    UpdateItemEquipdedFace ,
    LoadListDaruma ,
    LoadListHouse ,
    LoadHouseBought ,
    LoadHouseInMap ,
    UpdataSprBuildingInMap ,
    DeleteBuildingInMap ,
    AddHouseBought,
}
