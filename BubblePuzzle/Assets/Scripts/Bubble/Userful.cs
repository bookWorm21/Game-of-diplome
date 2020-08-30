using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Userful : Bubble
{
    public override void OnTouchedWave(TouchedBallsHundler currentSystem)
    {
        currentSystem.OnTouchUserfulBubble();
        Destroy(gameObject);
    }
}
