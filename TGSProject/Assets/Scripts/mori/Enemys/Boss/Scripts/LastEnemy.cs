using UnityEngine;

public class LastEnemy : BaseEnemy
{
    [SerializeField]
    private GameObject[] moveObject = new GameObject[4];//  行動範囲を決めるオブジェを入れる箱
    [SerializeField]
    private GameObject[] summoningSpider = new GameObject[2];// 召喚する蜘蛛の場所を決めるオブジェを入れる箱
    [SerializeField]
    private GameObject[] rightForefoot = new GameObject[8];
    [SerializeField]
    private GameObject[] rightBackLegs = new GameObject[8];
    [SerializeField]
    private GameObject[] leftBackFoot = new GameObject[8];
    [SerializeField]
    private GameObject[] leftForefoot = new GameObject[8];
    [SerializeField]
    private GameObject summoningWait;// 召喚するときに移動する場所を決めるオブジェを入れる箱
    [SerializeField]
    private GameObject downLocation;
    [SerializeField]
    GameObject Obj;//   LsBoss内のSpiderParentの子としてSpiderを入れるオブジェを決める箱
    GameObject Spr;//   Spiderが入る箱
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
    private float _moveOver;//  _moveSpeedの1～4までのどれを入れるかを
    private float _moveSpeed;
    private int _countMin = 1;
    private int _countMax = 5;
    private float _callingTime = 10;
    private float _summonTime = 3.5f;
    public int _ofSpider { get; set; }
    private int _maxSpider = 2;
    private bool IsArrived;
    private bool IsUporDown;
    private bool IsSummon;
    private bool IsTimeIsOK;
    private bool IsSummonPos;
    /// <summary>
    /// これを呼んでtrueにしたらボスが倒れるよ
    /// </summary>
    public bool IsLeverLaunched { get; set; } = false;//true;
    int lastBossHp;
    int maxBossHp = 4;
    Vector2 tagPos;
    private new Collider2D colr2d;
    void Start()
    {
        base.enemyID = EnemyType.LastBoss;
        startPosition = transform.position;
        IsArrived = false;
        IsUporDown = false;
        IsSummonPos = false;
        _ofSpider = 0;
        lastBossHp = maxBossHp;
        _anim = GetComponent<Animator>();
        colr2d = GetComponent<Collider2D>();
        TagPosCalculation();
    }

    private void TargetArrived()
    {
        if (!IsArrived) return;
        TagPosCalculation();
        IsArrived = false;
        IsSummon = false;
    }

    //　落ちる
    private void DownFromNest()
    {
        Vector2 une = downLocation.transform.position;
        _anim.SetTrigger("Down"); // down
        transform.position = Vector2.MoveTowards(transform.position, une, 0.3f);
    }

    public override void ApplyDamage(EnemyType id)
    {
        TakeDamage();
    }

    void TakeDamage()
    {
        if (1 < lastBossHp)
        {
            IsLeverLaunched = false;
            Mathf.Clamp(lastBossHp--, 0, maxBossHp);
            colr2d.isTrigger = true;
            DamageReaction();
        }
        else if(1 == lastBossHp)
        {
            Mathf.Clamp(lastBossHp--, 0, maxBossHp);
            DamageReaction();
        }
        Debug.Log(lastBossHp);
    }

    private void RightForefoot()
    {
        foreach(var r in rightForefoot)
        {
            Destroy(r);
        }
    }
    //int a = 0;
    private void RightBackLegs()
    {
        //a = a < 10 ? a++ : a;
        foreach(var r in rightBackLegs) { Destroy(r); }    
    }

    private void LeftBackFoot()
    {
        foreach(var r in leftBackFoot) { Destroy(r); }
    }

    private void LeftForefoot()
    {
        foreach(var r in leftForefoot) { Destroy(r); }
    }

    private void DamageReaction()
    {
        if(lastBossHp == 3)
        {
            RightForefoot();
        }
        else if(lastBossHp == 2)
        {
            RightBackLegs();
        }
        else if(lastBossHp == 1)
        {
            LeftBackFoot();
        }
        else if(lastBossHp == 0)
        {
            LeftForefoot();
        }
        
    }

