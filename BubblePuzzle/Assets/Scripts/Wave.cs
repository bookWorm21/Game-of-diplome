using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private TouchedBallsHundler _currentSystem;

    [SerializeField] private float _magnifierRate;

    private bool _isPossibilityIncrease = true;
    private Vector3 _startScale;

    private Bubble _touchedBubble;
    private List<Bubble> _bubblesInCircle = new List<Bubble>();

    private void Awake()
    {
        _startScale = transform.localScale;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall walll))
        {
            _isPossibilityIncrease = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Bubble>(out _touchedBubble))
        {
            _bubblesInCircle.Add(_touchedBubble);
        }
    }

    public void TryIncreaseScall()
    {
        if (_isPossibilityIncrease)
        {
            IncreaseScall();
        }
    }

    public void OnEndClick()
    {
        if (_bubblesInCircle.Count > 1)
        {
            foreach (Bubble bubble in _bubblesInCircle)
            {
                bubble.OnTouchedWave(_currentSystem);
            }
        }

        _currentSystem.OnDisableCurrentWave();
        _isPossibilityIncrease = true;
        transform.localScale = _startScale;
        gameObject.SetActive(false);
        _bubblesInCircle.Clear();
    }

    private void IncreaseScall()
    {
        transform.localScale *= _magnifierRate;
    }
}


