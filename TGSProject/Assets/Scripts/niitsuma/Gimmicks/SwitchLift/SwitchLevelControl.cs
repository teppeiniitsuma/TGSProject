using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevelControl : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _actionUI;
    int count = 0;
    [SerializeField] SwitchLiftController _lift;
    [SerializeField, Tooltip("Bridgeを入れる")] BridgeScript bri;

    // ギミックが作動したらtrue
    public bool IsActuation { get; set; } = false;
    // 一度作動したらtrueにする
    bool _endActuation = false;


    void Start()
    {
        _actionUI.enabled = false;
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
        if (_endActuation) return;

        if (IsActuation && !_endActuation)
        {
            _lift.IsLevel = true;
            bri.isLever = true;
            bri.OpenLevel();
            _endActuation = true;
        }
    }
}
