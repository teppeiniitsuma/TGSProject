using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimasion : MonoBehaviour
{ 
    private bool _isCamera;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnBecameVisible()
    {
         _isCamera = true;
        GetComponent<Animator>().enabled = true;
    }

    private void OnBecameInvisible()
    {
        _isCamera = false;
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_isCamera);
    }
}
