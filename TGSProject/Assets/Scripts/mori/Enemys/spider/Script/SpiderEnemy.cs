//using System.Collections.Generic;
using UnityEngine;

public enum SpiderType
{
    Normal,
    Boss,
}

public class SpiderEnemy : BaseEnemy
{
    [SerializeField] GameObject[] spiderObject = new GameObject[2];
    [SerializeField] GameObject[] moveSpider = new GameObject[2];
    [SerializeField] GameObject[] fleeLocation = new GameObject[2];
    [SerializeField] GameObject wasSurprised;
    ConfirmationSpiderPosition _spiderPos;
    public bool isCamera { get; set; } = false;
    public bool isLeftOrRight { get; set; } = false;

    public bool hasToFaceWhich { get; set; } = false;

    GameObject LastBoos;
    LastEnemy LsBoss;

    [SerializeField]
    private Animator _anims;

    // 蜘蛛の見つけてない時の移動速度
    [SerializeField][Header("↓↓蜘蛛の見つけてない時の移動速度")][Range(0.0f,100.0f)]
    private float moveTime = 1.0f;
    //  オブジェクトとplayerの適切な距離で停止する変数
    //[SerializeField]
    private float stopMove = 1.5f;
    [SerializeField]
    private float FleeMoveSpeed;
    //public delegate int unko = 114514;
    //  playerがオブジェクトに近づいたら開始する変数
    public bool playerConfirmation { get; set; } = false;
    private bool WasHitToStone = false;
    private bool _speedSwitching = false;
    public bool _speedSwitchingON { set { _speedSwitching = value; } }
    [SerializeField]
    private float _surprisedTime;
    [SerializeField]
    [Header("↓↓プレイヤーを追いかける速度")]
    private float attackMove;
    public SpiderType spiderType;
    private int _countMin = 1; 
    private int _countMax = 4;
    private int _moveSpeed;

    void Start()
    {
        _speedSwitchingON = false;
        _spiderPos = GetComponent<ConfirmationSpiderPosition>();
        IsFieldBoss();
        startPosition = transform.position;
        player = null;
        player = GameObject.Find("player");
        switch(this.spiderType)
        {
            case SpiderType.Boss:
                LastBoos = GameObject.Find("spiderBoss");
                LsBoss = LastBoos.GetComponent<LastEnemy>();
                break;
        }
    }

