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
                _wave.gameObject.SetActive(false);
            }

            if (_timeLastClick >= _activationTime)
            {
                var point = Camera.main.ScreenToWorldPoint(touch.position);
                if (GetFirstBubbleUnderTouch(point))
                {
                    ActivatedWave(point);
                }
            }
        }
    }

    private void ActivatedWave(Vector3 point)
    {
        _wave.gameObject.SetActive(true);
        _wave.gameObject.transform.position = new Vector3(point.x, point.y, 0f);
        _wave.TryIncreaseScall();
    }

    private bool GetFirstBubbleUnderTouch(Vector3 point)
    {
        var pointer = new Vector2(point.x, point.y);

        if (Physics2D.Raycast(pointer, Vector2.zero, 0f, _layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
