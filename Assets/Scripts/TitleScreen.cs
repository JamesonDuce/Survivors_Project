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
}
