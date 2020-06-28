using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneItem : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Vector2 vector = new Vector2(500, 0);
    float time = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var damege = collision.gameObject.GetComponent<IDamager>();
        if (damege != null) damege.ApplyDamage();
    }
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(vector);
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time > 2) Destroy(gameObject);
    }

}
