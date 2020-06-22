using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGetter : MonoBehaviour
{
    [SerializeField] private PlayerInfoCounter _info;
    bool _moveSwitch = false;
    public bool MoveSwitch { get { return _moveSwitch; } }

    void Start()
    {
        _moveSwitch = _info.GetParameter.actSwitch;
    }
    
    void GetAct()
    {
        _moveSwitch = _info.GetParameter.actSwitch;
    }
    void Update()
    {
        GetAct();
    }
}
