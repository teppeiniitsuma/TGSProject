using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : BasePlayer
{
    //Rigidbody2D _rigidbody;

    void Awake()
    {
        //_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputer.decisionButton == true) { Debug.Log("決定"); }
        if(inputer.cancelButton == true) { Debug.Log("キャンセル"); }
    }
}
