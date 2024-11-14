using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fku : MonoBehaviour
{
    public void RestartKeLevelSatu()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void RestartKeLevelDua()
    {
        SceneManager.LoadScene("GameplayLevel2");
    }

    public void RestartKeLevelTiga()
    {
        SceneManager.LoadScene("GameplayLevel3");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
