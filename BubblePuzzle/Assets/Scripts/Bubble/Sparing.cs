using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparing : Bubble
{
    public override void OnTouchedWave(TouchedBallsHundler currentSystem)
    {
        currentSystem.OnTouchSparingBubble();
        Destroy(gameObject);
    }
}
