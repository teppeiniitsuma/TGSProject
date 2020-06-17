using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class SpiderEnemy : BaseEnemy 
{
    //オブジェクトのRigidbodyの変数
    private Rigidbody2D ri2d;
    //  playerのtransformを格納する変数
    [SerializeField]
    private Transform player;
    //  オブジェクトの移動速度を格納する変数
    //[SerializeField]
    //private float moveSpeed;
    //  オブジェクトとplayerの適切な距離で停止する変数
    [SerializeField]
    private float stopMove;
    //  playerがオブジェクトに近づいたら開始する変数
    [SerializeField]
    private float startMove;
    private bool playerConfirmation = false;

    void Start()
    {
        ri2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Confirmation();
    }

    //  プレイヤーを検知する関数
    private void Confirmation()
    {
        Vector3 playerPos = player.position;
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance < startMove && distance > stopMove)
        {
            playerConfirmation = true;
            Debug.Log("プレイヤーを発見しました。");
        }
        else
        {
            playerConfirmation = false;
            Debug.Log("プレイヤーが見つかりません。");
        }

    }

    //  移動関数
    private void Move()
    {
        if(playerConfirmation == true)
        {

        }
        else if(playerConfirmation == false)
        {

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
