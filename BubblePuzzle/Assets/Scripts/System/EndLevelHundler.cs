using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndLevelHundler : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameWinPanel;

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
            _gameWinPanel.SetActive(true);
        else
            _gameOverPanel.SetActive(true);
    }
}
