using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public enum Currency
{
    Gold, 
    Energy,
    Zen,
    Level,
    Coin,
    CurrentExp
}
public class UserData : MonoBehaviour
{

    //user data
    public static string userName = "vanteo123" , password = "123456";

    public static string uID, userName1;

    public static int uLevel = 0, currentExp = 0, uCoin = 0, maxExp=100;

    public static int userLevel = 1, userExp = 0, nextLevelExp = 0;

    public static Action OnChangeExp;

    public static int userEnergy = 100, energyPerCollect = 2, WhiteTea = 0, GreenTea = 0, BlackTea = 0;

    static long userGold = 0, userZen = 1000;

    //public static List<ShopItem> ListHouse = new List<ShopItem>();

    

    //[SerializeField]  List<AvatarItemdata> listAvatarItemData = new List<AvatarItemdata>();

    //[SerializeField] List<ShopItemData> listBuildingItemData = new List<ShopItemData>();

    //[SerializeField] List<PeopleItemData> listAddFriendData = new List<PeopleItemData>();

    //[SerializeField] List<PeopleItemData> listFriendRequestData = new List<PeopleItemData>();

    //[SerializeField] List<PeopleItemData> listFriendData = new List<PeopleItemData>();

    //[SerializeField] List<DarumaItemData> listDarumaData = new List<DarumaItemData>();

    //[SerializeField] List<ShopItemData> listHouseShopData = new List<ShopItemData>();
    public static UserData instance;
    //=======

    private void Awake()
    {
        instance = this;

        
        //CaleculateNextLevel();

    }
    private void Start()
    {

        //ClientSC.On(Function.UpdateUserEnergy, OnUpdateUserEnergy);
        //ClientSC.On(Function.UpdateUserChip, OnUpdateUserGem);
        ClientSC.On(Function.UpdateUserCoin, OnUpdateCoin);
        ClientSC.On(Function.UpdateUserLevel, OnUpdateLevel);
        ClientSC.On(Function.UpdateUserCurrentExp, OnUpdateCurrentExp);
    }

    public void OnUpdateLevel(SocketIOEvent obj)
	{
        int value = 0;
        obj.data.GetField(ref value, Schema.value);
        SetBalance(Currency.Level, value);
	}
    public void OnUpdateCoin(SocketIOEvent obj)
	{
        int value = 0;
        obj.data.GetField(ref value, Schema.value);
        SetBalance(Currency.Coin, value);
	}
    public void OnUpdateCurrentExp(SocketIOEvent obj)
    {
        int value = 0;
        obj.data.GetField(ref value, Schema.value);
        SetBalance(Currency.CurrentExp, value);
    }
    private void OnUpdateUserGem(SocketIOEvent obj)
    {
        int value = 0;
        obj.data.GetField(ref value, Schema.value);
        SetBalance(Currency.Zen, value);
    }

    private void OnUpdateUserEnergy(SocketIOEvent obj)
    {
        int value = 0;
        obj.data.GetField(ref value, Schema.value);
        SetBalance(Currency.Energy, value);
    }

    //level
    static void CaleculateNextLevel()
    {
        nextLevelExp = userLevel * 150;
    }


    public static void UpdateExp(int exp)
    {
        userExp += exp;

        if (userExp > nextLevelExp)
        {
            userLevel++;
            userExp -= nextLevelExp;

            CaleculateNextLevel();

        }

        if (OnChangeExp != null)
            OnChangeExp();
    }


    //===========
    //user update balance


    static Action OnChangeGold, OnChangeZen, OnChangeEnergy, OnChangeQuantityItem, OnChangeLevel,OnChangeCoin,OnChangeCurrentExp;

    //

    internal static void RegisterObserItem(Action func)
    {
        OnChangeQuantityItem += func;
    }

    internal static void RemoveObserItem(Action func)
    {
        OnChangeQuantityItem -= func;
    }

    
    internal static int GetQuantity(Item item)
    {
        //switch (item)
        //{
        //    //case Item.WhiteTea:
        //    //    return WhiteTea;
        //    //case Item.GreenTea:
        //    //    return GreenTea;
        //    //case Item.BlackTea:
        //    //    return BlackTea;
        //}

        return 0;
    }

