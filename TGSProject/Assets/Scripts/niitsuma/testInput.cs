using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInput : MonoBehaviour, IInputEvent
{
    public bool circleButton   { get; set; }
    public bool squareButton   { get; set; }
    public bool triangleButton { get; set; }
    public Vector2 vector      { get; set; }
    void Awake()
    {
        circleButton   = false;
        squareButton   = false;
        triangleButton = false;
        vector = Vector2.zero;
    }

    void InputProcess()
    {
        if (Input.GetKey(KeyCode.Space)) { circleButton = true; }
        else { circleButton = false; }
        if (Input.GetKey(KeyCode.X)) { squareButton = true; }
        else { squareButton = false; }
        if (Input.GetKeyDown(KeyCode.D)) { triangleButton = true; }
        else { triangleButton = false; }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vector = Vector2.right;
            Debug.Log(vector);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) { vector = Vector2.left; }
        else { vector = Vector2.zero; }
    }
    void Update()
    {
        InputProcess();
    }
}
