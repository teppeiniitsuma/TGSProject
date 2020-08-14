//using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : BaseEnemy
{
    [SerializeField] GameObject[] spiderObject = new GameObject[2];
    [SerializeField] GameObject[] moveSpider = new GameObject[2];
    public bool isCamera { get; set; } = false;
    public bool isLeftOrRight { get; set; } = false;

    // 蜘蛛の見つけてない時の移動速度
    [SerializeField][Header("↓↓蜘蛛の見つけてない時の移動速度")][Range(0.0f,100.0f)]private float moveTime = 1.0f;
    //  オブジェクトとplayerの適切な距離で停止する変数
    //[SerializeField]
    private float stopMove = 1.5f;
    //  playerがオブジェクトに近づいたら開始する変数
    [SerializeField]
    [Header("↓↓蜘蛛の視野の良さ")]
    private float startMove;
    private bool playerConfirmation = false;
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
        if (playerConfirmation)
        {
            spiderObject[1].SetActive(false);
            spiderObject[0].SetActive(true);
        }
        else if (!playerConfirmation)
        {
            spiderObject[0].SetActive(false);
            spiderObject[1].SetActive(true);
        }
    }
    public void Left()
    {
        isLeftOrRight = true;
        moveSpider[1].SetActive(true);
    }

    public void Right()
    {
        isLeftOrRight = false;
        moveSpider[0].SetActive(true);
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

        if (playerConfirmation) { Move2(); }//    プレイヤーが範囲内に居るとき
        else if (!playerConfirmation) { aho_move(); }//  プレイヤーが範囲内に居ないとき
    }

    //  移動関数
    private void Move2()
    {
        Vector2 tagetPos = player.transform.position;

        float x = tagetPos.x;
        float y = 0;

        Vector2 playerDirection = new Vector2(x - transform.position.x, y).normalized;
        ri2d.velocity = playerDirection * attackMove;

        transform.localScale = new Vector2(direction, 1);
        if (transform.position.x <= tagetPos.x) { direction = -1; }
        else if(transform.position.x >= tagetPos.x) { direction = 1; }
    }

    //  見つけていないときの動き
    private void aho_move()
    {
        if (direction != 0) { transform.localScale = new Vector2(direction, 1); }
        Vector2 MOSpider_L = moveSpider[0].transform.position;
        Vector2 MOSpider_R = moveSpider[1].transform.position;
        if (!isLeftOrRight)
        {
            transform.position = new Vector2(Mathf.MoveTowards
            (transform.position.x, MOSpider_L.x, Time.deltaTime * moveTime), startPosition.y);
            if(transform.position.x >= MOSpider_L.x) { direction = 1; }
            else if(transform.position.x <= MOSpider_L.x) { direction = -1; }
        }
        else if(isLeftOrRight)
        {
            transform.position = new Vector2(Mathf.MoveTowards
            (transform.position.x, MOSpider_R.x, Time.deltaTime * moveTime), startPosition.y);
            if (transform.position.x >= MOSpider_R.x) { direction = 1; }
            else if (transform.position.x <= MOSpider_R.x) { direction = -1; }
        }
    }


        void Update()
        {
        if(GameManager.Instance.GetGameState == GameManager.GameState.Road)
        {
            transform.position = startPosition;
            return;
        }
        if(GameManager.Instance.GetGameState == GameManager.GameState.Main)
        {
            if (!isCamera)
            {
                IsAttackOrNot();
                Move();
                Confirmation();
            }
            else if (isCamera)
            {

            }
        }
        }
    }

/*
    

    
 */
