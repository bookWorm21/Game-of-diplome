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

                if (GetFirstBubbleUnderTouch(point))
                {
                    ActivatedWave(point);
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

    private void ActivatedWave(Vector3 point)
    {
        _wave.gameObject.SetActive(true);
        _wave.gameObject.transform.position = new Vector3(point.x, point.y, 0);
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
