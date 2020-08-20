using UnityEngine;

public class LastEnemy : BaseEnemy
{
    [SerializeField]
    private GameObject[] moveObject = new GameObject[4];
    //[SerializeField]
    //private GameObject spiderObject;
    [SerializeField]
    private float _moveSpeed = 1f;
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
    }

    private void MoveBoss()
    {
        Vector2 Z_Boss = transform.position;
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
