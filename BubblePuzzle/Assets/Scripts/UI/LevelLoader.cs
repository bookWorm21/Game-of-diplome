using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(int number)
    {
        SceneManager.LoadScene(number);
    }
    
    public void NextLevel()
    {
        int sceneCount = SceneManager.sceneCount;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex < sceneCount - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("Last level"); // fixe this
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
