using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerAnalog : MonoBehaviour
{
    [SerializeField] private float _activationTime;
    [SerializeField] private Wave _wave;

    [SerializeField] LayerMask _layerMask;
    [SerializeField] ContactFilter2D _contactFilter;

    private float _timeLastClick;
    private bool _isPress = false;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _isPress = true;
        }

        if(_isPress)
        {
            _timeLastClick += Time.deltaTime;
            
            if(_timeLastClick >= _activationTime)
            {
                var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (GetFirstBubbleUnderTouch(point, out Vector3 bubblePoint))
                {
                    ActivatedWave(bubblePoint);
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            _isPress = false;

            if(_timeLastClick >= _activationTime)
            {
                _wave.OnEndClick();
                _timeLastClick = 0;
                _wave.gameObject.SetActive(false); 
            }

            _timeLastClick = 0;
        }
    }

    private void ActivatedWave(Vector2 point)
    {
        _wave.gameObject.SetActive(true);
        _wave.gameObject.transform.position = new Vector3(point.x, point.y, 0);
        _wave.TryIncreaseScall();
    }

    private bool GetFirstBubbleUnderTouch(Vector3 point, out Vector3 _bubblePoint)
    {
        var pointer = new Vector2(point.x, point.y);
        RaycastHit2D[] results = new RaycastHit2D[1];

        if (Physics2D.Raycast(new Vector2(point.x, point.y), Vector2.zero, _contactFilter, results) > 0)
        {
            _bubblePoint = results[0].transform.position;
            return true;
        }
        else
        {
            _bubblePoint = Vector2.zero;
            return false;
        }
    }
}
