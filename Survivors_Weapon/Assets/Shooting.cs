 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float attacktime;
  public float cooldowntime =100;
    public Transform spawn;
    public GameObject bulletImage;
    public float attackspeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //check if space bar is pressed and if it is then send projectile. Working on a cooldown in here
    void Update()
    {
        if (Input.GetKeyDown("space") && cooldowntime > attacktime)
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
   

    //code for shooting the bullet 
    public void attacking()
    {

        cooldowntime = 0;
        var bullet = Instantiate(bulletImage, spawn.position, spawn.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = spawn.up * attackspeed;

    }

}


