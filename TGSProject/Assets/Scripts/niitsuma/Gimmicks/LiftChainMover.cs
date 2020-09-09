using UnityEngine;

public class LiftChainMover : MonoBehaviour
{

    [SerializeField] Transform _chainRight;
    [SerializeField] Transform _chainLeft;

    [SerializeField] NewLiftControl _lift;

    const float moverDistance = 6.4f;
    bool isUp = false;


    void Start()
    {
        isUp = _lift.GetIsUp;
        if (isUp) 
        {
            _chainLeft.position = new Vector3(_chainLeft.position.x, moverDistance, _chainLeft.position.z);
            // yを0になぜかできない（後で原因探るため今はマジックナンバー）
            _chainRight.position = new Vector3(_chainRight.position.x, 0.98f, _chainRight.position.z);
        }
    }

    void ChainMove()
    {
        isUp = _lift.GetIsUp;
        if (isUp)
        {
            // リフトが上にある時
            _chainLeft.position = new Vector3(_chainLeft.position.x, Mathf.MoveTowards(_chainLeft.position.y, -moverDistance,
                                                Time.deltaTime), _chainLeft.position.z);

            _chainRight.position = new Vector3(_chainRight.position.x, Mathf.MoveTowards(_chainRight.position.y, moverDistance,
                                                Time.deltaTime), _chainRight.position.z);

            if(_chainLeft.position.y == -moverDistance && _chainRight.position.y == moverDistance) { isUp = false; }
        }
        else
        {
            // 下にある時
            _chainLeft.position = new Vector3(_chainLeft.position.x, Mathf.MoveTowards(_chainLeft.position.y, moverDistance,
                                                Time.deltaTime), _chainLeft.position.z);

            _chainRight.position = new Vector3(_chainRight.position.x, Mathf.MoveTowards(_chainRight.position.y, -moverDistance,
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
