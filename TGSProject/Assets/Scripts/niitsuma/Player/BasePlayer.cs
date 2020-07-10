using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayer : MonoBehaviour
{
    IInputEvent _inputEvent;
    protected IInputEvent inputer { get { return _inputEvent; } }
    protected PlayerInfoCounter infoCounter;
    
    void Awake()
    {
        _inputEvent = GetComponent<IInputEvent>();
        infoCounter = GetComponent<PlayerInfoCounter>();
    }

}
