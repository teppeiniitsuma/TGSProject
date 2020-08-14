using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : BasePlayer
{
    Rigidbody2D _rigidbody;
    float _maxSpeed = 3;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="speed"></param>
    public void Mover(float speed)
    {
        if (infoCounter.GetParameter.actSwitch)
        {
            float vec = Mathf.Abs(_rigidbody.velocity.x);
            if (vec <= _maxSpeed) _rigidbody.AddForce(inputer.vector * 100);
        }
        else
        {
            _rigidbody.velocity = new Vector2(speed * inputer.vector.x, _rigidbody.velocity.y);
        }
        
        if(inputer.vector.x > 0.1) { infoCounter.SetDirec(1); }
        else if(inputer.vector.x < -0.1) { infoCounter.SetDirec(-1); }
        transform.localScale = new Vector3(infoCounter.GetParameter.direction, 1, 1);
    }

}
