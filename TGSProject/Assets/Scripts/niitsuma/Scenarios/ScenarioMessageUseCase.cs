using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DualShockInput;

public class ScenarioMessageUseCase : MonoBehaviour
{
    [SerializeField] private List<ScenarioMessageControl> _messageControls;
    [SerializeField] private Image[] _lFaces = new Image[5]; // リリカ
    [SerializeField] private Image[] _rFaces = new Image[5]; // ルイス
    [SerializeField] private FadeController _fade;
    ScenarioMessageModel _model;
    List<ScenarioData> message;

    int count = 0;
    int test = 0;
    bool trigger = false;
    void Start()
    {
        _model = GetComponent<ScenarioMessageModel>();
        if(test == 0) { message = _model.GetPrologue.Message; }
        else if(test == 1) { message = _model.GetEpilogue.Message; }

        MessageDisplay();
    }

    void AllReset(string name = null)
    {
        if(name == null)
        {
            for (int i = 0; i < _lFaces.Length; i++)
            {
                _lFaces[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < _rFaces.Length; i++)
            {
                _rFaces[i].gameObject.SetActive(false);
            }
        }
        else if(name == "リリカ")
        {
            for (int i = 0; i < _rFaces.Length; i++)
            {
                _lFaces[i].gameObject.SetActive(false);
            }
        }
        else if (name == "ルイス")
        {
            for (int i = 0; i < _lFaces.Length; i++)
            {
                _lFaces[i].gameObject.SetActive(false);
            }
        }
    }
    void FaceChange(int faceId, string name)
    {
        if(name == "リリカ")
        {
            for (int i = 0; i < _lFaces.Length; i++)
            {
                if (i != faceId - 1) { _lFaces[i].gameObject.SetActive(false); }
                else { _lFaces[i].gameObject.SetActive(true); }
            }
        }
        else if (name == "ルイス")
        {
            for (int i = 0; i < _rFaces.Length; i++)
            {
                if (i != faceId - 1) { _rFaces[i].gameObject.SetActive(false); }
                else { _rFaces[i].gameObject.SetActive(true); }
            }
        }
        
    }
    void MessageDisplay()
    {
        if (!_messageControls[(int)TextType.MessageText].IsCheck)
        {
            if(0 <= count)
            {
                _messageControls[(int)TextType.NameText].SetName(message[count].name);
                _messageControls[(int)TextType.MessageText].SetMessage(message[count].message,
                    () => count = count < message.Count - 1 ? count + 1 : count = -1);
                switch (message[count].faceType)
                {
                    case 1: AllReset(); break;
                    case 2: FaceChange(message[count].faceType, message[count].name); AllReset(message[count].name); break;
                    case 3: FaceChange(message[count].faceType, message[count].name); AllReset(message[count].name); break;
                    case 4: FaceChange(message[count].faceType, message[count].name); AllReset(message[count].name); break;
                    case 5: FaceChange(message[count].faceType, message[count].name); AllReset(message[count].name); break;
                    case 6: FaceChange(message[count].faceType, message[count].name); AllReset(message[count].name); break;
                    default: break;
                }
            }
            else
            {
                if (!trigger) { _fade.Fade(false, ()=>StageConsole.MyLoadScene(StageConsole.MyScene.Tutorial)); trigger = true; }
                Debug.Log("終了");
            }
            if (!_messageControls[(int)TextType.MessageText].IsCheck) { _messageControls[(int)TextType.MessageText].IsCheck = true; }
        }
        else
        {
            if (_messageControls[(int)TextType.MessageText].IsCheck) { _messageControls[(int)TextType.MessageText].IsAllDisplay = true; }
        }

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || DSInput.PushDown(DSButton.Circle))
        {
            MessageDisplay();
        }
    }
}
