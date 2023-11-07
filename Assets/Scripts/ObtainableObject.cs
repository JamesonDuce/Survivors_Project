using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ObtainableObject : MonoBehaviour
{
    public int value = 10;
    public string type = "Experience";
    Character charControl;

    private bool shouldMove = false;
    Vector3 diff;
    // Start is called before the first frame update
    void Start()
    {
        charControl = GameObject.FindWithTag("Player").GetComponent<Character>();
    }
    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            gameObject.transform.Translate(-diff * 5 * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            Vector3 pos = collision.transform.position;
            diff = gameObject.transform.position - pos;

            shouldMove = true;
        }
        else
        {
            shouldMove = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyPickup"))
        {
            if (type == "Experience")
            {
                charControl.AddExp(value);
            }
            else if (type == "Gold")
            {
                charControl.AddGold(value);
            }

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Player"))
        {
            Character charControl = collision.gameObject.GetComponent<Character>();
            if(type == "Experience")
            {
                charControl.AddExp(value);
            }
            else if(type == "Gold")
            {
                charControl.AddGold(value);
            }

            Destroy(gameObject);
        }
        */
    }
}
