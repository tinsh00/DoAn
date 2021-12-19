using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Player.instance.playerStatus.ResetHealth();
        CanvasMovement.instance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
