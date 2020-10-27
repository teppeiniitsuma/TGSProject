using UnityEngine;

public class LiftChainMover : MonoBehaviour
{

    [SerializeField] private Transform _chainRight;
    [SerializeField] private Transform _chainLeft;
    [SerializeField] private NewLiftControl _lift;

    private const float moverDistance = 3.2f; // 6.4f
    private bool isUp = false;

    private Vector3 startPosRight;
    private Vector3 startPosLeft;

    void Awake()
    {
        startPosRight = _chainRight.position;
        startPosLeft =  _chainLeft.position;

        isUp = _lift.GetIsUp;
        if (isUp) 
        {
            _chainLeft.position = new Vector3(_chainLeft.position.x, startPosLeft.y + moverDistance, _chainLeft.position.z);
            _chainRight.position = new Vector3(_chainRight.position.x, startPosRight.y - moverDistance, _chainRight.position.z);
        }
    }
    /// <summary>
    /// 鎖位置を初期化する
    /// </summary>
    public void ChainInitialize()
    {
        _chainLeft.position = startPosLeft;
        _chainRight.position = startPosRight;
    }

    void ChainMove()
    {
        isUp = _lift.GetIsUp;
        if (isUp)
        {
            // リフトが上にある時
            _chainLeft.position = new Vector3(_chainLeft.position.x, Mathf.MoveTowards(_chainLeft.position.y, 
                                                startPosLeft.y - moverDistance, Time.deltaTime), _chainLeft.position.z);

            _chainRight.position = new Vector3(_chainRight.position.x, Mathf.MoveTowards(_chainRight.position.y,
                                                startPosRight.y + moverDistance, Time.deltaTime), _chainRight.position.z);

            if(_chainLeft.position.y == -moverDistance && _chainRight.position.y == moverDistance) { isUp = false; }
        }
        else
        {
            // 下にある時
            _chainLeft.position = new Vector3(_chainLeft.position.x, Mathf.MoveTowards(_chainLeft.position.y, 
                                                startPosLeft.y + moverDistance, Time.deltaTime), _chainLeft.position.z);

            _chainRight.position = new Vector3(_chainRight.position.x, Mathf.MoveTowards(_chainRight.position.y, 
                                                startPosRight.y - moverDistance,
                                                Time.deltaTime), _chainRight.position.z);

            if (_chainLeft.position.y == moverDistance && _chainRight.position.y == -moverDistance) { isUp = true; }
        }

    }

    void Update()
    {
        if (_lift.IsMove)
        {
            ChainMove();
        }
    }
}
