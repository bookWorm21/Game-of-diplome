using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Userful : Bubble
{
    public override void OnTouchedWave(ScoreAndLivesCounter currentSystem)
    {
        currentSystem.OnTouchUserfulBubble();
        Destroy(gameObject);
    }
}
