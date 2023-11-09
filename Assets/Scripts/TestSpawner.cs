using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestSpawner : MonoBehaviour
{
    public GameObject spawnItem;

    public float delay = 7.5f;
    private float delayReset;
    
    // Start is called before the first frame update
    void Start()
    {
        delayReset = delay;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime; // Update the time that has passed

        if(delay <= 0) // If it is time to spawn the object
        {
            delay = delayReset; // Reset the delay time

            float randY = Random.Range(-2.5f, 2f); // Generate a random Y coordinate for spawning the object for some 
            Vector3 spawnPos = new Vector3(transform.position.x - 1, transform.position.y + randY, -1); // Determine the spawn pos

            Instantiate(spawnItem, spawnPos, transform.rotation); // Create the object in the scene
        }
    }
}
