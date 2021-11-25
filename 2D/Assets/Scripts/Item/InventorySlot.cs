using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public Image icon;
	public Button removeButton;
    ItemData item;
    public void AddItem(ItemData newItem)
	{
		item = newItem;
		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}
	public void ClearSlot()
	{
		item = null;
		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;

	}
	public void OnRemoveButton()
	{
		Inventory.instance.removeItem(item);
	}

	public void UseItem()
	{
		if (item != null)
		{
			item.Use();
			Inventory.instance.removeItem(item);
		}
	}
}
