using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{




    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
	public List<Item> items = new List<Item>();
    public int space = 20;
    public float maxExp = Player.instance.playerStatus.maxExp;
    public float coin { get; private set; }
    public float level { get; private set; }
    public float currentExp { get; private set; }
	//public void addToInventory(Item item)
	//{
	//    Debug.Log("picked" + item.name);
	//    addItem(item);

	//}

	

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
    
    public bool addItem(Item item)
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
    public void removeItem(Item item)
    {
        Debug.Log("Coount " + items.Count);
        Debug.Log("Name" + item.name);
        items.Remove(item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
