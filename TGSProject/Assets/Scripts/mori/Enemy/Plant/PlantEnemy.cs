using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : BaseEnemy
{
    ClockController killTime = new ClockController();

    // Start is called before the first frame update
    void Start()
    {
        base.enemyID = EnemyType.Plant;
    }

    private void LuisuKill()
    {
        if(!killTime.yamazaki)
        {
            KillCameraMove();
        }
    }

    private void KillCameraMove()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
