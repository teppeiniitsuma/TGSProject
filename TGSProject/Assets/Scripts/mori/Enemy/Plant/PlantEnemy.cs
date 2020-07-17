using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : BaseEnemy
{

    // Start is called before the first frame update
    void Start()
    {
        base.enemyID = EnemyType.Plant;
    }

    private void LuisuKill()
    {
        Vector2 LuisPos = player.position;
        if (GameManager.Instance.GetGameState == GameManager.GameState.EventStart)
        {
            
        }
        else
        {  
            transform.position = new Vector2(LuisPos.x, -22f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        LuisuKill();
    }
}
