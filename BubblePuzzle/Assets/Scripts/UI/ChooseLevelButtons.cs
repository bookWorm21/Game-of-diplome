using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelButtons : MonoBehaviour
{
    [SerializeField] private Button[] _levelsButtons;
    [SerializeField] private SavingPassedLevel _savingPassedLevel;

    private void OnEnable()
    {
        _savingPassedLevel.OnGameStart();

        for (int i = 0; i < SavingPassedLevel.GetPassedLevels(); i++)
        {
            _levelsButtons[i].interactable = true;
        }
    }
}
