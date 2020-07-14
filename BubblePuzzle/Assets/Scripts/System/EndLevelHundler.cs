using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelHundler : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameWinPanel;
    [SerializeField] private GameObject _allLevelsCompletedPanel;

    [SerializeField] private ScoreAndLivesSystem _currentSystem;

    private void OnEnable()
    {
        _currentSystem.OnEndLevel += FinishGame;
    }

    private void OnDisable()
    {
        _currentSystem.OnEndLevel -= FinishGame;
    }

    private void FinishGame(bool isWin)
    {
        Time.timeScale = 0;

        if (isWin)
        {
            if (SavingPassedLevel.GetCountLevels() == SavingPassedLevel.GetPassedLevels() + 1)
            {
                _allLevelsCompletedPanel.SetActive(true);
            }
            else
            { 
                _gameWinPanel.SetActive(true);
                SavingPassedLevel.OnLevelComplete(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            _gameOverPanel.SetActive(true);
        }
    }
}
