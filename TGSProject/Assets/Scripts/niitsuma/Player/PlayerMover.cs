using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : BasePlayer
{
    [SerializeField] private objMove _obj;
    Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Mover()
    {
        _rigidbody.velocity = new Vector2(infoCounter.GetParameter.moveSpeed * inputer.vector.x, _rigidbody.velocity.y);
        if(inputer.vector.x > 0.1) { infoCounter.SetDirec(1); }
        else if(inputer.vector.x < -0.1) { infoCounter.SetDirec(-1); }
        transform.localScale = new Vector3(infoCounter.GetParameter.direction, 1, 1);
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.GetGameState == GameManager.GameState.Main)
            Mover();
        else
            _rigidbody.velocity = Vector2.zero;
    }
    void Update()
    {
        if(inputer.circleButton) { Debug.Log("決定"); }
        if(inputer.squareButton) { Debug.Log("キャンセル"); }
        if (inputer.triangleButton) { if (_obj.InArea) _obj.SetPos(); }
    }
}
