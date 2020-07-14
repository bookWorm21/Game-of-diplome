using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class PhaseStudying : MonoBehaviour
{
    [SerializeField] private GameObject[] _participants;
    [SerializeField] private GameObject _helpPanel;
    [SerializeField] private DeathTracking _deathTracking;

    public UnityAction OnEndingPhase;

    private void OnEnable()
    {
        _deathTracking.OnBubbleDestroyed += SatisfiedCondition;
    }
    private void OnDisable()
    {
        //_deathTracking.OnBubbleDestroyed -= SatisfiedCondition;
    }

    private void SatisfiedCondition()
    {
        OnEndingPhase?.Invoke();
    }

    public void OnStartPhase()
    {
        _helpPanel.SetActive(true);
        Invoke("TurnHelpPanel", 5.0f);
        foreach(GameObject _object in _participants)
        {
            _object.SetActive(true);
        }
    }

    public void OnEndPhase()
    {
        _helpPanel.SetActive(false);
        foreach (GameObject _object in _participants)
        {
            if (_object != null)
                _object.SetActive(false);
        }
    }

    public void TurnHelpPanel()
    {
        _helpPanel.SetActive(false);
    }
}
