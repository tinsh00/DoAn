using SocketIO;
using System;
using UnityEngine;

public class GameFunc : MonoBehaviour
{
    public static GameFunc instance;

    private void Awake()
    {
        instance = this;
    }

    string uID, sID = null;

    public string Version = "";

    // Use this for initialization
    void Start()
    {
        ClientSC.On(Function.connect, OnConnect);
        ClientSC.On(Function.disconnect, OnDisConnect);
        ClientSC.On(Function.reconnect, OnReconenct);
        ClientSC.On(Function.CheckVersion, OnCheckVersion);
        ClientSC.On(Function.Notice, OnNotice);
        ClientSC.On(Function.UserLogOut, OnLogOut);
    }

    private void OnLogOut(SocketIOEvent obj)
    {
        LoginSC.isLogout = true;
        SceneMN.LoadScene(Scene.Load);
    }

    private void OnNotice(SocketIOEvent obj)
    {
        
    }

    public void LogOut()
    {
        sID = null;

        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.DeleteKey("pwd");
        ClientSC.Submit(Function.UserLogOut);
        SceneMN.LoadScene(Scene.LoginScene);

        LoginSC.isLogout = true;
    }


    private void OnApplicationPause(bool pause)
    {
        if (pause)
            sID = ClientSC.mClient.mSocket.sid;
        else
        {
            Invoke("checkReconnect", 0.2f);
        }
    }


    private void OnCheckVersion(SocketIOEvent obj)
    {
        JSONObject data = new JSONObject();
        data.AddField(Schema.version, Version);
        data.AddField(Schema.OSVersion, SystemInfo.operatingSystem);
        ClientSC.Submit(Function.CheckVersion, data);
    }

    private void OnReconenct(SocketIOEvent obj)// when serv err, just go to homescene
    {
       

      
    }

    private void OnConnect(SocketIOEvent obj)
    {
       
    }

    void checkReconnect()
    {
       
    }

    public void OnUserReconnect()
    {
      
    }

    private void OnDisConnect(SocketIOEvent obj)
    {
       
    }
}
