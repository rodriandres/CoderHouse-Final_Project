using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour, IInvetoryItem
{
    public string Name
    {
        get
        {
            return "SpeedBoost";
        }
    }

    public Sprite _image = null;

    public Sprite Image 
    {
        get
        {
            return _image;
        }
    }

    public void OnPickUp()
    {
        // Add logic what happends to player when throw this power
        gameObject.SetActive(false);
    }

}
