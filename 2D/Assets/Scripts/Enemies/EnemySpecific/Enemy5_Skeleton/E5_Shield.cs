using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_Shield : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name=="ArrowPlayer"|| collision.gameObject.name == "Arrow")

        {
            Destroy(collision.gameObject);
		}
	}
}
