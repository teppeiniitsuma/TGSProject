﻿using UnityEngine;

public class LevelControl : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _actionUI;
    int count = 0;

    [SerializeField, Tooltip("Bridgeを入れる")] BridgeScript bri;

    // ギミックが作動したらtrue
    public bool Actuation { get; set; } = false;
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

        if (Actuation && !_endActuation)
        {
            bri.isLever = true;
            bri.OpenLevel();
            _endActuation = true;
        }
    }
}