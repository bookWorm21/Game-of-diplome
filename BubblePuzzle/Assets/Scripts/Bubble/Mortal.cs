using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortal : Bubble
{
    public override void OnTouchedWave(ScoreAndLivesCounter currentSystem)
    {
        currentSystem.OnTouchMortalBubble();
        Destroy(gameObject);
    }
}
