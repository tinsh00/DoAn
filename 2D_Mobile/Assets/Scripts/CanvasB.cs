using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CanvasMovement.instance.gameObject.SetActive(false);
        Player.instance.playerStatus.ResetHealth();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
