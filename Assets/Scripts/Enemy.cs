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
}
