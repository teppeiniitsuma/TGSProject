using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

public class SpiderEnemy : BaseEnemy 
{
    //オブジェクトのRigidbodyの変数
    private Rigidbody2D ri2d;
    //  playerのtransformを格納する変数
    [SerializeField]
    private Transform player;
    //  オブジェクトの移動速度を格納する変数
    [SerializeField]
    private float attMove;
    //  オブジェクトとplayerの適切な距離で停止する変数
    [SerializeField]
    private float stopMove;
    //  playerがオブジェクトに近づいたら開始する変数
    [SerializeField]
    private float startMove;
    [SerializeField]
    private float enemyRange_1;
    [SerializeField]
    private float enemyRange_2;
    [SerializeField]
    private float time = 3f;
    private bool playerConfirmation = false;
    private bool enemyConfirmation = false;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Vector2 position;
    private Vector2 vec;
    [SerializeField]
    private float position_max = 2f;
    [SerializeField]
    private float position_mix = 2f;
    //float conten;

    void Start()
    {
        ri2d = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        //conten = transform.position.x;
    }

    void Update()
    {
        Move();
        Confirmation();
    }

    //  プレイヤーを検知する関数
    private void Confirmation()
    {
        //endPosition.x = startPosition.x + enemyRange_1;
        //position.x = startPosition.x + enemyRange_2;

        //  プレイヤーのトランスフォームを取る
        Vector2 playerPos = player.position;
        //  自分positionとプレイヤーのpositionをdistanceに入れる
        float distance = Vector2.Distance(transform.position, playerPos);
        //float pos = Vector2.Distance(transform.position, endPosition);
        //float pos2 = Vector2.Distance(transform.position, position);
        //  指定した範囲内にプレイヤーが居るときはtrue、居ないときはfalse
        if(distance < startMove && distance > stopMove)
        {
            playerConfirmation = true;
            Debug.Log("プレイヤーを発見しました。");
        }
        else
        {
            playerConfirmation = false;
            Debug.Log("プレイヤーが見つかりません。");
            //if() 
            //{
            //    Debug.Log("範囲にいます");

            //}
            //else
            //{
            //    Debug.Log("範囲に居ません");
            //}
        }

    }

    //  移動関数
    private void Move()
    {
        
        if(playerConfirmation)//    プレイヤーが範囲内に居るとき
        {
            Move2();
        }
        else if(!playerConfirmation)//  プレイヤーが範囲内に居ないとき
        {
            
            if(enemyConfirmation)// エネミーが最初の範囲に居るとき
            {
                
            }
            else if(!enemyConfirmation)//   エネミーが最初の範囲に居ないとき
            {
                transform.position = new Vector2(Mathf.MoveTowards
                (transform.position.x, startPosition.x, Time.deltaTime), transform.position.y);
                aho_move();
            }
            // transform.position.z);
           
        }
    }

    //  移動関数
    private void Move2()
    {
        Vector2 tagetPos = player.transform.position;

        float x = tagetPos.x;
        float y = 0;

        Vector2 direction = new Vector2(x - transform.position.x, y).normalized;
        ri2d.velocity = direction * 2;
    }

    private void aho_move()
    {
        startPosition.x += Time.deltaTime * time;
        if(startPosition.x >= position_max)
        {
            time *= -1;
            startPosition.x = position_max;
        }
        else if(startPosition.x <= position_mix)
        {
            time *= -1;
            startPosition.x = position_mix;
        }
        transform.position = new Vector2(startPosition.x, -1.5f);
    }

}

/*
 
 
 */
