using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{

	private void OnTriggerExit2D(Collider2D collision)
	{
		
			if (collision.gameObject.tag == "Player")
			{
				
				PlayerStatus status = collision.gameObject.GetComponentInChildren<PlayerStatus>();
				status.SaveDPlayer();
				Debug.Log("save " + transform.position);
				
			}

		
	}
}
