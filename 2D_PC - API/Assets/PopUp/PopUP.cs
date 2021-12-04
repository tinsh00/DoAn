using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUP : MonoBehaviour
{
    [SerializeField]
    Text txtContent;

    public void Show(string Content)
    {
        txtContent.text = Content;
        gameObject.SetActive(true);
    }


    public void BtnClose()
    {
        //SoundMN.soundClick();
        gameObject.SetActive(false);
    }

    public void BtnDestroy()
    {
        //SoundMN.soundClick();
        Destroy(gameObject);
    }

}
