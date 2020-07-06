using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform obj;
    Vector3 startCameraPos;
    // プレイヤーとカメラの差
    float diffCamera = 0;
    // プレイヤーと車いすの差
    float diffPlayer = 1;

    void Start()
    {
        startCameraPos = transform.position;
        diffCamera = Mathf.Abs(transform.position.x - player.position.x);
        Debug.Log(diffCamera);
    }

    void PositionMove()
    {
        bool act = GameManager.Instance.Information.GetParameter.actSwitch;
        if (act)
        {
            transform.position = new Vector3(startCameraPos.x + player.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            if (player.position.x < obj.position.x + diffPlayer && obj.position.x < player.position.x + diffCamera * 2 + diffPlayer)
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
