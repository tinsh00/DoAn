using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SocketIO;

public class LoginSC : MonoBehaviour
{


    public static LoginSC instance;
    private string usernameReg, emailReg, pwdReg, userInputLogin, pwdLogin,  emailForget, verifyCode, newInputPwd1, newInputPwd2;


    public static bool isLogout = false;

    void Awake()
    {
        instance = this;
        ClientSC.On(Function.LoginSucceed, LoginSucceed);
    }



    public void LoginSucceed(SocketIOEvent skEvent)
    {
       
        UserData.instance.SetUserData(skEvent);
        Player.instance.LoadData(skEvent);
        SceneMN.LoadScene(Scene.Menu);



    }
    public void GuestLogin()
    {
       
        string deviceid = SystemInfo.deviceUniqueIdentifier;
        string guestID = "guest0" + deviceid.Substring(0, 5);
        JSONObject data = new JSONObject();
        data.AddField(Schema.userName, guestID);
        ClientSC.Submit(Function.GuestLogin, data);
    }

    

}
