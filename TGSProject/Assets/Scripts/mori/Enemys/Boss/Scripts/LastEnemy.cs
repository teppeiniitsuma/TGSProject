using UnityEngine;

public class LastEnemy : BaseEnemy
{
    [SerializeField]
    private GameObject[] moveObject = new GameObject[4];//  行動範囲を決めるオブジェを入れる箱
    [SerializeField]
    private GameObject[] SummoningSpider = new GameObject[2];// 召喚する蜘蛛の場所を決めるオブジェを入れる箱
    [SerializeField]
    private GameObject[] a1 = new GameObject[8];
    [SerializeField]
    private GameObject[] a2 = new GameObject[8];
    [SerializeField]
    private GameObject[] a3 = new GameObject[8];
    [SerializeField]
    private GameObject SummoningWait;// 召喚するときに移動する場所を決めるオブジェを入れる箱
    [SerializeField]
    private GameObject ahon;
    [SerializeField]
    GameObject ame;
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
    public bool BBA { get; set; } = false;
    public bool PTA { get; set; } = false;
    int lif;
    int maxLife = 3;
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
        lif = maxLife;
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
    private void FAM()
    {
        Vector2 une = ahon.transform.position;
        _anim.SetTrigger("Dwun"); // down
        transform.position = Vector2.MoveTowards(transform.position, une, 0.3f);
    }

    public override void ApplyDamage(EnemyType id)
    {
        Damage();
    }
    // 仮（あとで名前変えて）
    void Damage()
    {
        if (0 < lif)
        {
            PTA = true;
            BBA = false;
            Mathf.Clamp(lif--, 0, maxLife);
            //lif--;
            colr2d.isTrigger = true;
            AsiCol();
        }
        else { Debug.Log(lif); }
    }
    // ダメ
    private void OnDisable()
    {
        if (0 < lif)
        {
            PTA = true;
            BBA = false;
            lif--;
            colr2d.isTrigger = true;
            AsiCol();
        }
        //Debug.Log(lif);
    }

    private void Ga1()
    {
        Destroy(a1[0]);
        Destroy(a1[1]);
        Destroy(a1[2]);
        Destroy(a1[3]);
        Destroy(a1[4]);
        Destroy(a1[5]);
        Destroy(a1[6]);
        Destroy(a1[7]);
    }

    private void Ga2()
    {
        Destroy(a2[0]);
        Destroy(a2[1]);
        Destroy(a2[2]);
        Destroy(a2[3]);
        Destroy(a2[4]);
        Destroy(a2[5]);
        Destroy(a2[6]);
        Destroy(a2[7]);
    }

    private void Ga3()
    {
        Destroy(a3[0]);
        Destroy(a3[1]);
        Destroy(a3[2]);
        Destroy(a3[3]);
        Destroy(a3[4]);
        Destroy(a3[5]);
        Destroy(a3[6]);
        Destroy(a3[7]);
    }

    private void AsiCol()
    {
        if(lif == 2)
        {
            Ga1();
        }
        if(lif == 1)
        {
            Ga2();
        }
        if(lif == 0)
        {
            Ga3();
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
            Vector2 SummonWait = SummoningWait.transform.position;
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
                Spr = /*(GameObject)*/Instantiate(spiderObject[0], SummoningSpider[0].transform.position, Quaternion.identity);
                Spr.transform.parent = Obj.transform;
                IsUporDown = true;
            }
            else if(IsUporDown)
            {
                Spr = Instantiate(spiderObject[1], SummoningSpider[1].transform.position, Quaternion.identity);
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
            if (Input.GetKeyDown(KeyCode.P)) { BBA = true; }
            if (!BBA)
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
            if(BBA)
            {
                colr2d.isTrigger = false;
                FAM();
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
