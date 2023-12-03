using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestSpawner : MonoBehaviour
{
    public GameObject spawnItem;
    public UserInterface UI;

    public float delay = 7.5f;
    private float delayReset;
    private int spawnlimit = 0;
    private int wave = 1;
    public int wavecount = 1;
    // Start is called before the first frame update
    void Start()
    {
        delayReset = delay;
        UI = GameObject.Find("Canvas").GetComponent<UserInterface>();
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
            spawnlimit += 2;
            wavecheck();
        }

       


    }
    public void wavecheck() 
    
    {
        if (spawnlimit >= 10 && wave == 1) 
        {
            wavecount = 2;
            wave = 2;
            delay = 30f;
            UI.updateWaveText();
        
        }

       else if (spawnlimit >= 20 && wave == 2)
        {
            wavecount = 3;
            wave = 3;
            delay = 30f;
            UI.updateWaveText();

        }

        else if (spawnlimit >= 25 && wave == 3)
        {
            wave = 4;
            UI.updateWaveText();



        }
       else  if (wave ==4)
        { delay = 10000f;
        ///end game code here
        
        }

        if (spawnlimit == 2 && wave == 2)
        {
            delay = 7.5f;

        }
        else if(spawnlimit ==2 && wave ==3)
        {

            delay = 7.5f;

        }


    }

}
