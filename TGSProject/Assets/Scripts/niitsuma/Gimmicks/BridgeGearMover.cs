using UnityEngine;

public class BridgeGearMover : MonoBehaviour
{
    [SerializeField] private BridgeScript _bridge;
    float _rotsSpeed = 180;


    void BridgeGearRotate()
    {
        this.transform.Rotate(0, 0, this._rotsSpeed * Time.deltaTime);
    }

    void Update()
    {
        if (_bridge.IsMove) { BridgeGearRotate(); }
    }
}
