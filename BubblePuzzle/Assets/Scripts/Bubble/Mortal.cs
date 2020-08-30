using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortal : Bubble
{
    public override void OnTouchedWave(TouchedBallsHundler currentSystem)
    {
        currentSystem.OnTouchMortalBubble();
        Destroy(gameObject);
    }
}
