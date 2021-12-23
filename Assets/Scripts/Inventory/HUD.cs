using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;
    // Start is called before the first frame update
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("inventoryPanel");
        foreach (Transform slot in inventoryPanel)
        {
            // Boder... Image
            Debug.Log("2");
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            Debug.Log("3");
            // We found the empty slot
            if (!image.enabled)
            {
                Debug.Log("image enabled");
                image.enabled = true;
                image.sprite = e.Item.Image;

                // POSIBLE TODO HERE: Store reference to the item

                break;
            }
        }
    }
}
