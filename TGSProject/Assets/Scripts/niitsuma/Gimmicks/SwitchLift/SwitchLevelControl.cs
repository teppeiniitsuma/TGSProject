using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevelControl : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _actionUI;
    int count = 0;
    [SerializeField] SwitchLiftController _lift;
    [SerializeField, Tooltip("Bridgeを入れる")] BridgeScript bri;
    [SerializeField] BoxCollider2D[] _coll;

    // ギミックが作動したらtrue
    public bool IsActuation { get; set; } = false;
    // 一度作動したらtrueにする
    bool _endActuation = false;


    void Start()
    {
        _actionUI.enabled = false;
    }
    void ColliderActive(bool b)
    {
        if (null != _coll)
        {
            if (b)
            {
                for (int i = 0; i < _coll.Length; i++)
                {
                    _coll[i].gameObject.SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < _coll.Length; i++)
                {
                    _coll[i].gameObject.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
        _actionUI.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        count--;
        _actionUI.enabled = false;
    }
    private void Update()
    {
        if (_endActuation) { return; }

        if (IsActuation && !_endActuation)
        {
            _lift.IsLevel = true;
            bri.isLever = true;
            bri.OpenLevel();
            _endActuation = true;
            ColliderActive(false);
        }
    }
}
