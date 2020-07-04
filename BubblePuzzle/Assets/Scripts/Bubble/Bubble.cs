using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bubble : MonoBehaviour
{
    public abstract void OnTouchedWave(ScoreAndLivesSystem currentSystem);
}
