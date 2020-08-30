using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour
{
    [SerializeField] private TouchedBallsHundler _liveSystem;
    [SerializeField] private GameObject[] _hearts;

    private void OnEnable()
    {
        _liveSystem.OnLivesChanged += OnLivesChange;
    }
    private void OnDisable()
    {
        _liveSystem.OnLivesChanged -= OnLivesChange;
    }

    private void OnLivesChange(int hearts)
    {
        if (hearts > _hearts.Length || hearts < 0)
            return;

        for (int i = 0; i < hearts; i++)
            _hearts[i].SetActive(true);

        for (int i = hearts; i < _hearts.Length; i++)
            _hearts[i].SetActive(false);
    }
}
