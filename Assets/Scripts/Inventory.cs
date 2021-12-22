using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    private List<Item> itemsList;

    // INVENTORY OF ITEMS

    public Inventory()
    {
        itemsList = new List<Item>();
        
        
        AddItem(new Item{ itemType = Item.ItemType.SpeedBoost, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Coin, amount = 0 });
        AddItem(new Item { itemType = Item.ItemType.HealthCristal, amount = 2 });
        
        // otro item para probar el hud:
        // AddItem(new Item { itemType = Item.ItemType.Force, amount = 5 });

    }

    public void AddItem(Item item)
    {
        itemsList.Add(item);
    }

    public List<Item> GetItemsList()
    {
        return itemsList;
    }


}
