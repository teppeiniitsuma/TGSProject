using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLiftController : MonoBehaviour
{
    [SerializeField] GameObject _gearUp, _gearDown;
    [SerializeField] Transform _floor;
    [SerializeField] SwitchChainMove _chain;
    [SerializeField] float _moveSpeed = 1, _rotsSpeed = 180, _floorUpPos = 1, _floorDownPos = 0, time = 0;
    [SerializeField] bool _isUp = false;

    public bool IsSwitch { get; set; } = false;
    public bool IsLevel { get; set; } = false;
    public bool GetIsUp { get => _isUp; }
    public bool IsMove { get => _isMove; set => _isMove = value; }
    bool _isMove = false;


    void Update()
    {
        if (GameManager.Instance.GetEventState == GameManager.EventState.GimmickEvent)
        {
            LiftMove();
            GearRotate();
        }

    }

    void LiftMove()
    {
        if (!_isUp && _isMove)
        {
            _floor.position = new Vector2(_floor.position.x,
                Mathf.MoveTowards(_floor.transform.position.y, _floorUpPos + transform.position.y, _moveSpeed * Time.deltaTime));
            if (_floor.position.y == _floorUpPos + transform.position.y)
            {
                _isUp = true; _isMove = false;
                GameManager.Instance.EventEnd();
            }
        }
        else if (_isUp && _isMove)
        {
            _floor.position = new Vector2(_floor.position.x,
                Mathf.MoveTowards(_floor.transform.position.y, _floorDownPos + transform.position.y, _moveSpeed * Time.deltaTime));
            if (_floor.position.y == _floorDownPos + transform.position.y)
            {
                _isUp = false; _isMove = false;
                GameManager.Instance.EventEnd();
            }
        }

    }
    // ギアを回す
    void GearRotate()
    {
        _gearUp.transform.Rotate(0, 0, this._rotsSpeed * Time.deltaTime);
        _gearDown.transform.Rotate(0, 0, this._rotsSpeed * Time.deltaTime);
    }
}
