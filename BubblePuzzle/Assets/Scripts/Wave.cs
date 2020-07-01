using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private bool _isPossibilityIncrease = true;
    private Transform _transform;
    private Vector3 _startScale;

    private Bubble _touchedBubble;
    private List<Bubble> _bubblesInCircle = new List<Bubble>();

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _startScale = _transform.localScale;
    }

    private void Update()
    {
        //StartCoroutine(IncreaseScall());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Wall")
            _isPossibilityIncrease = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
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
        foreach( Bubble bubble in _bubblesInCircle)
        {
            bubble.TemplateOnTouched();
        }

        _transform.localScale = _startScale;
        _bubblesInCircle.Clear();
    }

    private IEnumerator IncreaseScall()
    {
        yield return new WaitForSeconds(0.1f);
        _transform.localScale *= 1.013f;
    }
}


