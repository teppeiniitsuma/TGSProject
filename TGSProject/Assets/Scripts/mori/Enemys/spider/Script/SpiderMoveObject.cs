using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMoveObject : MonoBehaviour
{
    [SerializeField]
    GameObject spider;
    void Update()
    {
        transform.position = new Vector2(transform.position.x, spider.transform.position.y);
    }
}
