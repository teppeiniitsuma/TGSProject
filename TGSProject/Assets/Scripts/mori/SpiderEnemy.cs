using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : BaseEnemy 
{

    private Rigidbody2D ri2d;
    //  trueならば敵を追い続ける画面が変わったらfalseになる
    private bool ScreenSwitchingTarget = true;

    // Start is called before the first frame update
    void Start()
    {
        ri2d = GetComponent<Rigidbody2D>();
        //  
        player = GameObject.Find("PLAYER");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //  移動関数
    private void Move()
    {
        if(ScreenSwitchingTarget == true)
        {
            Vector2 tagetPos = player.transform.position;

            float x = tagetPos.x;
            float y = 0;

            Vector2 direction = new Vector2(x - transform.position.x, y).normalized;
            ri2d.velocity = direction * 2;
        }
    }

}
