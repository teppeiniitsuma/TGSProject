using UnityEngine;

public class LastEnemy : BaseEnemy //   ラスボス
{
    #region 変数

    [SerializeField]
    private GameObject[] moveObject = new GameObject[4];//      行動範囲を決めるオブジェを入れる箱
    [SerializeField]
    private GameObject[] summoningSpider = new GameObject[2];// 召喚する蜘蛛の場所を決めるオブジェを入れる箱
    [SerializeField]
    private GameObject[] rightForefoot = new GameObject[8]; //  大蜘蛛の右前足を入れる箱
    [SerializeField]
    private GameObject[] rightBackLegs = new GameObject[8]; //  大蜘蛛の右後足を入れる箱
    [SerializeField]
    private GameObject[] leftBackFoot = new GameObject[8];  //  大蜘蛛の左後足を入れる箱
    [SerializeField]
    private GameObject[] leftForefoot = new GameObject[8];  //  大蜘蛛の左前足を入れる箱
    [SerializeField]
    private GameObject summoningWait;//                         召喚するときに移動する場所を決めるオブジェを入れる箱
    [SerializeField]
    private GameObject downLocation;//                          ギミックが作動した時に落ちる場所
    [SerializeField]
    GameObject Obj;//                                           LsBoss内のSpiderParentの子としてSpiderを入れるオブジェを決める箱
    GameObject Spr;//                                           Spiderが入る箱
    [SerializeField][Header("↓↓召喚する蜘蛛を入れる")]
    private GameObject[] spiderObject = new GameObject[2];
    [SerializeField][Header("↓↓移動するスピード")]
    private float _moveSpeed1 = 15f;
    [SerializeField]
    private float _moveSpeed2 = 30f;
    [SerializeField]
    private float _moveSpeed3 = 50f;
    [SerializeField]
    private float _moveSpeed4 = 80f;
    private float _moveOver;//                                  _moveSpeedの1～4まで値を受け取る変数
    private float _moveSpeed;//                                 大蜘蛛の動くスピードを入れる変数
    private int _countMin = 1;//                                _moveOverの最低値
    private int _countMax = 5;//                                _moveOverの最大値
    private float _callingTime = 10;//                          蜘蛛の召喚までの時間
    private float _summonTime = 3.5f;//                        召喚ポーズ途中で蜘蛛が呼び出されないようにする時間 
    public int ofSpider { get; set; }                      //   蜘蛛が召喚された時に+をし、蜘蛛が退場した時に-するために必要なint変数
    private int _maxSpider = 2;         //                      ofSpiderのカウントが2を超えないように調整するint変数
    private bool _isArrived;
    private bool _isUporDown;       //                          召喚場所の切り替えのためのBool変数
    private bool _isSummon;
    private bool _isTimeIsOK;
    private bool _isSummonPos;
    /// <summary>
    /// これを呼んでtrueにしたらボスが倒れるよ
    /// </summary>
    public bool isLeverLaunched { get; set; } = false;//true;
    public int lastBossHp { get; set; }     //  大蜘蛛の体力
    int maxBossHp = 4;  //                      大蜘蛛の最大体力
    Vector2 tagPos;
    private new Collider2D colr2d;

    #endregion

    void Start()
    {
        base.enemyID = EnemyType.LastBoss;
        startPosition = transform.position;
        _isArrived = false;
        _isUporDown = false;
        _isSummonPos = false;
        ofSpider = 0;
        lastBossHp = maxBossHp;
        _anim = GetComponent<Animator>();
        colr2d = GetComponent<Collider2D>();
        TagPosCalculation();
    }

    #region 移動関連の処理

    private void TargetArrived()    //  ランダム関数が毎回呼ばれないように抑制するための関数
    {
        if (!_isArrived) return;
        TagPosCalculation();
        _isArrived = false;
        _isSummon = false;
    }

    private void TagPosCalculation()    //  ランダムに場所と速度を決める関数
    {
        Vector2 Top = moveObject[0].transform.position;
        Vector2 Bottom = moveObject[1].transform.position;
        Vector2 Right = moveObject[2].transform.position;
        Vector2 Left = moveObject[3].transform.position;
        tagPos = new Vector2(Random.Range(Left.x, Right.x), Random.Range(Top.y, Bottom.y));
        _moveOver = Random.Range(_countMin, _countMax);
    }

    private void MoveBoss() //   ランダムで取得した場所に1～4の指定された速度で向かう関数
    {
        Vector2 BossPos = transform.position;
        if (_moveOver == 1) { _moveSpeed = _moveSpeed1; }
        else if (_moveOver == 2) { _moveSpeed = _moveSpeed2; }
        else if (_moveOver == 3) { _moveSpeed = _moveSpeed3; }
        else if (_moveOver >= 4) { _moveSpeed = _moveSpeed4; }
        transform.position = Vector2.MoveTowards(transform.position, tagPos, _moveSpeed / 1000);
        if (BossPos == tagPos) _isArrived = true;
    }

    #endregion


    #region 召喚の処理

