using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : BaseEnemy 
{
    //  オブジェクトのRigidbodyの変数
    //private Rigidbody2D ri2d;
    //  playerのtransformを格納する変数
    [SerializeField]
    private Transform player;
    //  オブジェクトの移動速度を格納する変数
    [SerializeField]
    private float moveSpeed;
    //  オブジェクトとplayerの適切な距離で停止する変数
    [SerializeField]
    private float stopMove;
    //  playerがオブジェクトに近づいたら開始する変数
    [SerializeField]
    private float startMove;

    void Start()
    {
        //ri2d = GetComponent<Rigidbody2D>();
        //  
        //player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //  移動関数
    private void Move()
    {
        Vector2 tagetPos = player.position;

        //tagetPos.y = transform.position.y;

        transform.LookAt(tagetPos);

        float move = Vector2.Distance(transform.position, player.position);

        if(move < startMove && move > stopMove)
        {
            transform.position = transform.position * moveSpeed * Time.deltaTime;
        }
    }

    //  移動関数
    private void Move2()
    {
            //Vector2 tagetPos = player.transform.position;

            //float x = tagetPos.x;
            //float y = 0;

            //Vector2 direction = new Vector2(x - transform.position.x, y).normalized;
            //ri2d.velocity = direction * 2;
    }

}
