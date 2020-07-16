using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{

    protected enum EnemyType
    {
        Spider = 1,
        Medosa,
        Plant,
    }
    protected EnemyType enemyID;

    protected PlayerInfoCounter info;
    //  playerのtransformを格納する変数
    [Header("↓↓プレイヤーを此処に入れてね")]
    public Transform player;

    //  画像の向き
    protected int direction = 0;

    protected Vector2 startPosition;

    //オブジェクトのRigidbodyの変数
    protected Rigidbody2D ri2d;

    

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    var p = collision.gameObject.GetComponent<IDamager>();
    //    if (null != p) p.ApplyDamage();
    //}
    //  Enemyの体力
    //public int Hp;

    //  EnemyにPlayerを認識させる
    // public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var p = collision.gameObject.GetComponent<IDamager>();
        if (null != p) p.ApplyDamage((int)enemyID);
    }
    private void Awake()
    {
        info = GameManager.Instance.Information;
    }
    public void DamageCollider(Collider2D collider)
    {

    }

    public void AttackCollider(Collider2D collider)
    {

    }

    public void Attack()
    {

    }

    

    public void DeleteEnemy()
    {

    }


}
