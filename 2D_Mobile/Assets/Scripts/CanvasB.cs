using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.instance.playerStatus.ResetHealth();
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
        CanvasMovement.instance.gameObject.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
