using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
	public List<ItemData> items = new List<ItemData>();
    private int space = 20;
    private float maxExp ;
    public float coin;
    public float level;
    public float currentExp;
	//public void addToInventory(Item item)
	//{
	//    Debug.Log("picked" + item.name);
	//    addItem(item);

	//}

	private void Start()
	{
        maxExp = Player.instance.playerStatus.maxExp;
 

    }

	public void ResetCoin()
	{
        coin = 0;
	}
    public void ResetLevel()
	{
        level = 0;
	}
    public void ResetCurrentExp()
	{
        currentExp = 0;
	}
    public void IncreaseCoin(float amount)
	{
        coin += amount;
	}
    public bool DecreaseCoin(float amount)
	{
		if (coin < amount)
		{
            return false;
		}
        else
          coin -= amount;
        return true;
        
	}
    public void IncreaseCurExp(float amount)
    {
        currentExp += amount;
		if (currentExp >= maxExp)
		{
            IncreaseLevel();
            currentExp -=maxExp;
		}

    }
    public bool DecreaseCurExp(float amount)
    {
        if (currentExp < amount)
        {
            return false;
        }
        else
            currentExp -= amount;
        return true;

    }
    public void IncreaseLevel()
	{
        level++;
	}
    
    public bool addItem(ItemData item)
    {
        if (!item.isDefauleItem)
		{
			if (items.Count >= space)
			{
                Debug.Log("Not enough room.");
                return false;
			}
            
            items.Add(item);
            if(onItemChangedCallBack!=null)
                onItemChangedCallBack.Invoke();

		}
        return true;
    }
    public void removeItem(ItemData item)
    {
        Debug.Log("Coount " + items.Count);
        Debug.Log("Name" + item.name);
        items.Remove(item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