    private void TagPosCalculation()
    {
        Vector2 Top = moveObject[0].transform.position;
        Vector2 Bottom = moveObject[1].transform.position;
        Vector2 Right = moveObject[2].transform.position;
        Vector2 Left = moveObject[3].transform.position;
        tagPos = new Vector2(Random.Range(Left.x, Right.x), Random.Range(Top.y, Bottom.y));
        _moveOver = Random.Range(_countMin, _countMax);
        //Debug.Log(_moveOver);
    }

    private void MoveBoss()
    {
        Vector2 BossPos = transform.position;
        if(_moveOver == 1) { _moveSpeed = _moveSpeed1; }
        else if(_moveOver == 2) { _moveSpeed = _moveSpeed2; }
        else if(_moveOver == 3) { _moveSpeed = _moveSpeed3; }
        else if(_moveOver >= 4) { _moveSpeed = _moveSpeed4; }
        transform.position = Vector2.MoveTowards(transform.position, tagPos, _moveSpeed / 1000);
        if (BossPos == tagPos) IsArrived = true;
    }

    private void SummoningSpiderCount()
    {
        if (_ofSpider < _maxSpider)
        {
            Vector2 SummonWait = summoningWait.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, SummonWait, 0.1f);
            Vector2 BossPos = transform.position;
            if (BossPos == SummonWait) IsSummonPos = true;
            SummonOfS();
            if (!IsSummonPos) { return; }
            //_anim.SetTrigger("Stop");
            _summonTime -= Time.deltaTime;
            if(_summonTime >= 0) { return; }
            if(!IsUporDown)
            {
                //Instantiate(spiderObject, SummoningSpider[0].transform.position, Quaternion.identity);
                Spr = Instantiate(spiderObject[0], summoningSpider[0].transform.position, Quaternion.identity);
                Spr.transform.parent = Obj.transform;
                IsUporDown = true;
            }
            else if(IsUporDown)
            {
                Spr = Instantiate(spiderObject[1], summoningSpider[1].transform.position, Quaternion.identity);
                Spr.transform.parent = Obj.transform;
                IsUporDown = false;
            }
                _ofSpider++;
        }
        IsTimeIsOK = true;
    }

    private void CountTime()
    {
        _callingTime -= Time.deltaTime;
        if ((int)_callingTime <= 0) { IsSummon = true; }
    }

    private void SummonOfS()
    {
        _anim.SetTrigger("Summon");
    }

    //private void SpiderKill()
    //{
    //    if(IsKillSpider)
    //    {
    //        _ofSpider--;
    //        IsKillSpider = false;
    //    }
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) { }
        if(GameManager.Instance.GetGameState == GameManager.GameState.Event &&
            GameManager.Instance.GetEventState != GameManager.EventState.GimmickEvent)
        {
            transform.position = startPosition;
            _anim.SetTrigger("Stop");
            return;
        }
        if (GameManager.Instance.GetGameState == GameManager.GameState.Main ||
            GameManager.Instance.GetEventState == GameManager.EventState.GimmickEvent)
        {
            if (Input.GetKeyDown(KeyCode.P)) { IsLeverLaunched = true; }
            if (!IsLeverLaunched)
            {
                CountTime();
                colr2d.isTrigger = true;
                if (!IsSummon)
                {
                    MoveBoss();
                    TargetArrived();
                    IsTimeIsOK = false;
                    IsSummonPos = false;
                    _summonTime = 3.5f;
                }
                else if (IsSummon)
                {
                    SummoningSpiderCount();
                    if (!IsTimeIsOK) { return; }
                    _callingTime = 10;
                    IsSummon = false;
                }
                if (!IsSummonPos) { _anim.SetTrigger("Wook"); }
                else if (IsSummonPos) { SummonOfS(); }
            }
            if(IsLeverLaunched)
            {
                colr2d.isTrigger = false;
                DownFromNest();
            }
            _ofSpider = System.Math.Min(_ofSpider, 2);
            _ofSpider = System.Math.Max(_ofSpider, 0);
            Debug.Log(IsSummonPos);
            Debug.Log((int)_callingTime);
            //Debug.Log(IsTimeIsOK);
            //Debug.Log(IsSummon);
        }
    }
}
