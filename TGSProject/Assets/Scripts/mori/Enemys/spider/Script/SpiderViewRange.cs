using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderViewRange : MonoBehaviour
{
    //private GameObject player;
    [SerializeField]
    private SpiderEnemy spider;

    void Start()
    {
        //player = GameObject.Find("player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == spider.player)
        {
            spider.playerConfirmation = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == spider.player)
        {
            spider.playerConfirmation = false;
        }
    }
}
