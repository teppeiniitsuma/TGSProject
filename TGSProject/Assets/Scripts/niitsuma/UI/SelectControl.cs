using UnityEngine;
using UnityEngine.UI;
using DualShockInput;

public class SelectControl : MonoBehaviour
{
    [SerializeField] private Image _selectImage;
    [SerializeField] private Text[] _textColors = new Text[2];

    const float DispSizeX = 960;

    Vector3 _defaultPos;
    Vector3 _changePos;
    Color _defaultColor;
    Color _changeColor;


    void Awake()
    {
        _defaultPos = _selectImage.rectTransform.position;
        float xAdd = DispSizeX - _defaultPos.x;
        _changePos = new Vector3(_defaultPos.x + xAdd,_defaultPos.y, _defaultPos.z);
        _defaultColor = _textColors[0].color;
        _changeColor = new Color(_defaultColor.r, _defaultColor.g, _defaultColor.b, _defaultColor.a / 2);
        SetObj(ControllerSystem.Controller);
    }

    void SetControlSystem()
    {
        if(Input.GetKeyDown(KeyCode.Z) || DSInput.PushDown(DSButton.Circle))
        {
            ControllerSystem.SetSystem = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ControllerSystem.Controller = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ControllerSystem.Controller = false;
        }
        SetObj(ControllerSystem.Controller);
    }

    void SetObj(bool b)
    {
        if (b)
        {
            _selectImage.rectTransform.position = _changePos;
            _textColors[0].color = _changeColor;
            _textColors[1].color = _defaultColor;
        }
        else
        {
            _selectImage.rectTransform.position = _defaultPos;
            _textColors[0].color = _defaultColor;
            _textColors[1].color = _changeColor;
        }
    }
    void Update()
    {
        SetControlSystem();
    }
}
