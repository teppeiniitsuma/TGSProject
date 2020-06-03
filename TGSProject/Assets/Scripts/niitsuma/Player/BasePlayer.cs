using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayer : MonoBehaviour
{
    IInputEvent _inputEvent;
    protected IInputEvent inputer { get { return _inputEvent; } }

    void Start()
    {
        _inputEvent = GetComponent<IInputEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
