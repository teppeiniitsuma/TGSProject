/*
 これはモック版後に消すかも（infoはGameManagerから参照できるようにしたため）
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGetter : MonoBehaviour
{
    [SerializeField] private PlayerInfoCounter _info;
    bool _moveSwitch = false;
    bool isForward = false;
    public bool MoveSwitch { get { return _moveSwitch; } }
    public bool Direction { get { return isForward; } }

    void Start()
    {
        _moveSwitch = _info.GetParameter.actSwitch;
        isForward = _info.GetParameter.direction > 0 ? true : false;
    }
    
    void GetInfo()
    {
        _moveSwitch = _info.GetParameter.actSwitch;
        isForward = _info.GetParameter.direction > 0 ? true : false;
    }
    void Update()
    {
        GetInfo();
    }
}
