using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainManager : MonoBehaviour
{
    /*  The purpose of MainManager is to keep a central game object that stays in between scnenes.
        When a new level is loaded, it will reference this game object to determine what character is selected.
        It also stores the gold a player has, so that they can purchase new characters. 
     */ 
    public static MainManager Instance;

    public int gold;
    public int characterID;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
}
