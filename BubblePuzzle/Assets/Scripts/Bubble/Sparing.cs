using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparing : Bubble
{
    public override void OnTouchedWave(ScoreAndLivesSystem currentSystem)
    {
        currentSystem.OnTouchSparingBubble();
        Destroy(gameObject);
    }
}
