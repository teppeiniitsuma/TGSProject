using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCamera : MonoBehaviour
{
    public static bool _yesCamera{ set; get; }

    private void OnBecameVisible()
    {
        _yesCamera = false;
        GetComponent<Animator>().enabled = true;
    }

    private void OnBecameInvisible()
    {
        _yesCamera = true;
        GetComponent<Animator>().enabled = false;
    }

    void Update()
    {
        Debug.Log(_yesCamera);
    }
}
