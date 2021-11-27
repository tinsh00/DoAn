using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DPlayer 
{
	public List<ItemData> items = new List<ItemData>();
	public float coin;
	public float level;
	public float currentExp;
	public int missionSuccess;

	public DPlayer()
	{
		items = Inventory.instance.items;
		coin = Player.instance.playerStatus.coin;
		level = Player.instance.playerStatus.level;
		currentExp = Player.instance.playerStatus.currentExp;
		missionSuccess = Player.instance.questSuccess;
		//position = new float[3];
		//position[0] = stats.transform.position.x;
		//position[1] = stats.transform.position.y;
		//position[2] = stats.transform.position.z;
	}
}

