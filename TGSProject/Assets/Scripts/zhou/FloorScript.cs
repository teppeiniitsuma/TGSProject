using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    [SerializeField] BoxCollider2D floor;
    [SerializeField] GameObject playerParent;

    // 上に乗ったらプラスする（これでトリガー判定を制御）
    int _count = 0;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player") {

            floor.isTrigger = true;
            _count++;
            collider.gameObject.transform.parent = transform.parent;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _count--;
            if(_count == 0)
            {
                floor.isTrigger = false;
                // parentの子要素にしてたの気が付かなかった
                collider.gameObject.transform.parent = playerParent.transform;
            }
            else if(_count == 1)
            {
                collider.gameObject.transform.parent = playerParent.transform;
            }

        }
    }    
}