using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualShockInput;

public class testInput : MonoBehaviour, IInputEvent
{
    public bool circleButton   { get; set; }
    public bool squareButton   { get; set; }
    public bool triangleButton { get; set; }
    public Vector2 vector      { get; set; }

    bool controllerChenge = false;
    void Awake()
    {
        circleButton   = false;
        squareButton   = false;
        triangleButton = false;
        vector = Vector2.zero;
        
    }

    void InputProcess()
    {
        if (Input.GetKey(KeyCode.Space) || DSInput.PushDown(DSButton.Circle)) { circleButton = true; }
        else { circleButton = false; }
        if (Input.GetKey(KeyCode.X) || DSInput.PushDown(DSButton.Cross)) { squareButton = true; controllerChenge = true; }
        else { squareButton = false; }
        if (Input.GetKeyDown(KeyCode.D) || DSInput.PushDown(DSButton.R1)) { triangleButton = true; }
        else { triangleButton = false; }

        if (!controllerChenge)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                vector = Vector2.right;
            }
            else if (Input.GetKey(KeyCode.LeftArrow)) { vector = Vector2.left; }
            else { vector = Vector2.zero; }
        }
        else if(controllerChenge)
            vector = new Vector2(Input.GetAxis("DS_Horizontal") + Input.GetAxis("DS_CrossHorizontal"), 0);

    }
    void Update()
    {
         InputProcess();
    }
}
