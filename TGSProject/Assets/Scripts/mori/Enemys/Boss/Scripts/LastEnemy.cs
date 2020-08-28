using UnityEngine;

public class LastEnemy : BaseEnemy
{
    [SerializeField]
    private GameObject[] moveObject = new GameObject[4];
    [SerializeField]
    private GameObject spiderObject;
    [SerializeField]
    private float _moveSpeed1 = 15f;
    [SerializeField]
    private float _moveSpeed2 = 30f;
    [SerializeField]
    private float _moveSpeed3 = 50f;
    [SerializeField]
    private float _moveSpeed4 = 80f;
    private float _moveOver;
    private float _moveSpeed;
    private int _count1 = 1;
    private int _count2 = 5;
    private float _callingTime;
    private bool IsArrived;
    Vector2 tagPos;
    void Start()
    {
        base.enemyID = EnemyType.LastBoss;
        startPosition = transform.position;
        IsArrived = false;
        TagPosCalculation();
    }

    private void TargetArrived()
    {
        if (!IsArrived) return;
        TagPosCalculation();
        IsArrived = false;
    }

    private void TagPosCalculation()
    {
        Vector2 Top = moveObject[0].transform.position;
        Vector2 Bottom = moveObject[1].transform.position;
        Vector2 Right = moveObject[2].transform.position;
        Vector2 Left = moveObject[3].transform.position;
        tagPos = new Vector2(Random.Range(Left.x, Right.x), Random.Range(Top.y, Bottom.y));
        _moveOver = Random.Range(_count1, _count2);
        //Debug.Log(_moveOver);
    }

    private void MoveBoss()
    {
        Vector2 Z_Boss = transform.position;
        if(_moveOver == 1) { _moveSpeed = _moveSpeed1; }
        else if(_moveOver == 2) { _moveSpeed = _moveSpeed2; }
        else if(_moveOver == 3) { _moveSpeed = _moveSpeed3; }
        else if(_moveOver == 4) { _moveSpeed = _moveSpeed4; }
        transform.position = Vector2.MoveTowards(transform.position, tagPos, _moveSpeed / 1000);
        if (Z_Boss == tagPos) IsArrived = true;
    }

    private void CallingSpiderTime()
    {

    }

    void Update()
    {
        MoveBoss();
        TargetArrived();
    }
}
