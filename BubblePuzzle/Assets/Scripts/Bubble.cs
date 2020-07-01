using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    //public abstract void OnTouchedWave();

    public void TemplateOnTouched()
    {
        Destroy(gameObject);
    }
}
