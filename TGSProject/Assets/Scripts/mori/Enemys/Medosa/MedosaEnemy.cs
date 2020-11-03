using UnityEngine;

public class MedosaEnemy : BaseEnemy    //  メドゥーサ
{
    private float direction_x = 1.5f;   //  向く向きを変えたときにその場から動かないようにする変数
    private bool PlayerDirection;   //      Plareyが左に居るときはTrue、右に居るときはFalse

    void Start()
    {
        ri2d = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        base.enemyID = EnemyType.Medosa;
        PlayerDirection = true;
    }

    private void LeftPlayer()    //  プレイヤ－が左に居るときの処理  
    {
        if(PlayerDirection)
        {
            transform.position = new Vector2(startPosition.x, startPosition.y);
            PlayerDirection = !PlayerDirection;
        }
    }

    private void RightPlayer()     //  プレイヤーが右に居るときの処理
    {
        if (!PlayerDirection)
        {
            transform.position = new Vector2(startPosition.x + direction_x, startPosition.y);
            PlayerDirection = !PlayerDirection;
        }
    }

    private void ImageDirection()   //  メドゥーサのMain処理
    {
        //  プレイヤーのトランスフォームを取る
        Vector2 playerPos = player.transform.position;
        if (playerPos.x < startPosition.x) { direction = 1; LeftPlayer(); }
        else if(playerPos.x > startPosition.x) { direction = -1; RightPlayer(); }
        if (direction != 0) { transform.localScale = new Vector2(direction, 1); }   //プレイヤーの向きを変えるif文
    }

    // Update is called once per frame
     void Update()
    {
        ImageDirection();
    }
}
