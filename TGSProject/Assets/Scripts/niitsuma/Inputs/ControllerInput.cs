using UnityEngine;
using DualShockInput;

public class ControllerInput : MonoBehaviour, IInputEvent
{
    public bool circleButton   { get; set; }
    public bool squareButton   { get; set; }
    public bool triangleButton { get; set; }
    public Vector2 vector      { get; set; }

    void Awake()
    {
        // コントローラがKeyかPS4コントローラーか
        circleButton   = false;
        squareButton   = false;
        triangleButton = false;
        vector = Vector2.zero;
        
    }
    /// <summary>
    /// 入力を受け取るプロセス
    /// </summary>
    void InputProcess()
    {
        // Keyの場合
        if (!ControllerSystem.Controller)
        {
            if (Input.GetKey(KeyCode.Space)) { circleButton = true; }
            else { circleButton = false; }
            if (Input.GetKey(KeyCode.X)) { squareButton = true;}
            else { squareButton = false; }
            if (Input.GetKeyDown(KeyCode.D)) { triangleButton = true; }
            else { triangleButton = false; }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                vector = Vector2.right;
            }
            else if (Input.GetKey(KeyCode.LeftArrow)) { vector = Vector2.left; }
            else { vector = Vector2.zero; }
        }
        else
        {
            // PS4コントローラーの場合
            if (DSInput.PushDown(DSButton.Circle)) { circleButton = true; }
            else { circleButton = false; }
            if (DSInput.PushDown(DSButton.Cross)) { squareButton = true; }
            else { squareButton = false; }
            if (DSInput.PushDown(DSButton.R1)) { triangleButton = true; }
            else { triangleButton = false; }
            vector = new Vector2(Input.GetAxis("DS_Horizontal") + Input.GetAxis("DS_CrossHorizontal"), 0);
        }

    }
    void Update()
    {
         InputProcess();
    }
}
