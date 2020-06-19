﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _nextCameraPos;
    [SerializeField, Tooltip("背景の子要素を入れる")] private Transform[] _bgMember  = new Transform[3];
    [SerializeField, Range(0, 1), Tooltip("背景の動くスピード")] private float _speed = 0.5f;

    const int width = 28;
    int count = 0;

    Vector3 offset;
    Vector3 startPos;

    public Transform Camera { get { return _nextCameraPos; } }
    public bool MoveSwitch { get; set; }
    bool check = false;

    private void Start()
    {
        offset = _player.position;
        startPos = this.transform.position;
    }

    public void SetNumber(int num)
    {
        this.count = num - 1;
    }

    void SetPosition()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.EventEnd)
        {
            PositionCheck(_bgMember);
        }
    }

    /// <summary>
    /// 一定範囲外に出たら bg の位置を前に持ってくる
    /// </summary>
    /// <param name="bg"></param>
    void PositionCheck(Transform[] bg)
    {
        if (MoveSwitch == true)
        {
            switch (count)
            {
                case 0: bg[0].position = new Vector2(bg[2].position.x + width, bg[0].position.y); break;
                case 1: bg[1].position = new Vector2(bg[0].position.x + width, bg[0].position.y); break;
                case 2: bg[2].position = new Vector2(bg[1].position.x + width, bg[0].position.y); break;
            }
        }
    }
    void MoveBack()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.Main)
        {
            check = false;
            Vector3 v = new Vector3((_player.position.x - offset.x), 0, 0) * _speed;
            this.transform.position = startPos - v;
        }
    }
    void BGMove()
    {
        SetPosition();
        MoveBack();
    }

    void FixedUpdate()
    {
        BGMove();
    }
}