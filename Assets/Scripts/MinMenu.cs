using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    
}
