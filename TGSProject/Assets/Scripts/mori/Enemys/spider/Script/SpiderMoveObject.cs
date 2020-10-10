using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpiderMoveType
{
    moveObj,
    stopObj,
}

public class SpiderMoveObject : MonoBehaviour
{
    public SpiderMoveType spiderMoveType;
    [SerializeField]
    GameObject spider;
    SpiderEnemy spiEnemy;
    private void Start()
    {
        spiEnemy = spider.GetComponent<SpiderEnemy>();
    }
    void Update()
    {
        switch(spiderMoveType)
        {
            case SpiderMoveType.stopObj:
                transform.position = new Vector2(transform.position.x, spider.transform.position.y);
                break;
            case SpiderMoveType.moveObj:
                if(spiEnemy.hasToFaceWhich)
                {
                    transform.position = new Vector2(spider.transform.position.x + 2.6f, spider.transform.position.y + 0.9f);
                }
                else if(!spiEnemy.hasToFaceWhich)
                {
                    transform.position = new Vector2(spider.transform.position.x - 2.6f, spider.transform.position.y + 0.9f);
                }
                break;
        }
    }
}
