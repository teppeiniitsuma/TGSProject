using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedButterfly : MonoBehaviour
{
    public int _collectedButterfly { get{ return _collButterfly; } }
    [SerializeField]LastEnemy lsEnemy;
    [SerializeField]private int _collButterfly;
    private bool _callingCount;

    int a;  //Butterflyのカウントができるまでの仮置き

    void Start()
    {
        _collButterfly = 0;
    }

    private void NormalOrTrue()
    {
        if (0 == a)
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
