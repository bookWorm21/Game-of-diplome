using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseSelector : MonoBehaviour
{
    [SerializeField] private PhaseStudying[] _phases;
    [SerializeField] private GameObject _endLevelPanel;

    private int _currentIndex;
    private int _phaseCount;

    private void OnEnable()
    {
        foreach (var phase in _phases)
            phase.OnEndingPhase += GoNextPhase;

    }
    private void Start()
    {
        _currentIndex = 0;
        _phaseCount = _phases.Length;

        _phases[_currentIndex].OnStartPhase();
        _phases[_currentIndex].gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        foreach (var phase in _phases)
            phase.OnEndingPhase -= GoNextPhase;
    }

    private void GoNextPhase()
    {
        StartCoroutine(ChangePhase());
    }
    private IEnumerator ChangePhase()
    {
        yield return new WaitForSeconds(2.0f);

        _phases[_currentIndex].OnEndPhase();
        _phases[_currentIndex].gameObject.SetActive(false);
        _currentIndex++;

        if (_currentIndex > _phaseCount - 1)
        {
            Time.timeScale = 0;
            SavingPassedLevel.OnLevelComplete(2);
            _endLevelPanel.SetActive(true);
        }
        else
        {
            _phases[_currentIndex].gameObject.SetActive(true);
            _phases[_currentIndex].OnStartPhase();
        }
    }
}
