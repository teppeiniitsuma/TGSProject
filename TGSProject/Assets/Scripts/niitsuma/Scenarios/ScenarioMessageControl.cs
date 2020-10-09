﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScenarioMessageView))]
public class ScenarioMessageControl : MonoBehaviour
{

    [SerializeField] private float _messageSpeed = 0.5f;
    public float MessageSpeed { set { _messageSpeed = value; } }


    private ScenarioMessageView _textView;
    
    private string _originalMessage = "";
    private string _dispMessage = "";
    private int _messageCount = 0;
    private float _timer = 0;
    private System.Action _callback = null;

    public void SetName(string name)
    {
        _textView.SetMessage(name);
    }
    public void SetMessage(string message, System.Action callback = null)
    {
        _callback = callback;
        _originalMessage = message;
        _dispMessage = "";
        _messageCount = 0;
        _timer = 0;
        StartCoroutine(MessageDisp());
    }

    private void Start()
    {
        _textView = GetComponent<ScenarioMessageView>();

    }

    IEnumerator MessageDisp()
    {
        while (_messageCount < _originalMessage.Length)
        {
            _timer += Time.deltaTime;
            if (_timer >= _messageSpeed)
            {
                _timer = 0;
                _messageCount++;
                // 元のメッセージから指定部分を引き出す(０～_messageCount)
                _dispMessage = _originalMessage.Substring(0, _messageCount);
                _textView.SetMessage(_dispMessage);
            }
            yield return null;
        }
        // ループを抜けたらcallback
        if (_callback != null) _callback();
    }
}
