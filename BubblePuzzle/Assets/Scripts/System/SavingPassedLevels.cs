using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;
using System.Linq.Expressions;

public class SavingPassedLevels
{
    private static bool[] _isPassedLevel;

    private static bool _firstStart = true;
    private static string _path;

    private static int _countPassedLevels;


    public static void OnGameStart()
    {
        if(_firstStart)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        _path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        _path = Path.Combine(Application.dataPath, "Save.json");
#endif
            if (File.Exists(_path))
            {
                Debug.Log("true");
                _countPassedLevels = JsonUtility.FromJson<int>(File.ReadAllText(_path)) + 2;
                Debug.Log(_countPassedLevels);
            }
            else
            {
                Debug.Log("false");
                _countPassedLevels = 2;
            }

            //_firstStart = false;

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
        return _isPassedLevel.Length;
    }

    public static int GetPassedLevels()
    {
        return _countPassedLevels - 1;
    }

    public static void OnExit()
    {
        Debug.Log("Save");
        Debug.Log(_countPassedLevels);
        File.WriteAllText(_path, JsonUtility.ToJson(_countPassedLevels));
    }
}
