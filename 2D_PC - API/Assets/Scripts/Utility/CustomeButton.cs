using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomeButton : MonoBehaviour
{

    private void Awake()
    {
        Image img = GetComponent<Image>();
        img.alphaHitTestMinimumThreshold = 0.2f;
    }

}
