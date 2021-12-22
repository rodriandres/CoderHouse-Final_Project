using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInvetoryItem
{
    string Name { get; }

    Sprite Image { get; }

    void OnPickUp();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInvetoryItem item)
    {
        Item = item;
    }
    public IInvetoryItem Item;
}

