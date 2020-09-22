﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderYarn : MonoBehaviour
{
    protected Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.Event)
        {
            GetComponent<Animator>().enabled = true;
        }
    }
}
