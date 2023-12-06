using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawner_Level_2 : MonoBehaviour
{
    public GameObject spawnItem;
    public UserInterface UI;

    public float delay = 3.5f;
    private float delayReset = 3.5f;
    private int spawnlimit = 0;
    private int wave = 1;
    public int wavecount = 1;
    // Start is called before the first frame update
    void Start()
    {
        delayReset = delay;
        
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime; // Update the time that has passed

        if (delay <= 0) // If it is time to spawn the object
        {
            delay = delayReset; // Reset the delay time

            float randY = Random.Range(-2.5f, 2f); // Generate a random Y coordinate for spawning the object for some 
            Vector3 spawnPos = new Vector3(transform.position.x - 1, transform.position.y + randY, -1); // Determine the spawn pos

            Instantiate(spawnItem, spawnPos, transform.rotation); // Create the object in the scene
            spawnlimit += 2;
            wavecheck();
        }




    }
    public void wavecheck()

    {
        if (spawnlimit >= 15 && wave == 1)
        {
            wavecount = 2;
            wave = 2;
            delay = 15f;
            


        }

        else if (spawnlimit >= 30 && wave == 2)
        {
            wavecount = 3;
            wave = 3;
            delay = 15f;
           

        }

        else if (spawnlimit >= 45 && wave == 3)
        {
            wave = 4;




        }
        else if (wave == 4)
        {
          
        }

        if (spawnlimit == 2 && wave == 2)
        {
            delay = 3.5f;

        }
        else if (spawnlimit == 2 && wave == 3)
        {

            delay = 3.5f;

        }


    }

}