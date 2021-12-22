using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsAssets : MonoBehaviour
{
    public static ItemsAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemToCatch;
 
    public Sprite CoinSprite;
    public Sprite SpeedBoostSprite;
    public Sprite HealthCristalSprite;
    public Sprite TransparencyCapeSprite;
    public Sprite ForceSprite;
}
