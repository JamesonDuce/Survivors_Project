using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float attacktime;
    public float cooldowntime = 100;
    public Transform spawn;
    public GameObject bulletImage;
    public float attackspeed = 50f;
    public int direction = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //check if space bar is pressed and if it is then send projectile. Working on a cooldown in here
    void Update()
    {
        bulletdirection();
        if (Input.GetKeyDown("x") && cooldowntime > attacktime)
        {
            attacking();
        }

        cooldowntime += Time.deltaTime;
    }

    //currently commented out for testing purposes but when all is said and done would be the method used by the weaponcontrol script
    /* public void shoot()
     {

         if (Input.GetKeyDown("space") && cooldowntime > attacktime)
         {
             attacking();
         }

         cooldowntime += Time.deltaTime;
     }*/


    //code for shooting the bullet and sets direction based on the last button pressed. 
    public void attacking()
    {
        cooldowntime = 0;
        var bullet = Instantiate(bulletImage, spawn.position, spawn.rotation);
        if (direction == 1)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = spawn.up * attackspeed;

        }
        if (direction == 2)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = -spawn.right * attackspeed;

        }
        if (direction == 3)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = -spawn.up * attackspeed;

        }
        else if (direction == 4)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = spawn.right * attackspeed;
        }


    }
    //when pressing a key sets value of variable direction
    public void bulletdirection()
    {
        if (Input.GetKey("w")) { direction = 1; }
        if (Input.GetKey("a")) { direction = 2; }
        if (Input.GetKey("s")) { direction = 3; }
        if (Input.GetKey("d")) { direction = 4; }
    }


}





