using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using TMPro;
using System;
using UnityEngine.SceneManagement;



public class ClientSC : MonoBehaviour {

    public static ClientSC mClient;
	public static bool IsConnected;						   
    public SocketIOComponent mSocket;

    void Awake()
    {
        if (mClient == null)
        {
            mClient = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            DestroyImmediate(gameObject);

    }

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
     
    }

    

    public static void Submit(Function func, JSONObject json = null)
    {
        if (!mClient.mSocket) return;

        if (json != null)
            mClient.mSocket.Emit(func.ToString(), json);
        else if (json == null)
        {
            mClient.mSocket.Emit(func.ToString());
        }
    }

    public static void On(Function func, Action<SocketIOEvent> callback)
    {
        if (mClient.mSocket)
            mClient.mSocket.On(func.ToString(), callback);
    }

    public static void Off(Function func, Action<SocketIOEvent> callback)
    {
        if(mClient.mSocket)
            mClient.mSocket.Off(func.ToString(), callback);
    }    

    
}