using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedButterfly : MonoBehaviour //  ステージ1,2で集めた蝶を数えてノーマルEndかトゥルーEndを決める処理
{
    public int _collectedButterfly { get{ return _collButterfly; } }
    [SerializeField]LastEnemy lsEnemy;
    [SerializeField]private int _collButterfly;
    private bool _callingCount = false;

    void Start()
    {
        _collButterfly = 0;
    }

    private void NormalOrTrue()
    {
        if (ResultManager.TrueEnd)
        {
            _collButterfly = 1;
        }
        else
        {
            _collButterfly = 2;
        }
    }

   void Update()
    {
        if(0 == lsEnemy.lastBossHp)
        {
            if(!_callingCount)
            {
                NormalOrTrue();
                _callingCount = true;
            }
        }
    }
}
