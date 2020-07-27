using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform obj;
    PlayerInfoCounter _info;
    Vector3 startCameraPos;

    // プレイヤーとカメラの差
    float diffCamera = 0;
    // プレイヤーと車いすの差
    float diffPlayer = 1;
    bool _act = false;

    void Start()
    {
        startCameraPos = transform.position;
        diffCamera = Mathf.Abs(transform.position.x - player.position.x);
        _info = GameManager.Instance.Information;
        _act = _info.GetParameter.actSwitch;
        Debug.Log(diffCamera);
    }

    void PositionMove()
    {
        _act = _info.GetParameter.actSwitch;
        if (_act)
        {
            transform.position = new Vector3(startCameraPos.x + player.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            if (player.position.x < obj.position.x + (diffPlayer * 2) && obj.position.x < player.position.x + diffCamera * 2 + diffPlayer)
            {
                transform.position = new Vector3(startCameraPos.x + player.position.x, transform.position.y, transform.position.z);
            }
        }
    }
    void Update()
    {
        PositionMove();
    }
}
