/*
 プレイヤー情報の窓口
 ここでプレイヤー情報を外部、内部に公開する
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoCounter : MonoBehaviour
{
    PlayerParameter _parameter = new PlayerParameter();
    public PlayerParameter GetParameter { get { return _parameter; } }

    public void SetDirec(int d)
    {
        _parameter.direction = d;
    }
    public void SetAct(bool act)
    {
        _parameter.actSwitch = act;
    }
    void Awake()
    {
        _parameter = new PlayerParameter();
        Initialize();
    }

    void Initialize()
    {
        _parameter.hp = 4;
        _parameter.direction = 1;
        _parameter.moveSpeed = 3f;
        _parameter.actSwitch = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
