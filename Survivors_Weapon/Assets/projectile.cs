using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public Weapons weapons;
   //this determines how far the projectile goes before going off the screen
    public void Awake()
    {
        Destroy(gameObject, 3);
        /*if (weapons.weaponID == 1)
        {
            Destroy(gameObject, 3);
        }
    else if (weapons.weaponID == 2{
        Destroy(gameObject, 10);
        
        }*/
    }
    // this will contain the collision code for enemies
    public void bulletCollide()
    {



    }


}
