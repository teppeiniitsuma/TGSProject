using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Positon _position;

    bool touch = false;

    CameraManager _cameraManager;
    private enum Positon
    {
        PREV = 0,
        NEXT,
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { touch = true; }
    }

    void Start()
    {
        _cameraManager = transform.parent.gameObject.GetComponent<CameraManager>();
    }


    void TouchJudgement()
    {
        if (touch)
        {
            _cameraManager.TauchTest((int)_position);
            touch = false;
        }
    }
    void Update()
    {
        TouchJudgement();
    }
}
