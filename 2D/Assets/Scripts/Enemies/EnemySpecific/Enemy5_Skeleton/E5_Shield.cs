using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_Shield : MonoBehaviour
{
    string shieldHitClip = "shieldHit";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        AudioManager.instance.PlaySound(shieldHitClip);
        if (collision.gameObject.name=="ArrowPlayer")
        { 
            Destroy(collision.gameObject);
		}
	}
}
