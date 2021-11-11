using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DPlayer : MonoBehaviour
{
	public float exp;
	public float health;
	public float coin;
	public float level;
	public float[] position;

	public DPlayer(PlayerStatus stats)
	{
		this.level = stats.level;
		this.exp = stats.currentExp;
		this.health = stats.currentHealth;
		this.coin = stats.coin;
		position = new float[3];
		position[0] = stats.transform.parent.parent.position.x;
		position[1] = stats.transform.parent.parent.position.y;
		position[2] = stats.transform.parent.parent.position.z;
	}
}
