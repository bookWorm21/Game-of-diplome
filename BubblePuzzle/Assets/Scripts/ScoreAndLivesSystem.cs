using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndLivesSystem : MonoBehaviour
{
    [SerializeField] private int _maxLives;
    [SerializeField] private Text _forTest;

    private int _currentLives;

    private int _score;
    private int _multiplier;

    private void Start()
    {
        _multiplier = 1;
        _currentLives = _maxLives;
        _score = 0;
        _forTest.text = _score.ToString();
    }

    public void OnTouchUserfulBubble()
    {
        _multiplier *= 2;
    }

    public void OnTouchMortalBubble()
    {
        if (_currentLives > 1)
            _currentLives--;
        else
            Debug.Log("Game Over");
    }

    public void OnTouchSparingBubble()
    {
        _currentLives++;
    }

    public void OnDisableCurrentWave()
    {
        if(_multiplier > 2)
            _score += _multiplier;

        _forTest.text = _score.ToString();
        _multiplier = 1;
    }
}
