using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickTracker : MonoBehaviour
{
    [SerializeField] private float _activationTime;
    [SerializeField] private Wave _wave;

    [SerializeField] LayerMask _layerMask;
    [SerializeField] ContactFilter2D _contactFilter;

    private float _timeLastClick;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Stationary)
            {
                _timeLastClick += Time.deltaTime;
            }

            if(touch.phase == TouchPhase.Ended && _timeLastClick >= _activationTime)
            {
                _wave.OnEndClick();
                _timeLastClick = 0;
                //_wave.gameObject.SetActive(false);
            }

            if (_timeLastClick >= _activationTime)
            {
                var point = Camera.main.ScreenToWorldPoint(touch.position);

                if (GetFirstBubbleUnderTouch(point, out Vector3 bubblePoint))
                {
                    ActivatedWave(bubblePoint);
                }
            }
        }
    }

    private void ActivatedWave(Vector2 point)
    {
        _wave.gameObject.SetActive(true);
        _wave.gameObject.transform.position = new Vector3(point.x, point.y, 0f);
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
