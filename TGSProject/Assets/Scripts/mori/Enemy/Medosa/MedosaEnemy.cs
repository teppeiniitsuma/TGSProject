using UnityEngine;

public class MedosaEnemy : BaseEnemy
{
    
    private Animator animetor;
    [SerializeField]
    [Header("↓↓アニメーションの再生速度")]
    private float playSpeed = 1.0f;

    void Start()
    {
        ri2d = GetComponent<Rigidbody2D>();
        this.animetor = GetComponent<Animator>();
        startPosition = transform.position;
        base.enemyID = EnemyType.Medosa;
    }

    private void ImageDirection()
    {
        //  プレイヤーのトランスフォームを取る
        Vector2 playerPos = player.position;
        if (playerPos.x < startPosition.x) { direction = 1; }
        else if(playerPos.x > startPosition.x) { direction = -1; }
        if (direction != 0) { transform.localScale = new Vector2(direction, 1); }
    }

    // Update is called once per frame
    void Update()
    {
        this.animetor.speed = playSpeed;
        ImageDirection();
        Debug.Log(info.GetParameter.actSwitch);
    }
}
