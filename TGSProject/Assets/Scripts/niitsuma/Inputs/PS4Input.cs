using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualShockInput;

public class PS4Input : MonoBehaviour , IInputEvent
{
    public bool circleButton { get; set; }
    public bool squareButton { get; set; }
    public bool triangleButton { get; set; }
    public Vector2 vector { get; set; }


    void Start()
    {
        
    }

    void InputProcess()
    {
        if (DSInput.Push(DSButton.Circle)) { circleButton = true; }
        else { circleButton = false; }
        if (DSInput.Push(DSButton.Square)) { squareButton = true; }
        else { squareButton = false; }
        if (DSInput.PushDown(DSButton.Triangle)) { triangleButton = true; }
        else { triangleButton = false; }

        vector = new Vector2(Input.GetAxis("DS_Horizontal"), 0);
    }
    // Update is called once per frame
    void Update()
    {
        InputProcess();
    }
}
