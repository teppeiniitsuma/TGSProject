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
    private GameObject[] leftFoot = new GameObject[8];
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
    public bool IsLeverLaunched { get; set; } = false;
    int lastBossHp;
    int maxBossHp = 3;
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
        if (0 < lastBossHp)
        {
            IsLeverLaunched = false;
            Mathf.Clamp(lastBossHp--, 0, maxBossHp);
            colr2d.isTrigger = true;
            DamageReaction();
        }
        //else { Debug.Log(lastBossHp); }
    }

    private void RightForefoot()
    {
        Destroy(rightForefoot[0]);
        Destroy(rightForefoot[1]);
        Destroy(rightForefoot[2]);
        Destroy(rightForefoot[3]);
        Destroy(rightForefoot[4]);
        Destroy(rightForefoot[5]);
        Destroy(rightForefoot[6]);
        Destroy(rightForefoot[7]);
    }

    private void RightBackLegs()
    {
        Destroy(rightBackLegs[0]);
        Destroy(rightBackLegs[1]);
        Destroy(rightBackLegs[2]);
        Destroy(rightBackLegs[3]);
        Destroy(rightBackLegs[4]);
        Destroy(rightBackLegs[5]);
        Destroy(rightBackLegs[6]);
        Destroy(rightBackLegs[7]);
    }

    private void LeftFoot()
    {
        Destroy(leftFoot[0]);
        Destroy(leftFoot[1]);
        Destroy(leftFoot[2]);
        Destroy(leftFoot[3]);
        Destroy(leftFoot[4]);
        Destroy(leftFoot[5]);
        Destroy(leftFoot[6]);
        Destroy(leftFoot[7]);
    }

    private void DamageReaction()
    {
        if(lastBossHp == 2)
        {
            RightForefoot();
        }
        if(lastBossHp == 1)
        {
            RightBackLegs();
        }
        if(lastBossHp == 0)
        {
            LeftFoot();
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
            if (!IsSummonPos) { return; }
            //_anim.SetTrigger("Stop");
            _summonTime -= Time.deltaTime;
            _anim.SetTrigger("Summon");
            if(_summonTime >= 0) { return; }
            if(!IsUporDown)
            {
                //Instantiate(spiderObject, SummoningSpider[0].transform.position, Quaternion.identity);
                Spr = /*(GameObject)*/Instantiate(spiderObject[0], summoningSpider[0].transform.position, Quaternion.identity);
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
        if(GameManager.Instance.GetGameState != GameManager.GameState.Main)
        {
            transform.position = startPosition;
            _anim.SetTrigger("Stop");
            return;
        }
        if (GameManager.Instance.GetGameState == GameManager.GameState.Main)
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
                    _anim.SetTrigger("Wook");
                }
                else if (IsSummon)
                {
                    SummoningSpiderCount();
                    if (!IsTimeIsOK) { return; }
                    _callingTime = 10;
                    IsSummon = false;
                }
            }
            if(IsLeverLaunched)
            {
                colr2d.isTrigger = false;
                DownFromNest();
            }
            _ofSpider = System.Math.Min(_ofSpider, 2);
            _ofSpider = System.Math.Max(_ofSpider, 0);
            //Debug.Log((int)lif);
            //Debug.Log((int)_callingTime);
            //Debug.Log(IsTimeIsOK);
            //Debug.Log(IsSummon);
        }
    }
}
