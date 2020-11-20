using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 時間ないから書いた処理
public class LiftTrigger : MonoBehaviour
{
    PlayerInfoCounter info;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            info.IsSwitchedable = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            info.IsSwitchedable = true;
        }
    }
    private void Awake()
    {
        info = PlayerInfoCounter.Instance;
    }
}
