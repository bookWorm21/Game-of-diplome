using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ScoreAndLivesSystem : MonoBehaviour
{
    public event UnityAction<int> OnLivesChanged;
    public event UnityAction<bool> OnEndLevel;

    [SerializeField] private int _maxLives;
    [SerializeField] private Text _forTest;

    private int _currentLives;

    private int _score;
    private int _multiplier;

    private int _countUserfulInLevel;

    private bool _touchUnUserfulBubble = false;

    private void Start()
    {
        _multiplier = 1;
        _currentLives = _maxLives - 2;
        _score = 0;
        _forTest.text = _score.ToString();

        OnLivesChanged?.Invoke(_currentLives);

        _countUserfulInLevel = GameObject.FindGameObjectsWithTag("Userful").Length;
    }

    public void OnTouchUserfulBubble()
    {
        _multiplier *= 2;
    }

    public void OnTouchMortalBubble()
    {
        _touchUnUserfulBubble = true;

        if (_currentLives > 1)
        {
            _currentLives--;
        }
        else
        {
            OnEndLevel?.Invoke(false);
        }

        OnLivesChanged?.Invoke(_currentLives);
    }

    public void OnTouchSparingBubble()
    {
        _touchUnUserfulBubble = true;
        _currentLives++;
        OnLivesChanged?.Invoke(_currentLives);
    }

    public void OnDisableCurrentWave()
    {
        if (_multiplier > 2)
        {
            _score += _multiplier;
            _countUserfulInLevel -= _multiplier / 2;
        }
        else if (_touchUnUserfulBubble)
        {
            _score += 2;
            _countUserfulInLevel -= 1;
        }

        if (_countUserfulInLevel == 0)
        {
            OnEndLevel?.Invoke(true);
        }
        else if (_countUserfulInLevel == 1 && GameObject.FindGameObjectWithTag("Bubble") == null)
        {
            OnEndLevel?.Invoke(false);
        }

        _touchUnUserfulBubble = false;
        _forTest.text = _score.ToString();
        _multiplier = 1;

    }
}
