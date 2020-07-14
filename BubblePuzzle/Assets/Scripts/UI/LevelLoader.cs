using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private SavingPassedLevel _savingPassedLevel;

    public void LoadLevel(int number)
    {
        SceneManager.LoadScene(number);
    }
    
    public void NextLevel()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex < sceneCount)
        {
            SavingPassedLevel.OnLevelComplete(SceneManager.GetActiveScene().buildIndex);
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
        _savingPassedLevel.OnExit();
        Application.Quit();
    }
}
