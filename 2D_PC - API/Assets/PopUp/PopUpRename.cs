using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class PopUpRename : PopUP
{
   
    Text txtname;

    [SerializeField]
    InputField InputField;
    public void showPopUp (Text _txtName)
    {
        txtname = _txtName;
        InputField.text = txtname.text;
    }
    public void btnConfirm ()
    {
        txtname.text = InputField.text;
        Destroy(gameObject);
    }
}
