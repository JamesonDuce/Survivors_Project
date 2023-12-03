using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] characters;
    void Start()
    {
        Instantiate(characters[GameObject.Find("MainManager").GetComponent<MainManager>().characterID]);
    }
}
