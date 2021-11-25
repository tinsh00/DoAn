using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DInventory 
{
	//public float exp;
	//public float health;
	//public float coin;
	//public float level;
	////public float[] position;

	public List<ItemData> items = new List<ItemData>();
	public float coin;
	public float level;
	public float currentExp;

	public DInventory()
	{
		items = Inventory.instance.items;
		coin = Inventory.instance.coin;
		level = Inventory.instance.level;
		currentExp = Inventory.instance.currentExp;
		//this.level = stats.level;
		//this.exp = stats.currentExp;
		//this.health = stats.currentHealth;
		//this.coin = stats.coin;
		//position = new float[3];
		//position[0] = stats.transform.position.x;
		//position[1] = stats.transform.position.y;
		//position[2] = stats.transform.position.z;
	}
}

