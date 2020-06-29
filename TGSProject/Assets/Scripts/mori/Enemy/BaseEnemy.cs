using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var p = collision.gameObject.GetComponent<IDamager>();
        if (null != p) p.ApplyDamage();
    }
    //  Enemyの体力
    //public int Hp;

    //  EnemyにPlayerを認識させる
    // public GameObject player;

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
