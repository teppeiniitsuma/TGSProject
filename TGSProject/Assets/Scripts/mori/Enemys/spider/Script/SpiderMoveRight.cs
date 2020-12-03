using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMoveRight : MonoBehaviour
{
    [SerializeField]
    GameObject obj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var f = collision.gameObject.GetComponent<SpiderEnemy>();
        if (null != f)
        {
            
        }
        if(collision.gameObject == obj)
        {
            f.Right();
            f._speedSwitchingON = true;
            gameObject.SetActive(false);
        }
    }
}
