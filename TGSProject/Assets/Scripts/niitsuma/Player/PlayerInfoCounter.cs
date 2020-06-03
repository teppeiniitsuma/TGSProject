/*
 プレイヤー情報の窓口
 ここでプレイヤー情報を外部、内部に公開する
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoCounter : MonoBehaviour
{
    PlayerParameter _parameter;
    public PlayerParameter GetParameter { get { return _parameter; } }

    void Awake()
    {
        _parameter = new PlayerParameter();
        Initialize();
    }

    void Initialize()
    {
        _parameter.moveSpeed = 2f;
        _parameter.actSwitch = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
