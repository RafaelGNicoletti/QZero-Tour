using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private List<InventoryItem> inventory = new List<InventoryItem>();

    public void GiveItem(InventoryItem item)
    {
        inventory.Add(item);
    }

    public InventoryItem TakeFirstItem()
    {
        InventoryItem item = null;
        
        if (InventoryHaveItens())
        {
            item = inventory[0];
            RetireFirstItem();
        }

        return item;
    }

    public InventoryItem TakeItem(string itemName)
    {
        InventoryItem item = SearchItem(itemName);
        
        if (item)
        {
            RetireItem(itemName);
        }

        return item;
    }

    public void RetireFirstItem()
    {
        if (InventoryHaveItens())
        {
            inventory.RemoveAt(0);
        }
    }

    public void RetireItem(string itemName)
    {
        InventoryItem item = SearchItem(itemName);
        if(item)
        {
            inventory.Remove(item);
        }
    }

    public List<InventoryItem> GetAllItems()
    {
        return inventory;
    }

    public InventoryItem GetItemByIndex(int i)
    {
        if (inventory.Count>i)
        {
            return inventory[i];
        }

        return null;
    }

    public bool VerifyItemObtained(string itemName)
    {
        if (SearchItem(itemName))
        {
            return true;
        }
        
        return false;

    }

    private InventoryItem SearchItem(string itemName)
    {
        foreach (InventoryItem item in inventory)
        {
            if (itemName == item.GetNome())
            {
                return item;
            }
        }
        return null;
    }

    public bool InventoryHaveItens()
    {
        if (inventory.Count > 0)
        {
            return true;
        }

        return false;
    }
}
