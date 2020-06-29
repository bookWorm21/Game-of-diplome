using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnifier : MonoBehaviour
{
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        StartCoroutine(Magn());
    }

    private IEnumerator Magn()
    {
        yield return new WaitForSeconds(0.1f);
        _transform.localScale *= 1.05f;
        StartCoroutine(Magn());
    }
}
