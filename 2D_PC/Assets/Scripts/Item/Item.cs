using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string name = "New Item";
    public Sprite icon = null;
    public bool isDefauleItem = false;
    public float amountExp;
    public float amountCoin;
    public float amountHealth;
	public virtual void Use()
	{
		Player.instance.playerStatus.IncreaseHealth(amountHealth);
		Player.instance.playerStatus.IncreateCoin(amountCoin);
		Player.instance.playerStatus.IncreateExp(amountExp);
		Debug.Log("Using " + name +" + "+ amountHealth);

	}
}
[CreateAssetMenu(fileName = "New Item", menuName = "Data/Inventory/Item")]
public class Item: ScriptableObject
{
	public ItemData item = new ItemData();
	
}

