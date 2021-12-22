using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 3;

    private List<IInvetoryItem> mItems = new List<IInvetoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemUse;

    public void AddItem(IInvetoryItem item)
    {
        if (mItems.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;

                mItems.Add(item);

                item.OnPickUp();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    internal void UseItem(IInvetoryItem item)
    {
        if (ItemUse != null)
        {
            ItemUse(this, new InventoryEventArgs(item));
        }
    }

    public void RemoveItem(IInvetoryItem item)
    {
        if (mItems.Contains(item))
        {
            mItems.Remove(item);

            // keep going, this function is incomplete
        }
    }

}