    private void IsFieldBoss()
    {
        switch(this.spiderType)
        {
            case SpiderType.Normal:
                base.enemyID = EnemyType.SpiderNormal;
                break;
            case SpiderType.Boss:
                base.enemyID = EnemyType.SpiderBoss;
                break;
        }
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
    //private void Confirmation()
    //{
    //    //  プレイヤーのトランスフォームを取る
    //    Vector2 playerPos = player.transform.position;
    //    //  自分positionとプレイヤーのpositionをdistanceに入れる
    //    float distance = Vector2.Distance(transform.position, playerPos);
    //    //  指定した範囲内にプレイヤーが居るときはtrue、居ないときはfalse
    //    if (distance < startMove && distance > stopMove)
    //    {
    //        playerConfirmation = true;
    //        //Debug.Log("プレイヤーを発見しました。");
    //    }
    //    else if()
    //    {
    //        playerConfirmation = false;
    //        //Debug.Log("プレイヤーが見つかりません。");
    //    }

    //}

    //  プレイヤーがいるかどうかの関数
    private void MovingJudgement()
    {

        if (playerConfirmation) { AttackMove(); }//    プレイヤーが範囲内に居るとき
        else if (!playerConfirmation) { NormalMove(); }//  プレイヤーが範囲内に居ないとき
    }

    //  攻撃移動の関数
    private void AttackMove()
    {
        Vector2 tagetPos = player.transform.position;

        transform.position = new Vector2(Mathf.MoveTowards
        (transform.position.x, tagetPos.x, Time.deltaTime * attackMove), transform.position.y);

        transform.localScale = new Vector2(direction, 1);
        if (transform.position.x <= tagetPos.x) { direction = -1; }
        else if(transform.position.x >= tagetPos.x) { direction = 1; }
    }

    //  見つけていないときの動き
    private void NormalMove()
    {
        _anims.SetTrigger("Work");
        if (direction != 0) { transform.localScale = new Vector2(direction, 1); }
        Vector2 MOSpider_L = moveSpider[0].transform.position;
        Vector2 MOSpider_R = moveSpider[1].transform.position;
        if (!isLeftOrRight)
        {
            transform.position = new Vector2(Mathf.MoveTowards
            (transform.position.x, MOSpider_L.x, Time.deltaTime * moveTime), transform.position.y);
            if(transform.position.x >= MOSpider_L.x) { direction = 1; }
            else if(transform.position.x <= MOSpider_L.x) { direction = -1; }
        }
        else if(isLeftOrRight)
        {
            transform.position = new Vector2(Mathf.MoveTowards
            (transform.position.x, MOSpider_R.x, Time.deltaTime * moveTime), transform.position.y);
            if (transform.position.x >= MOSpider_R.x) { direction = 1; }
            else if (transform.position.x <= MOSpider_R.x) { direction = -1; }
        }
        if (_speedSwitching)
        {
            NormalRandomSpeed();
        }
    }

    private void NormalRandomSpeed()
    {
        _moveSpeed = Random.Range(_countMin,_countMax);
        _speedSwitchingON = false;
    }

    private void NormalMoveSpeed()
    {

    }

    //private void OnDisable()
    //{
    //    switch(this.spiderType)
    //    {
    //        case SpiderType.Boss:
    //            LsBoss._ofSpider--;
    //            //Destroy(this);
    //            break;
    //    }
    //}

    private void HasToFaceWhich()
    {
        if(direction == 1)
        {
            hasToFaceWhich = false;
        }
        else if(direction == -1)
        {
            hasToFaceWhich = true;
        }
    }

    public override void ApplyDamage(EnemyType id)
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        spiderObject[0].SetActive(false);
        spiderObject[1].SetActive(true);
        transform.position = wasSurprised.transform.position;
        WasHitToStone = true;
        switch (this.spiderType)
        {
            case SpiderType.Boss:
                LsBoss.ofSpider--;
                //Destroy(this);
                break;
        }
    }

    private void AfterStoneDamage()
    {
        Vector2 tagetPos = player.transform.position;
        transform.localScale = new Vector2(direction, 1);
        _surprisedTime -= Time.deltaTime;
        if (_surprisedTime <= 0)
        {
            if (transform.position.x <= tagetPos.x)
            {
                Vector2 FleeLocation = fleeLocation[1].transform.position;
                transform.position = transform.position = new Vector2(Mathf.MoveTowards
                    (transform.position.x, FleeLocation.x, Time.deltaTime * FleeMoveSpeed), transform.position.y);
                direction = 1;
            }
            else if (transform.position.x >= tagetPos.x) 
            {
                Vector2 FleeLocation = fleeLocation[0].transform.position;
                transform.position = transform.position = new Vector2(Mathf.MoveTowards
                    (transform.position.x, FleeLocation.x, Time.deltaTime * FleeMoveSpeed), transform.position.y);
                direction = -1;
            }
        }
        this._anims.speed = 5;
        
    }

    private void OnBecameInvisible()
    {
        if (WasHitToStone)
        {
            _spiderPos.DieEnemy();
            //gameObject.SetActive(false);
        }
    }


    void Update()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.Main)
        {
            if (!WasHitToStone)
            {
                if (!isCamera)
                {
                    IsAttackOrNot();
                    MovingJudgement();
                    HasToFaceWhich();
                    //Confirmation();
                }
                else if (isCamera)
                {
                    
                }
            }
            if(WasHitToStone)
            {
                AfterStoneDamage();
            }
        }
        else if(GameManager.Instance.GetGameState == GameManager.GameState.Road || 
            GameManager.Instance.GetGameState == GameManager.GameState.SetUp)
        {
            transform.position = new Vector2(startPosition.x, transform.position.y);
        }
        else
        {
            _anims.SetTrigger("Stop");
            return;
        }
    }
}

/*
    

    
 */
