using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Data/Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefauleItem = false;
    public float amountExp;
    public float amountCoin;

    public virtual void Use()
	{
        //Use the Item
        //Something might happen

        Debug.Log("Using " + name);
        
	}
}
