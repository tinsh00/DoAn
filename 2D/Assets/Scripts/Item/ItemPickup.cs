using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData item;

	[SerializeField]
	private string pickUpItem = "pickUpItem";

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if(collision.gameObject.tag == "Player")
		{
			AudioManager.instance.PlaySound(pickUpItem);
			if (item.isDefauleItem)
			{
				Player.instance.playerStatus.IncreateExp(item.amountExp);
				Player.instance.playerStatus.IncreateCoin(item.amountCoin);
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
