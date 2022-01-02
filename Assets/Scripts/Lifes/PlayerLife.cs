using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{
    [SerializeField] private GameObject heartsPanel;
    [SerializeField] private int lifes;
    [SerializeField] private bool dead;
    private void Start()
    {
        Transform lifePanel = transform.Find("LifesPanel");
        int max = lifePanel.childCount;
        for (int i = 0; i < max; i++)
        {
            lifePanel.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < lifes; i++)
        {
            lifePanel.GetChild(i).gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            Debug.Log("Your are Dead");
            // Set Dead Event
        }
    }
    public void TakeDamage(int dmg)
    {
        Transform lifePanel = transform.Find("LifesPanel");
        if (lifes >= 1 && !dead)
        {
            for (int i = 0; i < dmg; i++)
            {
                lifes -= 1;
                int max = lifePanel.childCount;
                lifePanel.GetChild(max).gameObject.SetActive(false);
            }
        }
        else
        {
            dead = true;
        }
    }
    public void HealLife(int healValue)
    {
        Transform lifePanel = transform.Find("LifesPanel");
        Debug.Log(lifePanel);
        if (lifes >= 1)
        {
            lifes += healValue;
            for (int i = 0; i < healValue; i++)
            {
                int max = lifePanel.childCount;
                int actives = 0;
                for (i = 0; i < max; i++)
                {
                    if (lifePanel.GetChild(i).gameObject.activeSelf)
                    {
                        actives += 1;
                    }
                }
                lifePanel.GetChild(actives).gameObject.SetActive(true);
            }
        }
    }
}
