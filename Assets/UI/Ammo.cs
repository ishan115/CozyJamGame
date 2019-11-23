using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int ammo;
    public int ammoTotal;

    public Image[] snowballs;
    public Sprite fullAmmo;
    public Sprite noAmmo;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo > ammoTotal)
        {
            ammo = ammoTotal;
        }

        for (int i = 0; i < snowballs.Length; i++)
        {
            if (i<ammo)
            {
                snowballs[i].sprite = fullAmmo;
            }
            else
            {
                snowballs[i].sprite = noAmmo;
            }
            if (i < ammoTotal)
            {
                snowballs[i].enabled = true;
            }
            else
            {
                snowballs[i].enabled = false;
            }
        }
    }
}
