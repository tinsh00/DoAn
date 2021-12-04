using System;
using UnityEngine;
public class PopUpMN : MonoBehaviour
{
    static PopUpMN instance;

    [SerializeField]
    PopUP noticePopUp;

    [SerializeField]
    PopUpYesNo prePopUpYesNo;

    [SerializeField]
    GameObject loadingPoPuP;

    [SerializeField] Popup2Option prePopup2Option;

    private void Awake()
    {
        instance = this;
    }

    public static void ShowNotice(string mes)
    {
        instance.noticePopUp.Show(mes);
    }


    public static void ShowYesNo(string mes, Action<bool> callBack)
    {
        PopUpYesNo popup = Instantiate(instance.prePopUpYesNo, instance.transform);
        popup.Show(mes, callBack);
    }

    public static void Show2Option (string mes ,Action <bool> callBack, string option1 , string option2)
    {
        Popup2Option popup = Instantiate(instance.prePopup2Option, instance.transform);
        popup.Show(mes, callBack);
        popup.setTxtOption(option1, option2);

    }

    public static void ShowLoading(bool show)
    {
        instance.loadingPoPuP.SetActive(show); 
    }
}
