using NativeWebSocket;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WebClient : MonoBehaviour
{

    public static WebClient instance;

    static bool isOpen = false;

    static Action<string> callBack;

    static WebSocket websocket;

    static string serverLink = "https://app-qc.darumawallet.com/api/wallet";

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void  ConnectedToServer(Action<bool> callBack)
    {
        string api = "/v1/personal/link/init/ws/?";
        string link = serverLink + api + "device_uid=" + SystemInfo.deviceUniqueIdentifier + "&token=" + SystemInfo.deviceUniqueIdentifier;
        //string link = "ws://localhost:8080";
        Dictionary<string, string> header = new Dictionary<string, string>();
        header.Add("Origin", "com.Ebiz.DarumaLand");
        websocket = new WebSocket(link, header);

        websocket.OnOpen += () =>
        {
            isOpen = true;

            Debug.Log("onOpen");

            callBack(isOpen);
        };

        websocket.OnError += (e) =>
        {
            isOpen = false;
            Debug.Log("Error! " + e);

            callBack(isOpen);
        };

        websocket.OnClose += (e) =>
        {
            isOpen = false;

            Debug.Log("onClose");
        };

        websocket.OnMessage += OnMessage;

        // waiting for messages
        Connect();

    }

    public static void SendMessage(string mess, Action<string> callBack)
    {
        if (instance)
        {
            websocket.SendText(mess);
            WebClient.callBack = callBack;
        }
    }

    private void OnMessage(byte[] bytes)
    {
        Debug.Log("OnMessage");
        // getting the message as a string
        var message = System.Text.Encoding.UTF8.GetString(bytes);
        
        if(callBack != null)
        {
            callBack(message);
        }

        callBack = null;
    }

    void Update()
    {
        if (websocket == null) return;

#if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();
#endif
    }

    async void Connect()
    {
        await websocket.Connect();
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }

    private async void OnApplicationQuit()
    {
        if (websocket == null) return;
        await websocket.Close();
    }

}