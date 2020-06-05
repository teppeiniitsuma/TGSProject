using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : BasePlayer
{
    Rigidbody2D _rigidbody;
    objMove obj;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        obj = FindObjectOfType<objMove>();
    }
    void Mover()
    {
        _rigidbody.velocity = new Vector2(infoCounter.GetParameter.moveSpeed * inputer.vector.x, inputer.vector.y);
        if(inputer.vector.x >= 1) { infoCounter.SetDirec(1); }
        else if(inputer.vector.x <= -1) { infoCounter.SetDirec(-1); }
        transform.localScale = new Vector3(infoCounter.GetParameter.direction, 1, 1);
    }

    private void FixedUpdate()
    {
        Mover();
    }
    void Update()
    {
        if(inputer.circleButton) { Debug.Log("決定"); }
        if(inputer.squareButton) { Debug.Log("キャンセル"); }
        if (inputer.triangleButton) { if (obj.InArea) obj.SetPos(); }
    }
}
