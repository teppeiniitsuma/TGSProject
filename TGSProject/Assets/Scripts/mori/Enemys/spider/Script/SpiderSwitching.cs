using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine; 

public class SpiderSwitching : BaseEnemy
{
    //private bool _abc;

    //public bool ON;

    [SerializeField] GameObject[] spiderObject = new GameObject[2];

    // 蜘蛛の見つけてない時の移動速度
    private float moveTime = 1.0f;
    //[SerializeField][Header("蜘蛛の移動速度↓※今はいじらないでね")]
    private float moveSpeed = 1.0f;
    //  オブジェクトとplayerの適切な距離で停止する変数
    //[SerializeField]
    private float stopMove = 1.5f;
    //  playerがオブジェクトに近づいたら開始する変数
    [SerializeField]
    [Header("↓↓蜘蛛の視野の良さ")]
    private float startMove;
    private bool playerConfirmation = false;
    [SerializeField]
    [Header("↓↓プレイヤーを見つけてない時の右方向の移動範囲")]
    private float position_max = 2f;
    [SerializeField]
    [Header("↓↓プレイヤーを見つけてない時の左方向の移動範囲")]
    private float position_mix = 2f;
    [SerializeField]
    [Header("↓↓プレイヤーを追いかける速度")]
    private float attackMove = 2f;
    void Start()
    {
        base.enemyID = EnemyType.Spider;
        ri2d = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void IsAttackOrNot()
    {
        if(playerConfirmation)
        {
            spiderObject[1].SetActive(false);
            spiderObject[0].SetActive(true);
        }
        else if(!playerConfirmation)
        {
            spiderObject[0].SetActive(false);
            spiderObject[1].SetActive(true);
        }
    }

    //  プレイヤーを検知する関数
    private void Confirmation()
    {
        //  プレイヤーのトランスフォームを取る
        Vector2 playerPos = player.position;
        //  自分positionとプレイヤーのpositionをdistanceに入れる
        float distance = Vector2.Distance(transform.position, playerPos);
        //  指定した範囲内にプレイヤーが居るときはtrue、居ないときはfalse
        if (distance < startMove && distance > stopMove)
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

        if (playerConfirmation)//    プレイヤーが範囲内に居るとき
        {
            //SpiderWalking anokodou = GetComponent<SpiderWalking>();
            //anokodou.A_Move2();
            Move2();
            transform.localScale = new Vector2(direction, 1);
            //this.animator.SetTrigger("LockTrigger");
        }
        else if (!playerConfirmation)//  プレイヤーが範囲内に居ないとき
        {
            aho_move();
            transform.position = new Vector2(Mathf.MoveTowards
            (transform.position.x, startPosition.x, Time.deltaTime), startPosition.y);
            //this.animator.SetTrigger("WalkTrigger");
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
        //this.animator.speed = playSpeed;
        startPosition.x += Time.deltaTime * moveTime;
        if (startPosition.x >= position_max)
        {
            moveTime *= -moveSpeed;
            startPosition.x = position_max;
            direction = 1;
        }
        else if (startPosition.x <= position_mix)
        {
            moveTime *= -moveSpeed;
            startPosition.x = position_mix;
            direction = -1;
        }
        if (direction != 0) { transform.localScale = new Vector2(direction, 1); }
    }


void Update()
    {
        if (!SpiderCamera._yesCamera)
        {
            IsAttackOrNot();
            Move();
            Confirmation();
        }
        else if (SpiderCamera._yesCamera) 
        {

        }
    }
}
