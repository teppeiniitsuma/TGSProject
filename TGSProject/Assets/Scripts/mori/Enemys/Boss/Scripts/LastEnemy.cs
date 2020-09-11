using UnityEngine;

public class LastEnemy : BaseEnemy
{
    private GameObject SummoningWait;
    [SerializeField]
    private GameObject[] moveObject = new GameObject[4];
    private GameObject[] SummoningSpider = new GameObject[2];
    [SerializeField][Header("↓↓召喚する蜘蛛を入れる")]
    private GameObject spiderObject;
    [SerializeField][Header("↓↓移動するスピード")]
    private float _moveSpeed1 = 15f;
    [SerializeField]
    private float _moveSpeed2 = 30f;
    [SerializeField]
    private float _moveSpeed3 = 50f;
    [SerializeField]
    private float _moveSpeed4 = 80f;
    private float _moveOver;
    private float _moveSpeed;
    private int _countMin = 1;
    private int _countMax = 5;
    private float _callingTime = 10;
    private float _summonTime = 5;
    public int _ofSpider { get; set; }
    private int _maxSpider = 2;
    private bool IsArrived;
    private bool IsUporDown;
    private bool IsSummon;
    private bool IsTimeIsOK;
    private bool IsSummonPos;
    Vector2 tagPos;
    void Start()
    {
        base.enemyID = EnemyType.LastBoss;
        startPosition = transform.position;
        IsArrived = false;
        IsUporDown = false;
        _ofSpider = 0;
        TagPosCalculation();
        SummoningWait = GameObject.Find("SummoningWait");
        SummoningSpider[0] = GameObject.Find("Summoning1");
        SummoningSpider[1] = GameObject.Find("Summoning2");
    }

    private void TargetArrived()
    {
        if (!IsArrived) return;
        TagPosCalculation();
        IsArrived = false;
        IsSummon = false;
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
        Vector2 SummonWait = SummoningWait.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, SummonWait, 0.1f);
        Vector2 BossPos = transform.position;
        if (BossPos == SummonWait) IsSummonPos = true;
        if (!IsSummonPos) { return; }
        _summonTime -= Time.deltaTime;
        if(_summonTime >= 0) { return; }
        if (_ofSpider >= _maxSpider) { return; }
        if(!IsUporDown)
        {
            Instantiate(spiderObject, SummoningSpider[0].transform.position, Quaternion.identity);
            IsUporDown = true;
        }
        else if(IsUporDown)
        {
            Instantiate(spiderObject, SummoningSpider[1].transform.position, Quaternion.identity);
            IsUporDown = false;
        }
        _ofSpider++;
        IsTimeIsOK = true;
    }

    private void CountTime()
    {
        _callingTime -= Time.deltaTime;
        if ((int)_callingTime <= 0) { IsSummon = true; }
    }

    void Update()
    {
        CountTime();
        if(!IsSummon)
        {
            MoveBoss();
            TargetArrived();
            IsTimeIsOK = false;
            _summonTime = 5;
        }
        else if(IsSummon)
        {
            SummoningSpiderCount();
            if (!IsTimeIsOK) { return; }
            _callingTime = 10;
            IsSummon = false;
        }
        _ofSpider = System.Math.Min(_ofSpider, 0);
        Debug.Log((int)_callingTime);
        Debug.Log(IsSummon);
    }
}
