using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 1;

    private List<IInvetoryItem> mItems = new List<IInvetoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public event EventHandler<InventoryEventArgs> ItemUse;

    public void AddItem(IInvetoryItem item)
    {
        if (mItems.Count <= SLOTS)
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
        else
        {
            Debug.Log("No tienes mas espacio en el inventario");
        }
    }

    internal void UseItem(IInvetoryItem item)
    {
        item.OnUse();
        if (ItemUse != null)
        {
            ItemUse(this, new InventoryEventArgs(item));
        }
    }

    public List<IInvetoryItem> GetItems()
    {
        return mItems;
    }

    public void RemoveItem(IInvetoryItem item)
    {
        if (mItems.Contains(item))
        {
            mItems.Remove(item);

            //item.OnDrop();

            if (ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item)) ;
            }

            // keep going, this function is incomplete
        }
    }

}
