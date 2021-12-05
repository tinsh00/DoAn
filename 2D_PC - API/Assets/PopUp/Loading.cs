using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField]
    Scene nextScene;
    [SerializeField]
    float loadingTime, checkNetWorkTime;
    //[SerializeField]
    //Canvas OpenCanvas;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;

        Image image = GetComponent<Image>();

        float currTime = 0;

        while(Time.time < checkNetWorkTime)
        {
            image.fillAmount = Time.time / loadingTime;
            yield return null;
        }

        currTime = Time.time;

        //working check network

        //
        while(currTime < loadingTime)
        {
            currTime += Time.deltaTime;
            image.fillAmount = currTime / loadingTime;
            yield return null;
        }

        SceneMN.LoadScene(nextScene);
        //if(OpenCanvas)
        // OpenCanvas.gameObject.SetActive(true);
    }

}
