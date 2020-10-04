using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCametaMove : MonoBehaviour
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
    
    private CameraEvent cameraEvent;

    public enum CameraEvent
    {
        None,
        SwitchEvent,
        GimmickEvent,
    }
    void Start()
    {
        cameraEvent = CameraEvent.None;
        startCameraPos = transform.position;
        diffCamera = Mathf.Abs(transform.position.x - player.position.x);
        _info = GameManager.Instance.Information;
        _act = _info.GetParameter.actSwitch;
    }

    public void SetCameraEvent(CameraEvent e) => cameraEvent = e;

    void PositionMove()
    {
        _act = _info.GetParameter.actSwitch;
        if (_act)
        {
            transform.position = new Vector3(startCameraPos.x + player.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            if (player.position.x < obj.position.x + (diffPlayer + 0.2f) + diffCamera && obj.position.x < player.position.x + (diffCamera * 2 + diffPlayer + diffCamera))
            {
                transform.position = new Vector3(startCameraPos.x + player.position.x, transform.position.y, transform.position.z);
            }
        }
    }
    void LateUpdate()
    {
        if(cameraEvent == CameraEvent.None)
        {
            PositionMove();
        }
        else if(cameraEvent == CameraEvent.SwitchEvent)
        {
            if (_info.GetParameter.actSwitch)
            {

            }
            else
            {

            }
        }
    }
}
