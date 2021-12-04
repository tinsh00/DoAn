using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGAppear : MonoBehaviour
{
    Image imgBG;
    Color color;
    private void Awake()
    {
        imgBG = GetComponent<Image>();
        color = imgBG.color;
        color.a = 0.1f;
        imgBG.color = color;

        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        yield return null;

        while(color.a < 1)
        {
            color.a += 0.02f;
            imgBG.color = color;
            yield return null;
        }
    }


}
