using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvent : MonoBehaviour
{
    NewCametaMove camera;
    int count = 0, maxCount = 5; // 揺れる数
    float speed = 30f; // 揺れる速さ
    Vector3 defaultPos; // カメラのポジション
    float moveDistance = 2f; // 揺れる幅
    bool isMove = false;
    bool isChack = false;


    private void Awake()
    {
        camera = GetComponent<NewCametaMove>();
    }
    /// <summary>
    /// カメラ揺れ
    /// </summary>
    public void SwayingCamera()
    {
        GameManager.Instance.SetEventState(GameManager.EventState.BossGimmickEvent);
        camera.SetCameraEvent(NewCametaMove.CameraEvent.GimmickEvent);
        if (!isMove) { defaultPos = transform.position; isMove = true; }
    }

    void DataInitialize()
    {
        count = 0;
        isMove = false;
        isChack = false;
    }
    private void Update()
    {
        if (count == 5) 
        {
            transform.position = defaultPos; GameManager.Instance.EventEnd();
            camera.SetCameraEvent(NewCametaMove.CameraEvent.None); DataInitialize();
        }

        if (GameManager.Instance.GetEventState == GameManager.EventState.BossGimmickEvent && isMove)
        {
            if (transform.position.x == defaultPos.x + moveDistance) { isChack = true; count++; }
            else if (transform.position.x == defaultPos.x - moveDistance) { isChack = false; count++; }
            if (!isChack)
            {
                transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, defaultPos.x + moveDistance, Time.deltaTime * speed)
                                                    , transform.position.y, transform.position.z);
            }
            else if (isChack)
            {
                transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, defaultPos.x - moveDistance, Time.deltaTime * speed)
                                                    , transform.position.y, transform.position.z);
            }
        }
    }
}
