using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float walkSpeed = 300f;
    bool sensePlayer = false;
    bool faceRight = true;
    public int health;//Name subject to change
    public int attack;//Name subject to change
    Animator anim;

    public GameObject[] dropItems;
    public float[] dropRate;

    public float delayAttack = 2f;
    private float lastAttack = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Time.realtimeSinceStartup >= lastAttack + delayAttack) // If it is time to attack
            {
                collision.gameObject.GetComponent<Character>().DamageCharacter(attack); // Attack the player
                lastAttack = Time.realtimeSinceStartup; // Update the last time the enemy has attacked.
            }
        }
        //this is temp code for destroying enemies health will have to be implemented.
        //Destroy(gameObject)

    }
    //Called every fixed framerate frame, if MonoBehaviour is enabled
    public void FixedUpdate()
    {
        float speed = walkSpeed;
        //sensePlayer can must only be activated if player gets within the "Circle Collider 2D" range
        if (sensePlayer == false)
        {
            rb.velocity = new Vector2(-1 * walkSpeed * Time.deltaTime, rb.velocity.y);
            if(faceRight == true)
            {
                rb.transform.Rotate(0f, 180f, 0, Space.Self);
                faceRight = false;
            }
        }
        //Insert code for tracking player & matching movement direction with face here
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        for(int i = 0; i < dropItems.Length; i++) // Go through the drop table to determine if an enemy should drop items.
        {
            float randNum = Random.Range(0f, 1f); // Generate a random number from 0 to 1 
            if(randNum <= dropRate[i]) // If the item should drop 
            {
                // Generate a random position around the radius of the killed enemy

                float randX = transform.position.x + Random.Range(0f, 1f);
                float randY = transform.position.y + Random.Range(0f, 1f);

                Vector3 spawnPos = new Vector3(randX, randY, -1);
                Quaternion zeroQ = new Quaternion(0f, 0f, 0f, 0f);

                Instantiate(dropItems[i], spawnPos, zeroQ); // Spawn the item  into the scene
            }
        }

        Destroy(gameObject); // Get rid of the enemy
    }
}
