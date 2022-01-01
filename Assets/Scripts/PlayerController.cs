using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedPlayer = 3f;
    [SerializeField] private Rigidbody rbPlayer;

    [SerializeField] private InventoryManager mgInventory;

    [SerializeField] private GameObject lightTarget;
    [SerializeField] private GameObject spawnPointLvl02;

    [SerializeField] private GameObject inventoryPanel;

    private PlayerLife mPlayerLife;

    public Inventory inventory;

    public HUD Hud;

    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        mgInventory = GetComponent<InventoryManager>();

        inventory.ItemUse += Inventory_ItemUse;
        mPlayerLife = Hud.transform.Find("LifesPanel").GetComponent<PlayerLife>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UsePower(0);
        }
    }

    private void Inventory_ItemUse(object sender, InventoryEventArgs e)
    {
        IInvetoryItem item = e.Item;

        // Do something

        item.OnUse();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MovementPlayer();

        /*
        if (Input.GetKeyUp(KeyCode.G))
        {
            UseItemOld();
        }
        */

        // Use the ItemPowers

    }

    void MovementPlayer()
    {
        float horizontalaxis = Input.GetAxis("Horizontal");
        float verticalaxis = Input.GetAxis("Vertical");
        rbPlayer.AddForce(new Vector3(horizontalaxis, 0, verticalaxis) * speedPlayer * Time.deltaTime, ForceMode.Impulse);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            
            GameObject point = other.gameObject;
            point.SetActive(false);
            mgInventory.AddInventoryOne(point);
            mgInventory.CountPoint(point);            
        }

        if (other.gameObject.CompareTag("FinalPortal"))
        {
            transform.position = spawnPointLvl02.transform.position;
        }

        if (other.gameObject.CompareTag("Item"))
        {
            TextMesh text = other.gameObject.transform.GetChild(0).GetComponent<TextMesh>();
            List<IInvetoryItem> listOfItems = inventory.GetItems();

            int powerAmount = int.Parse(text.text.Replace("x", ""));
            int pointCount = mgInventory.GetPointQuantity()[0];

            //Debug.Log(pointCount);
            //Debug.Log("cantidad de items con indice 0: " + listOfItems.Count);
            if (listOfItems.Count <= 0) //  it's by index of the list Items
            {
               IInvetoryItem item = other.GetComponent<IInvetoryItem>();
                Debug.Log("count before: " + listOfItems.Count);
                if (listOfItems.Count == 0)
                {
                    if (powerAmount <= pointCount) // Ask if has the money to buy the item/power
                    {
                        if (item != null)
                        {
                            inventory.AddItem(item);
                            Debug.Log("count after: " + listOfItems.Count);

                            mgInventory.RemoveInventoryOne(powerAmount);
                            Debug.Log("left coins: " + mgInventory.GetPointQuantity()[0]);
                        }
                    }
                    else
                    {
                        Debug.Log("No Tienes suficiente dinero");
                    }
                }    
                else if (!listOfItems.Any(x => x.Image.name == item.Image.name))
                {
                    if (powerAmount <= pointCount) // Ask if has the money to buy the item/power
                    {
                        if (item != null)
                        {
                            inventory.AddItem(item);
                            Debug.Log("count after: " + listOfItems.Count);

                            mgInventory.RemoveInventoryOne(powerAmount);
                            Debug.Log("left coins: " + mgInventory.GetPointQuantity()[0]);
                        }
                    }
                    else
                    {
                        Debug.Log("No Tienes suficiente dinero");
                    }
                }
            }   
            else
            {
                Debug.Log("Tu inventario esta lleno");
            }
        }
    }
    private void UsePower(int indice)
    {
        List<IInvetoryItem> listOfInventoryItems = inventory.GetItems();
        Debug.Log("index Lista de items: " + listOfInventoryItems.Count);
        if (listOfInventoryItems.Count > 0)
        {
            Transform inventoryPanelTransform = inventoryPanel.transform;
            
            foreach (Transform slot in inventoryPanelTransform)
            {
                // Boder... Image
                Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
                if (listOfInventoryItems.ElementAtOrDefault(indice) != null)
                {
                    IInvetoryItem item = listOfInventoryItems[indice];
                    if (image.sprite.name == item.Image.name)
                    {
                        // Set slot
                        
                        image.enabled = false;
                        image.sprite = null;
                        inventory.UseItem(item);
                        inventory.RemoveItem(item);
                        Debug.Log("cantidad de items: " + listOfInventoryItems.Count);
                        break;
                    }
                }
                else
                {
                    Debug.Log("No tienes un item en ese slot");
                }
                
            }
        }
    }
    
    public void TakeDamage(int dmg)
    {
        Health -= dmg;
        if (Health < 0)
        {
            Health = 0;
            mPlayerLife.TakeDamage(dmg);
        }
    }

    public void IncreaseSpeed(int newSpeed, float coolDown)
    {
        float oldSpeed = speedPlayer;
        speedPlayer += newSpeed;
        StartCoroutine(speedBoostDuration(coolDown, newSpeed));
    }

    // Coroutines

    IEnumerator speedBoostDuration(float coolDown, float oldSpeed)
    {
        yield return new WaitForSeconds(coolDown);
        speedPlayer -= oldSpeed;
    }
}
