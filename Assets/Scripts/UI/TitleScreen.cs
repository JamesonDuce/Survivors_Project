using PlasticPipe.Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("First Stage");
        Time.timeScale = 1;
    }

    public void LoadLevel_2()
    {
        SceneManager.LoadScene("Second Stage");
        Time.timeScale = 1;
    }
    public void LoadLevel_3()
    {
        SceneManager.LoadScene("Third Stage");
        Time.timeScale = 1;
    }

}
