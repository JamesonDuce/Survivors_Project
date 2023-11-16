using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BattleSelector : MonoBehaviour
{
    private int charId = 0;
    private int lvlId = 0;
    public TMP_Dropdown charDrop;
    public TMP_Dropdown lvlDrop;
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void StartGame()
    {
        charId = charDrop.value;
        lvlId = lvlDrop.value;

        switch (lvlId)
        {
            case 0: // None
                break;
            case 1:
                SceneManager.LoadScene("First Stage");
                break;
            case 2:
                SceneManager.LoadScene("Second Stage");
                break;
            default:
                SceneManager.LoadScene("First Stage");
                break;
        }

    }
}
