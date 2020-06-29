//using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : BaseEnemy 
{
    //オブジェクトのRigidbodyの変数
    private Rigidbody2D ri2d;
    //  playerのtransformを格納する変数
    [SerializeField][Header("↓↓プレイヤーを此処に入れてね")]
    private Transform player;
    //private List<Transform> playerTransform = new List<Transform>() { };
    // 蜘蛛の見つけてない時の移動速度
    private float moveTime = 1.0f;
    //[SerializeField][Header("蜘蛛の移動速度↓※今はいじらないでね")]
    private float moveSpeed = 1.0f;
    //  オブジェクトとplayerの適切な距離で停止する変数
    //[SerializeField]
    private float stopMove = 1.5f;
    //  playerがオブジェクトに近づいたら開始する変数
    [SerializeField][Header("↓↓蜘蛛の視野の良さ")]
    private float startMove;
    private bool playerConfirmation = false;
    private bool enemyConfirmation = false;
    private Vector2 startPosition;
    [SerializeField][Header("↓↓プレイヤーを見つけてない時の右方向の移動範囲")]
    private float position_max = 2f;
    [SerializeField][Header("↓↓プレイヤーを見つけてない時の左方向の移動範囲")]
    private float position_mix = 2f;
    [SerializeField][Header("↓↓プレイヤーを追いかける速度")]
    private float attackMove = 2;
    private Animator animator;
    [SerializeField][Header("↓↓アニメーションの速度")]
    private float playSpeed = 1.0f;
    //  画像の向き
    private int direction = 0;

    void Start()
    {
        ri2d = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        this.animator = GetComponent<Animator>();
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
        //  プレイヤーのトランスフォームを取る
        Vector2 playerPos = player.position;
        //  自分positionとプレイヤーのpositionをdistanceに入れる
        float distance = Vector2.Distance(transform.position, playerPos);
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
        }

    }

    //  移動関数
    private void Move()
    {
        
        if(playerConfirmation)//    プレイヤーが範囲内に居るとき
        {
            Move2();
            transform.localScale = new Vector2(direction, 1);
            this.animator.SetTrigger("LockTrigger");
        }
        else if(!playerConfirmation)//  プレイヤーが範囲内に居ないとき
        {
                aho_move();
                transform.position = new Vector2(Mathf.MoveTowards
                (transform.position.x, startPosition.x, Time.deltaTime), transform.position.y);
            this.animator.SetTrigger("WalkTrigger");
        }
    }

    //  移動関数
    private void Move2()
    {
        Vector2 tagetPos = player.transform.position;

        float x = tagetPos.x;
        float y = 0;

        Vector2 playerDirection = new Vector2(x - transform.position.x, y).normalized;
        ri2d.velocity = playerDirection * attackMove;

        direction = 1;
    }

    //  見つけていないときの動き
    private void aho_move()
    {
        this.animator.speed = playSpeed;
        startPosition.x += Time.deltaTime * moveTime;
        if(startPosition.x >= position_max)
        {
            moveTime *= -moveSpeed;
            startPosition.x = position_max;
            direction = 1;
        }
        else if(startPosition.x <= position_mix)
        {
            moveTime *= -moveSpeed;
            startPosition.x = position_mix;
            direction = -1;
        }
        if(direction != 0) { transform.localScale = new Vector2(direction, 1); }
    }

}

/*
 
 
 */