    internal static void UpdateQuantity(Item item, int value)
    {
        //switch (item)
        //{
        //    //case Item.WhiteTea:
        //    //    WhiteTea += value;
        //    //    break;
        //    //case Item.GreenTea:
        //    //    GreenTea += value;
        //    //    break;
        //    //case Item.BlackTea:
        //    //    BlackTea += value;
        //    //    break;
        //}

        if (OnChangeQuantityItem != null)
            OnChangeQuantityItem();
    }



    //
    public static void RegisterObserEnergy(Action func)
    {
        OnChangeEnergy += func;
    }
       

    public static void RemoveObserEnerGy(Action func)
    {
        OnChangeEnergy -= func;
    }

    public static void UpdateEnergy(int value)
    {
        userEnergy += value;

        if (OnChangeEnergy != null)
            OnChangeEnergy();
    }

    internal static bool CheckEnergy()
    {
        return userEnergy > energyPerCollect;
    }

    //

    public static void UpdateZen(int value)
    {
        userZen += value;

        if (OnChangeZen != null)
            OnChangeZen();
    }
    public static void UpdateCoin(int value)
    {
        uCoin += value;

        if (OnChangeCoin != null)
            OnChangeCoin();
    }
    public static void UpdateLevel(int value)
    {
        uLevel += value;

        if (OnChangeLevel != null)
            OnChangeLevel();
    }
    public static void UpdateCurrentExp(int value)
    {
        currentExp += value;
		if (currentExp >= maxExp)
		{
            UpdateLevel(1);
            currentExp -= maxExp;
        }
        if (OnChangeCurrentExp != null)
            OnChangeCurrentExp();
    }
    //
    static Action GetActionBalance(Currency type)
    {
        switch (type)
        {
            case Currency.Gold: return OnChangeGold;
            case Currency.Energy: return OnChangeEnergy;
            case Currency.Zen: return OnChangeZen;
            case Currency.Coin: return OnChangeCoin;
            case Currency.Level: return OnChangeLevel;
            case Currency.CurrentExp: return OnChangeCurrentExp;
        }
        return null;
    }
       

    public static void RegisterObserBalance(Currency type, Action func)
    {
        switch (type)
        {
            case Currency.Gold: OnChangeGold += func; break;
            case Currency.Energy: OnChangeEnergy += func; break;
            case Currency.Zen: OnChangeZen += func; break;
            case Currency.Coin: OnChangeCoin += func; break;
            case Currency.Level: OnChangeLevel += func; break;
            case Currency.CurrentExp: OnChangeCurrentExp += func; break;
        }

    }

    public static void RemoveObserBalance(Currency type, Action func)
    {
        switch (type)
        {
            case Currency.Gold: OnChangeGold -= func; break;
            case Currency.Energy: OnChangeEnergy -= func; break;
            case Currency.Zen: OnChangeZen -= func; break;
            case Currency.Level: OnChangeLevel -= func; break;
            case Currency.Coin: OnChangeCoin -= func; break;
            case Currency.CurrentExp: OnChangeCurrentExp -= func; break;
        }
    }

    static void CallActionBalance(Currency type)
    {
        Action action = GetActionBalance(type);
        action?.Invoke();
    }


    public static long GetBalance(Currency type)
    {
        switch (type)
        {
            case Currency.Gold: return  userGold;
            case Currency.Energy: return userEnergy;
            case Currency.Zen: return userZen;
            case Currency.Level:return uLevel;
            case Currency.Coin:return uCoin;
            case Currency.CurrentExp:return currentExp;
        }

        return 0;
    }

    public static void UpdateBalance(Currency type, int value)
    {
        switch (type)
        {
            case Currency.Gold:
                userGold += value;
                CallActionBalance(Currency.Gold);
                break;
            case Currency.Energy:
                userEnergy += value;
                CallActionBalance(Currency.Energy);
                break;
            case Currency.Zen:
                userZen += value;
                CallActionBalance(Currency.Zen);
                break;
            case Currency.Level:
                uLevel += value;
                CallActionBalance(Currency.Level);
                break;
            case Currency.Coin:
                uCoin += value;
                CallActionBalance(Currency.Coin);
                break;
            case Currency.CurrentExp:
                currentExp += value;
                CallActionBalance(Currency.CurrentExp);
                break;
        }

    }

