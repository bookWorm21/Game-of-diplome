using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuButtons : MonoBehaviour
{
    public void OnClickGameMenuButtons(int timeScaleFactor)
    {
        Time.timeScale = timeScaleFactor;
    }
}
