using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMoveLeft : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var f = collision.gameObject.GetComponent<SpiderEnemy>();
        if (null != f)
        {
            f.Left();
            gameObject.SetActive(false);
        }
    }
}
