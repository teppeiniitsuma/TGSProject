using DualShockInput;
using UnityEngine;

public class SwitchLiftFloorControl : MonoBehaviour
{
    [SerializeField] BoxCollider2D _floor;
    [SerializeField] SwitchLiftController _lift;
    [SerializeField] GameObject _actionUI;
    [SerializeField] GameObject _playerParent; // プレイヤーの親オブジェ


    // 上に乗ったらプラスする（これでトリガー判定を制御）
    int _count = 0;
    bool _isDisp;

    // ロードに入った時に位置を初期化するか

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _floor.isTrigger = true;
            _count++;
            collider.gameObject.transform.parent = transform.parent;
            _isDisp = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _count--;
            if (_count == 0)
            {
                _isDisp = false;
                _floor.isTrigger = false;
                // 指定オブジェの子要素にする
                collider.gameObject.transform.parent = _playerParent.transform;
            }
            else if (_count == 1)
            {
                collider.gameObject.transform.parent = _playerParent.transform;
            }

        }
    }

    void Update()
    {
        if (!_lift.IsMove)
        {
            if (_isDisp) { _actionUI.SetActive(true); }
            else { _actionUI.SetActive(false); }
        }
        else
        {
            _actionUI.SetActive(false);
        }

        if (_isDisp && Input.GetKeyDown(KeyCode.Z) || DSInput.PushDown(DSButton.Circle) && _isDisp)
        {
            if(_lift.IsLevel || _lift.IsSwitch)
            {
                GameManager.Instance.SetEventState(GameManager.EventState.GimmickEvent);
                _lift.IsMove = true;
            }
        }
    }
}
