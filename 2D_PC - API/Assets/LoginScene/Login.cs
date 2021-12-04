using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{
    bool isLogin = false;

    //[SerializeField] GameObject preSetting;
    private void OnApplicationFocus(bool focus)
    {
        if (focus && isLogin)        
        {
            isLogin = false;
            InitWebSocket();
        }
    }

    public void BtnPlay()
    {
        //SoundMN.soundClick();
        PopUpMN.ShowLoading(true);
        StartAPI();
    }

    private void StartAPI()
    {
        isLogin = true;
        WebClientApi.OpenLoginPage();
    }
    

    void InitWebSocket()
    {
        WebClientApi.InitWS(OnInitWebSocket);        
    }

    private void OnInitWebSocket(bool success)
    {
        if (success)
        {
            WebClientApi.GetAccount(OnGetAccount);
        }
        else
        {
            PopUpMN.ShowLoading(false);
            PopUpMN.ShowNotice("Login fail. Please login again later");
        }
    }

    //{"id":"123456","result":{"chain_id":97,"network":"BNB:TESTNET","address":"0x8b522f2089a3ebf00473439692aa0bec3434223a"},"error":null}

    private void OnGetAccount(string obj)
    {
        JSONObject data = JSONObject.Create(obj).GetField(Schema.result);
        string address = data.GetStrField(Schema.address);

        LoginByAddress(address);
    }

    private void LoginByAddress(string address)
    {
        //working
        print("address " + address);

        PopUpMN.ShowLoading(false);
        SceneMN.LoadScene(Scene.Menu);
    }

    public void BtnGuest()
    {
        //SoundMN.soundClick();
       
        LoginSC.instance.GuestLogin();
    }

    public void BtnSetting ()
    {
        //SoundMN.soundClick();
       // preSetting.SetActive(true);
    }
}
