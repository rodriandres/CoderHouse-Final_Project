using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedPlayer = 3f;
    [SerializeField] private Rigidbody rbPlayer;

    [SerializeField] private InventoryManager mgInventory;
    [SerializeField] private UIInventory uiInventory;

    private Inventory inventory;


    [SerializeField] private GameObject lightTarget;
    [SerializeField] private GameObject spawnPointLvl02;

    private void Awake()
    {
        /*
        ItemToCatch.SpawnItemToCatch(new Vector3(20,20), new Item { itemType = Item.ItemType.SpeedBoost, amount = 1 });
        ItemToCatch.SpawnItemToCatch(new Vector3(-20,20), new Item { itemType = Item.ItemType.Coin, amount = 0 });
        ItemToCatch.SpawnItemToCatch(new Vector3(0,-20), new Item { itemType = Item.ItemType.HealthCristal, amount = 2 });
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        mgInventory = GetComponent<InventoryManager>();

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementPlayer();

        if (Input.GetKeyUp(KeyCode.G))
        {
            UseItem();
        }
        

    }

    void MovementPlayer()
    {
        float horizontalaxis = Input.GetAxis("Horizontal");
        float verticalaxis = Input.GetAxis("Vertical");
        //transform.Translate(new Vector3(horizontalaxis, 0, verticalaxis) * speedPlayer * Time.deltaTime);
        rbPlayer.AddForce(new Vector3(horizontalaxis, 0, verticalaxis) * speedPlayer * Time.deltaTime, ForceMode.Impulse);
        

        //transform.position += transform.right * horizontalaxis * Time.deltaTime;
        //transform.position += transform.forward * verticalaxis * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            //Destroy(other.gameObject);
            GameObject point = other.gameObject;
            point.SetActive(false);
            mgInventory.AddInventoryOne(point);
            mgInventory.CountPoint(point);            
        }

        if (other.gameObject.CompareTag("PlayerItem"))
        {
            GameObject item = other.gameObject;
            item.SetActive(false);
            Item newItem = other.GetComponent<Item>();
            inventory.AddItem(newItem);
        }

        if (other.gameObject.CompareTag("FinalPortal"))
        {
            transform.position = spawnPointLvl02.transform.position;
        }
    }

    private void UseItem()
    {
        GameObject item = mgInventory.GetInventoryOne();
        item.SetActive(true);
            
    }
}
