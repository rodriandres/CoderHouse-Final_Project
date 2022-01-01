using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleOfForce : MonoBehaviour, IInvetoryItem
{
    public Sprite _image = null;
    public GameObject _amountText = null;
    public int _amount = 0;

    public string Name
    {
        get
        {
            return "CapsuleOfForce";
        }
    }

    public Sprite Image
    {
        get
        {
            return _image;
        }
    }

    public GameObject AmountText
    {
        get
        {
            return _amountText;
        }
    }

    public int Amount
    {
        get
        {
            return _amount;
        }
    }

    public void OnDrop()
    {
        throw new System.NotImplementedException();
    }

    public void OnPickUp()
    {
        // Add logic what happends to player when throw this power
        gameObject.SetActive(false);
        AmountText.SetActive(false);

    }

    public void OnUse()
    {
        Debug.Log("May the force be with you");
        //PlayerLife lifes = transform.Find("LifesPanel").GetComponent<PlayerLife>();
        //PlayerController player = transform.Find("PLAYER").GetComponent<PlayerController>();

        //player.Health += 1;
        //lifes.HealLife(1);

    }
}
