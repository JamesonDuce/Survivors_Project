using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("First Stage");
    }

    public void LoadLevel_2()
    {
        SceneManager.LoadScene("Second Stage");
    }
    public void LoadLevel_3()
    {
        SceneManager.LoadScene("Third Stage");
    }

}
