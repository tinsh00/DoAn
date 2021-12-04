using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpYesNo : PopUP
{
    Action<bool> callBack;
    public void Show(string mess, Action<bool> callBack)
    {
        this.callBack = callBack;

        Show(mess);
    }

    public void OnConfirm(bool isYes)
    {
        BtnDestroy();

        if (callBack != null)
            callBack(isYes);    
    }
}
