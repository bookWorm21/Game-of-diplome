using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;
using System.Linq.Expressions;

public class SavingPassedLevel : MonoBehaviour
{
    private static bool[] _isPassedLevel;

    private static bool _firstStart = true;
    private string _path;

    private static int _countPassedLevels;

    private SaveData _saveData = new SaveData();


    public void OnGameStart()
    {
        if (_firstStart)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        _path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
            _path = Path.Combine(Application.dataPath, "Save.json");
#endif
            if (File.Exists(_path))
            {
                _countPassedLevels = JsonUtility.FromJson<SaveData>(File.ReadAllText(_path)).CountPassedLevels;
            }
            else
            {
                _countPassedLevels = 2;
            }

            _firstStart = false;

            _isPassedLevel = new bool[SceneManager.sceneCountInBuildSettings];

            for (int i = 0; i < _countPassedLevels; i++)
                _isPassedLevel[i] = true;

            for (int i = _countPassedLevels; i < _isPassedLevel.Length; i++)
                _isPassedLevel[i] = false;
        }
    }

    public static void OnLevelComplete(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < _isPassedLevel.Length)
        {
            if (_isPassedLevel[levelIndex] == false)
            {
                _isPassedLevel[levelIndex] = true;
                _countPassedLevels++;
            }
        }
    }

    public static int GetCountLevels()
    {
        if (_isPassedLevel != null)
            return _isPassedLevel.Length;
        else
            return 2;
    }

    public static int GetPassedLevels()
    {
        return _countPassedLevels - 1;
    }

    public void OnExit()
    {
        _saveData.TrySetPassedLevels(_countPassedLevels);
        File.WriteAllText(_path, JsonUtility.ToJson(_saveData));
    }
}

[Serializable]
public class SaveData
{
    public int CountPassedLevels { get; private set; }

    public void TrySetPassedLevels(int count)
    {
        if( count >= 0 && count <= SceneManager.sceneCountInBuildSettings)
        {
            CountPassedLevels = count;
        }
    }
}