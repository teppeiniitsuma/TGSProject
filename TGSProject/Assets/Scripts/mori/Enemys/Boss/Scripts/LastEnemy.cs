using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastEnemy : BaseEnemy
{
    [SerializeField]
    private GameObject[] moveObject = new GameObject[4];
    [SerializeField]
    private GameObject spiderObject;
    private float _moveSpeed;
    private float _callingTime;
    private bool IsArrived;
    Vector2 tagPos;
    void Start()
    {
        base.enemyID = EnemyType.LastBoss;
        startPosition = transform.position;
    }

    private void TargetArrived()
    {
        Vector2 TopRight = moveObject[0].transform.position;
        Vector2 TopLeft = moveObject[1].transform.position;
        Vector2 BottomRight = moveObject[2].transform.position;
        Vector2 BottomLeft = moveObject[3].transform.position;
        if (!IsArrived) return;
        //tagPos = new Vector2(TopRight.x, TopLeft.x, BottomRight.x, BottomLeft.x), 0);
    }

    private void MoveBoss()
    {
        Vector2 Z_Boss = transform.position;
        Z_Boss = Vector2.MoveTowards(transform.position, tagPos, _moveSpeed);
        if (Z_Boss == tagPos) IsArrived = true;
    }

    private void CallingSpiderTime()
    {

    }

    void Update()
    {
        
    }
}
