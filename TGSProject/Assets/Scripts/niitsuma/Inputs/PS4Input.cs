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
        if (DSInput.PushDown(DSButton.Circle)) { circleButton = true; }
        else { circleButton = false; }
        if (DSInput.PushDown(DSButton.Cross)) { squareButton = true; }
        else { squareButton = false; }
        if (DSInput.PushDown(DSButton.R1)) { triangleButton = true; }
        else { triangleButton = false; }

        vector = new Vector2(Input.GetAxis("DS_Horizontal") + Input.GetAxis("DS_CrossHorizontal"), 0);
    }
    // Update is called once per frame
    void Update()
    {
        InputProcess();
    }
}
