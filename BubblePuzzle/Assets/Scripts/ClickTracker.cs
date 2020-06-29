using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickTracker : MonoBehaviour
{
    [SerializeField] private float _clickTime;
    [SerializeField] private Wave _wave;

    private float _timeLastClick;
    private Touch _touch;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began)
            {
                _timeLastClick = 0;
            }

            if (_touch.phase == TouchPhase.Stationary)
            {
                _timeLastClick += Time.deltaTime;
            }

            if(_touch.phase == TouchPhase.Ended)
            {
                _wave.OnEndClick();
                _wave.gameObject.SetActive(false);
            }

            if(_timeLastClick >= _clickTime)
            {
                ActivateWave();
            }
        }
    }

    private void ActivateWave()
    {
        Debug.Log("wave active");
        _wave.gameObject.SetActive(true);
        _wave.gameObject.transform.position = _touch.position;
        _wave.TryIncreaseScall();
    }
}
