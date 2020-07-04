using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortal : Bubble
{
    public override void OnTouchedWave(ScoreAndLivesSystem currentSystem)
    {
        currentSystem.OnTouchMortalBubble();
        Destroy(gameObject);
    }
}
