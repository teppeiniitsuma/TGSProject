using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    float width;
    private void Awake()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    private void OnBecameInvisible()
    {
        transform.position += Vector3.right * width * 2;
    }
}
