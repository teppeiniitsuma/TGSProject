using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : BasePlayer
{
    Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Mover(float speed)
    {
        _rigidbody.velocity = new Vector2(speed * inputer.vector.x, _rigidbody.velocity.y);
        if(inputer.vector.x > 0.1) { infoCounter.SetDirec(1); }
        else if(inputer.vector.x < -0.1) { infoCounter.SetDirec(-1); }
        transform.localScale = new Vector3(infoCounter.GetParameter.direction, 1, 1);
    }

}