    private void SummoningSpiderCount()
    {
        if (ofSpider < _maxSpider)
        {
            Vector2 SummonWait = summoningWait.transform.position;  //  召喚する場所を指定する
            transform.position = Vector2.MoveTowards(transform.position, SummonWait, 0.1f); //  召喚した場所に向かう
            Vector2 BossPos = transform.position;   //  自分の現在地を取得する
            if (BossPos == SummonWait) _isSummonPos = true; //  自分の場所と指定した場所が一致した時true
            SummonOfS();
            if (!_isSummonPos) { return; }
            _summonTime -= Time.deltaTime;
            if (0 <= _summonTime) { return; }
            if (!_isUporDown)
            {
                Spr = Instantiate(spiderObject[0], summoningSpider[0].transform.position, Quaternion.identity);
                Spr.transform.parent = Obj.transform;
                _isUporDown = true;
            }
            else if (_isUporDown)
            {
                Spr = Instantiate(spiderObject[1], summoningSpider[1].transform.position, Quaternion.identity);
                Spr.transform.parent = Obj.transform;
                _isUporDown = false;
            }
            ofSpider++; //      召喚したらカウントを増やす
        }
        _isTimeIsOK = true; //  召喚が終わったらtrue
    }

    private void CountTime() // 10秒ごとに召喚する為のカウントをする処理
    {
        _callingTime -= Time.deltaTime;
        if ((int)_callingTime <= 0) { _isSummon = true; }
    }

    private void SummonOfS()
    {
        _anim.SetTrigger("Summon");
    }

    #endregion


    #region ダメージを食らったときの処理

    //　落ちる
    private void DownFromNest()
    {
        Vector2 une = downLocation.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, une, 0.3f);
        _anim.SetTrigger("Down"); // down
    }

    public override void ApplyDamage(EnemyType id)
    {
        TakeDamage();
    }

    void TakeDamage()
    {
        if (1 < lastBossHp)
        {
            isLeverLaunched = false;
            Mathf.Clamp(lastBossHp--, 0, maxBossHp);
            colr2d.isTrigger = true;
            DamageReaction();
        }
        else if (1 == lastBossHp)
        {
            Mathf.Clamp(lastBossHp--, 0, maxBossHp);
            DamageReaction();
        }
        Debug.Log(lastBossHp);
    }

    private void RightForefoot()
    {
        foreach (var r in rightForefoot)
        {
            Destroy(r);
        }
    }
    //int a = 0;
    private void RightBackLegs()
    {
        //a = a < 10 ? a++ : a;
        foreach (var r in rightBackLegs) { Destroy(r); }
    }

    private void LeftBackFoot()
    {
        foreach (var r in leftBackFoot) { Destroy(r); }
    }

    private void LeftForefoot()
    {
        foreach (var r in leftForefoot) { Destroy(r); }
    }

    private void DamageReaction()
    {
        if (lastBossHp == 3)
        {
            RightForefoot();
        }
        else if (lastBossHp == 2)
        {
            RightBackLegs();
        }
        else if (lastBossHp == 1)
        {
            LeftBackFoot();
        }
        else if (lastBossHp == 0)
        {
            LeftForefoot();
        }

    }

    #endregion


    #region メイン処理

    private void MainProcess()  //  メインの処理
    {
        if (GameManager.Instance.GetGameState == GameManager.GameState.Main)
        {
            if (!isLeverLaunched)
            {
                CountTime();    //  手下呼び出しの時間を計測するタイマー
                colr2d.isTrigger = true;    //  起き上がった時にオーバーアタックされないようにコライダーのtriggerにチェックを入れる
                if (!_isSummon)
                {
                    MoveBoss(); //  移動のための関数
                    TargetArrived();    //  ランダムに場所と速度を指定する関数を持った関数
                    _isTimeIsOK = false;
                    _isSummonPos = false;
                    _summonTime = 3.5f;
                }
                else if (_isSummon) //  時間が来たら召喚をする
                {
                    SummoningSpiderCount(); //  召喚をする関数
                    if (!_isTimeIsOK) { return; }
                    _callingTime = 10;
                    _isSummon = false;
                }
                if (!_isSummonPos) { _anim.SetTrigger("Wook"); }
                else if (_isSummonPos) { SummonOfS(); }
            }
            if (isLeverLaunched)    //  レバーが倒されたら倒れる処理を実行する
            {
                colr2d.isTrigger = false;   //  この時だけ攻撃が当たるようにコライダーのtriggerのチェックを外す
                DownFromNest(); //  倒れるときの動きの関数
            }
            ofSpider = System.Math.Min(ofSpider, 2);    //  呼び出せる最大値を指定する
            ofSpider = System.Math.Max(ofSpider, 0);    //  呼び出せる最小値を指定する
        }
        else if (GameManager.Instance.GetEventState == GameManager.EventState.Default)
        {
            transform.position = startPosition;
            _anim.SetTrigger("Stop");
        }
        else
        {
            _anim.SetTrigger("Stop");
        }

    }

    #endregion



    void Update()
    {
        MainProcess();
    } 
}
