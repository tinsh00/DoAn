using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    
    //public Transform itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;

    public InventorySlot[] slots;
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        inventory= Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        //slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (Player.instance.InputHandler.InventoryInput && inventoryUI.activeSelf==false && !isOpen)
		{
			inventoryUI.SetActive(true);
            isOpen = true;
		}

		if (!Player.instance.InputHandler.InventoryInput && inventoryUI.activeSelf == true && isOpen)
		{
            inventoryUI.SetActive(false);
            isOpen = false;
        }
  //      else if(Player.instance.InputHandler.InventoryInput && inventoryUI.activeSelf==true)
		//{
  //          inventoryUI.SetActive(false);
  //          isOpen = false;
  //      }            
	}

    void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
                slots[i].AddItem(inventory.items[i]);
			}
			else
			{
                slots[i].ClearSlot();
			}
		}
	}
}
