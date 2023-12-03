using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rotate;
    public float speed =  5f;
    public int projectileDamage;
    Vector3 startingPos;

    private void Start()
    {
        startingPos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.TakeDamage(projectileDamage);
        }

    }
    void FixedUpdate()
    {
        //transform.RotateAround(rotate.transform.position, Vector3.forward, speed * Time.deltaTime);
        rotate.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        transform.localPosition = startingPos;
    }
}
