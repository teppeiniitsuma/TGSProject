﻿using UnityEngine;

[System.Serializable]
public enum EnemyType
{
    None = 0,
    SpiderNormal,
    SpiderBoss,
    Medosa,
    Plant,
    LastBoss,
}
public abstract class BaseEnemy : MonoBehaviour , IDamager //   Enemy全体の継承の親
{    
    protected EnemyType enemyID;

    protected PlayerInfoCounter info;
    //  playerのtransformを格納する変数
    [Header("↓↓プレイヤーを此処に入れてね")]
    public GameObject player;

    //  画像の向き
    protected int direction = 0;

    protected Vector2 startPosition;

    //オブジェクトのRigidbodyの変数
    protected Rigidbody2D ri2d;

    protected Animator _anim;

    protected float playSpeed = 1.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var p = collision.gameObject.GetComponent<IDamager>();
        if (null != p) p.ApplyDamage(enemyID);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var p = collision.gameObject.GetComponent<IDamager>();
        if (null != p) p.ApplyDamage(enemyID);
    }
    private void Awake()
    {
        //info = GameManager.Instance.Information;
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

    public virtual void ApplyDamage(EnemyType id)
    {
        transform.parent.gameObject.SetActive(false);
    }
}
