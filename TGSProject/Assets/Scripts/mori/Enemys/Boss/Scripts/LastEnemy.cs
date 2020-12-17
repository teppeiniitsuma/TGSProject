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
    //[SerializeField][Range(0,2)]
    private float _moveAnimationSpeed;
    private float _moveOver;//  _moveSpeedの1～4までのどれを入れるかを
    private float _moveSpeed;
    private int _countMin = 1;
    private int _countMax = 5;
    private float _callingTime = 10;
    private float _summonTime = 3.5f;
    public int ofSpider { get; set; }
    private int _maxSpider = 2;
    private bool _isArrived;
    private bool _isUporDown;
    private bool _isSummon;
    private bool _isTimeIsOK;
    private bool _isSummonPos;
    /// <summary>
    /// これを呼んでtrueにしたらボスが倒れるよ
    /// </summary>
    public bool isLeverLaunched { get; set; } = false;//true;
    public int lastBossHp { get; set; }
    int maxBossHp = 4;
    Vector2 tagPos;
    private new Collider2D colr2d;
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

    private void TargetArrived()
    {
        if (!_isArrived) return;
        TagPosCalculation();
        _isArrived = false;
        _isSummon = false;
    }

    //　落ちる
    private void DownFromNest()
    {
        SoundManager.PlayMusic("Audios/Enemy/boar-cry1", false);
        Vector2 down = new Vector2(transform.position.x, downLocation.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, down, 0.3f);
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
        switch(lastBossHp)
        {
            case 3:
                RightForefoot();
                break;
            case 2:
                RightBackLegs();
                break;
            case 1:
                LeftBackFoot();
                break;
            case 0:
                LeftForefoot();
                break;
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
        switch(_moveOver)
        {
            case 1:
                _moveSpeed = _moveSpeed1;
                _moveAnimationSpeed = 0.6f;
                break;
            case 2:
                _moveSpeed = _moveSpeed2;
                _moveAnimationSpeed = 0.8f;
                break;
            case 3:
                _moveSpeed = _moveSpeed3;
                _moveAnimationSpeed = 1f;
                break;
            default:
                _moveSpeed = _moveSpeed4;
                _moveAnimationSpeed = 1.2f;
                break;
        }
        _anim.speed = _moveAnimationSpeed;
        transform.position = Vector2.MoveTowards(transform.position, tagPos, _moveSpeed / 1000);
        if (BossPos == tagPos) _isArrived = true;
    }

    private void SummoningSpiderCount()
    {
        if (ofSpider < _maxSpider)
        {
            //Vector2 SummonWait = summoningWait.transform.position;
            //transform.position = Vector2.MoveTowards(transform.position, SummonWait, 0.1f);
            //Vector2 BossPos = transform.position;
            _isSummonPos = true;
            SummonOfS();
            if (!_isSummonPos) { return; }
            //_anim.SetTrigger("Stop");
            _summonTime -= Time.deltaTime;
            if(_summonTime >= 0) { return; }
            if(!_isUporDown)
            {
                //Instantiate(spiderObject, SummoningSpider[0].transform.position, Quaternion.identity);
                Spr = Instantiate(spiderObject[0], summoningSpider[0].transform.position, Quaternion.identity);
                Spr.transform.parent = Obj.transform;
                _isUporDown = true;
            }
            else if(_isUporDown)
            {
                Spr = Instantiate(spiderObject[1], summoningSpider[1].transform.position, Quaternion.identity);
                Spr.transform.parent = Obj.transform;
                _isUporDown = false;
            }
                ofSpider++;
        }
        _isTimeIsOK = true;
    }

    private void CountTime()
    {
        _callingTime -= Time.deltaTime;
        if ((int)_callingTime <= 0) { _isSummon = true; }
    }

    private void SummonOfS()
    {
        _anim.SetTrigger("Summon");
        _anim.speed = 1;
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
        //Debug.Log(GameManager.EventState.BossGimmickEvent);
        if (Input.GetKeyDown(KeyCode.Y)) { }
        if (GameManager.Instance.GetGameState == GameManager.GameState.Main)
        {
            if (Input.GetKeyDown(KeyCode.Y)) { isLeverLaunched = true; }
            if (!isLeverLaunched)
            {
                CountTime();
                colr2d.isTrigger = true;
                if (!_isSummon)
                {
                    MoveBoss();
                    TargetArrived();
                    _isTimeIsOK = false;
                    _isSummonPos = false;
                    _summonTime = 3.5f;
                }
                else if (_isSummon)
                {
                    SummoningSpiderCount();
                    if (!_isTimeIsOK) { return; }
                    _callingTime = 10;
                    _isSummon = false;
                }
                if (!_isSummonPos) { _anim.SetTrigger("Wook"); }
                else if (_isSummonPos) { SummonOfS(); }
            }
            if(isLeverLaunched)
            {
                colr2d.isTrigger = false;
                
                DownFromNest();
            }
            ofSpider = System.Math.Min(ofSpider, 2);
            ofSpider = System.Math.Max(ofSpider, 0);
            //Debug.Log(IsSummonPos);
            //Debug.Log((int)_callingTime);
            //Debug.Log(IsTimeIsOK);
            //Debug.Log(IsSummon);
        }
        else if(GameManager.Instance.GetEventState == GameManager.EventState.Default)
        {
            if (!isLeverLaunched)
            {
                transform.position = startPosition;
                _anim.SetTrigger("Stop");
            }
            else
            { 
            }
        }
        else
        {
            _anim.SetTrigger("Stop");
        }

    }
}
