using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
	private void Awake()
	{
		if(instance != null)
		{
            Debug.LogWarning("More than one instance of Inventory found");
            return;
		}

        instance = this;
	}


    #endregion


    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
	public List<Item> items = new List<Item>();
    public int space = 20;
    //public void addToInventory(Item item)
    //{
    //    Debug.Log("picked" + item.name);
    //    addItem(item);

    //}
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
        items.Remove(item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
