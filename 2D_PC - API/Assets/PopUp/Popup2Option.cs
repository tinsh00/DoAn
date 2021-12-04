using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup2Option : PopUpYesNo
{
    [SerializeField] Text txtOption1;
    [SerializeField] Text txtOption2;

    public void setTxtOption(string option1, string option2)
    {
        txtOption1.text = option1;
        txtOption2.text = option2;
    }
}
