using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;



	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if(collision.gameObject.tag == "Player")
		{
			if (item.isDefauleItem)
			{
				PlayerStatus status = collision.gameObject.GetComponentInChildren<PlayerStatus>();
				status.IncreateExp(item.amountExp);
				status.IncreateCoin(item.amountCoin);
				Destroy(gameObject);
			}
			else
				PickUp(); 

		}
		
		
	}
	
	void PickUp()
	{
		Debug.Log("Picking up "+item.name);

		bool wasPickup = Inventory.instance.addItem(item);
		if (wasPickup)
			Destroy(gameObject);
	}
}