    static void SetBalance(Currency type, int value)
    {
        switch (type)
        {
            case Currency.Gold:
                userGold = value;
                CallActionBalance(Currency.Gold);
                break;
            case Currency.Energy:
                userEnergy = value;
                CallActionBalance(Currency.Energy);
                break;
            case Currency.Zen:
                userZen = value;
                CallActionBalance(Currency.Zen);
                break;
            case Currency.Level:
                uLevel = value;
                CallActionBalance(Currency.Level);
                break;
            case Currency.Coin:
                uCoin = value;
                CallActionBalance(Currency.Coin);
                break;
            case Currency.CurrentExp:
                currentExp = value;
                CallActionBalance(Currency.CurrentExp);
                break;

        }
    }
    // 
    //public  List <ShopItemData> getListBuildingData ()
    //{
    //    return listBuildingItemData;
    //}
    //public List <DarumaItemData> getListDarumaData ()
    //{
    //    return listDarumaData;
    //}

    //public List <ShopItemData> getListHouseShop ()
    //{
    //    return listHouseShopData;
    //}
    //public List<AvatarItemdata> getListAvatarItemData ()
    //{
    //    return listAvatarItemData;
    //}

    //public List<PeopleItemData> getListFriendData ()
    //{
    //    return listFriendData;
    //}
    //public List<PeopleItemData> getListAddFriendData ()
    //{
    //    return listAddFriendData;
    //}
    //public List<PeopleItemData> getListRequestFriendData ()
    //{
    //    return listFriendRequestData;
    //}
    //public void addListBuilding (ShopItemData _data)
    //{
      
    //    bool checkDuplicate = false;
    //    foreach (ShopItemData data in listBuildingItemData)
    //    {
    //        if (data.spr == _data.spr)
    //        {
    //            checkDuplicate = true;
    //        }
    //    }

    //    if (!checkDuplicate)
    //    {
    //        listBuildingItemData.Add(_data);
    //    }     
    //}


    //public void acceptFriend(PeopleItemData data)
    //{
    //    listFriendRequestData.Remove(data);
    //    listFriendData.Add(data);
    //}

    //public void cancelFriend(PeopleItemData data)
    //{
    //    listFriendRequestData.Remove(data);
    //    listAddFriendData.Add(data);
    //}

    //public void unFriend(PeopleItemData data)
    //{
    //    listFriendData.Remove(data);
    //    listAddFriendData.Add(data);
    //}
    public static void LoadUserData()
    {
        //working
    }



    public void SetUserData(SocketIOEvent skEvent)
    {
        JSONObject data = skEvent.data;
        data.GetField(ref uID, Schema.uID);
        data.GetField(ref userName1, Schema.userName);
        data.GetField(ref uLevel, Schema.userLevel);
        data.GetField(ref uCoin, Schema.userCoin);
        data.GetField(ref currentExp, Schema.userCurrentExp);
        Debug.Log(data.ToString());
        SetBalanceData(data);
    }

    void SetBalanceData(JSONObject data)
    {
        int value = 0;
        //data.GetField(ref value, Schema.userEnergys);

        //Debug.Log("Energy : " + value);
        //SetBalance(Currency.Energy, value);

        //data.GetField(ref value, Schema.userChips);
        //Debug.Log("Chip : : " + value);
        //SetBalance(Currency.Zen, value);
        data.GetField(ref value, Schema.userCoin);
        Debug.Log("Coin : : " + value);
        SetBalance(Currency.Coin, value);
        data.GetField(ref value, Schema.userLevel);
        Debug.Log("Level : : " + value);
        SetBalance(Currency.Level, value);
        data.GetField(ref value, Schema.userCurrentExp);
        Debug.Log("Current Exp : : " + value);
        SetBalance(Currency.CurrentExp, value);



    }
}
