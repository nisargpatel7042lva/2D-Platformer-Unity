using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Level()
    {
        SceneManager.LoadScene(1);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(3);
    }

    public void NextLevel()
    {
        if (LevelManager.instance != null)
        {
            LevelManager.instance.GoToNextLevel();
        }
        else
        {
            // Fallback if LevelManager not available
            int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextScene);
        }
    }

    public void RestartLevel()
    {
        if (LevelManager.instance != null)
        {
            LevelManager.instance.RestartLevel();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
