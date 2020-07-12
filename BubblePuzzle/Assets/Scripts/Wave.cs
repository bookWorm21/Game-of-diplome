using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private ScoreAndLivesSystem _currentSystem;

    private bool _isPossibilityIncrease = true;
    private Transform _transform;
    private Vector3 _startScale;

    private Bubble _touchedBubble;
    private List<Bubble> _bubblesInCircle = new List<Bubble>();

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _startScale = _transform.localScale;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
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
            StartCoroutine(IncreaseScall());
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
        _transform.localScale = _startScale;
        this.gameObject.SetActive(false);
        _bubblesInCircle.Clear();
    }

    private IEnumerator IncreaseScall()
    {
        _transform.localScale *= 1.013f;
        yield return new WaitForSeconds(0.1f);
    }
}


