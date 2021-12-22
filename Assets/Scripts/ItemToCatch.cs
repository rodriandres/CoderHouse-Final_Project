using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToCatch : MonoBehaviour
{

    public static ItemToCatch SpawnItemToCatch(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemsAssets.Instance.pfItemToCatch, position, Quaternion.identity);

        ItemToCatch itemToCatch = transform.GetComponent<ItemToCatch>();
        itemToCatch.SetItem(item);

        return itemToCatch;
    }

    public Item item;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }
}
