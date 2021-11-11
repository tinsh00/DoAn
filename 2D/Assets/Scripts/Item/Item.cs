using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Data/Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefauleItem = false;
    public float amountExp;
    public float amountCoin;
    public float amountHealth;

    public virtual void Use()
	{
        //Use the Item
        //Something might happen
        GameObject[] player= GameObject.FindGameObjectsWithTag("Player");
		if (player[0])
		{
            PlayerStatus playerStatus = player[0].GetComponentInChildren<PlayerStatus>();
            playerStatus.IncreaseHealth(amountHealth);
            //playerStatus.coin
            playerStatus.IncreateCoin(amountCoin);
            playerStatus.IncreateExp(amountExp);

		}
        Debug.Log("Using " + name);
        
	}
}
