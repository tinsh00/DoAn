using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebClientApi : MonoBehaviour
{
    public static void OpenLoginPage()
    {
        string serverLinkLogin = "https://app-qc.darumawallet.com/embed/darumaLand/link/{0}/{1}/";

        string fullLink = string.Format(serverLinkLogin, SystemInfo.deviceUniqueIdentifier, SystemInfo.deviceUniqueIdentifier);
        Application.OpenURL(fullLink);
    }

    public static void InitWS(Action<bool> callBack)
    {
        WebClient.instance.ConnectedToServer(callBack);
    }


//    {
//  "id": 8466032601,
//  "method": "Link.GetAccount",
//  "params": [
//    {
//      "chain_id": 97
//    }
//  ]
//}
    public static void GetAccount(Action<string> callBack)
    {
        JSONObject data = new JSONObject();
        JSONObject list = new JSONObject();
        JSONObject item = new JSONObject();

        item.AddField(Schema.chain_id, 97);

        list.Add(item);

        data.AddField(Schema.id, "123456");
        data.AddField(Schema.method, "Link.GetAccount");
        data.AddField("params", list);

        WebClient.SendMessage(data.ToString(), callBack);
    }
}
