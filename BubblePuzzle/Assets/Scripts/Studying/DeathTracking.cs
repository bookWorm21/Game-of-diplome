using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathTracking : MonoBehaviour
{
    public UnityAction OnBubbleDestroyed;

    private void OnDisable()
    {
        OnBubbleDestroyed?.Invoke();
    }
}
