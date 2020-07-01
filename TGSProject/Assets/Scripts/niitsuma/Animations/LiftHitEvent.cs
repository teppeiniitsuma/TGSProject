using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftHitEvent : MonoBehaviour
{
    private Transform player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //player.position = new Vector2(Mathf.MoveTowards(player.position.x, this.transform.position.x - 1f, Time.deltaTime * 2), player.position.y);
        }
    }
    void Start()
    {
        player = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
