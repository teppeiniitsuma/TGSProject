using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMover : MonoBehaviour
{
    [SerializeField] private Transform _cameraPos;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(_cameraPos.position.x, transform.position.y);
    }
}
