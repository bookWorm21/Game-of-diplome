using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private bool _isPossibilityIncrease = true;
    private Transform _transform;
    private Vector3 _startScale;

    private Bubble _touchedBubble;
    private List<Bubble> _bubblesInCircle;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _startScale = _transform.localScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Well")
            _isPossibilityIncrease = false;
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
        _transform.localScale = _startScale;
        _bubblesInCircle.Clear();
    }

    private IEnumerator IncreaseScall()
    {
        yield return new WaitForSeconds(0.1f);
        _transform.localScale *= 1.1f;
    }
}
