using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public Weapons weapons;
    public int projectileDamage;

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
    // this will contain the collision code for enemies and the bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(7, 6);
        //this is temp code for destroying enemies health will have to be implemented.

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit! " + projectileDamage);
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.TakeDamage(projectileDamage);
        }

        Destroy(gameObject);

    }



}
