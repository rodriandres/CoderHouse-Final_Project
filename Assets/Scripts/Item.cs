using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        SpeedBoost,
        HealthCristal,
        Force,
        TransparencyCape,
        Coin
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Coin:             return ItemsAssets.Instance.CoinSprite;
            case ItemType.HealthCristal:    return ItemsAssets.Instance.HealthCristalSprite;
            case ItemType.SpeedBoost:       return ItemsAssets.Instance.SpeedBoostSprite;
            case ItemType.Force:            return ItemsAssets.Instance.ForceSprite;
            case ItemType.TransparencyCape: return ItemsAssets.Instance.TransparencyCapeSprite;
        }
    }
}
