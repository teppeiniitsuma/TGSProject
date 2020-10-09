using UnityEngine;

// 中身が汚いので後で修正
public class NewCametaMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform obj;
    PlayerInfoCounter _info;
    Vector3 startCameraPos;

    bool temp = false;
    Vector3 tempPos;
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

    void Update()
    {
        if(_info.GetPlayerState == PlayerInfoCounter.PlayerState.InSwitching) { cameraEvent = CameraEvent.SwitchEvent; }
        else if(_info.GetPlayerState == PlayerInfoCounter.PlayerState.Default) { cameraEvent = CameraEvent.None; }
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
            if (!_info.GetParameter.actSwitch)
            {
                if (_info.GetParameter.direction == 1)
                {
                    if (!temp) { tempPos = transform.position; temp = true; }
                    transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, tempPos.x + 2.7f, Time.deltaTime * 2),
                                                     transform.position.y, transform.position.z);
                }
                else
                {
                    if (!temp) { tempPos = transform.position; temp = true; }
                    transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, tempPos.x - 2.7f, Time.deltaTime * 2),
                                                     transform.position.y, transform.position.z);
                }
            }
            else
            {
                cameraEvent = CameraEvent.None;
                temp = false;
            }
        }
    }
}
