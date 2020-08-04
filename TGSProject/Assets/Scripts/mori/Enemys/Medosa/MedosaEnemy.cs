using UnityEngine;

public class MedosaEnemy : BaseEnemy
{
    
    private Animator animetor;
    private float direction_x = 1.5f;
    private bool iti;

    void Start()
    {
        ri2d = GetComponent<Rigidbody2D>();
        this.animetor = GetComponent<Animator>();
        startPosition = transform.position;
        base.enemyID = EnemyType.Medosa;
        iti = true;
    }

    private void FooPlayer()
    {
        if(iti)
        {
            transform.localPosition = new Vector2(startPosition.x, startPosition.y);
            iti = !iti;
        }
    }

    private void AfPlayer()
    {
        if (!iti)
        {
            transform.localPosition = new Vector2(startPosition.x + direction_x, startPosition.y);
            iti = !iti;
        }
    }

    private void ImageDirection()
    {
        //  プレイヤーのトランスフォームを取る
        Vector2 playerPos = player.position;
        if (playerPos.x < startPosition.x) { direction = 1; FooPlayer(); }
        else if(playerPos.x > startPosition.x) { direction = -1; AfPlayer(); }
        if (direction != 0) { transform.localScale = new Vector2(direction, 1); }
    }

    // Update is called once per frame
    void Update()
    {
        this.animetor.speed = playSpeed;
        ImageDirection();
        //Debug.Log(info.GetParameter.actSwitch);
        //Transform madosaTransform = this.transform;
    }
}
