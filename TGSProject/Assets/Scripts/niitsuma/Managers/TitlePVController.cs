using UnityEngine;
using DualShockInput;

public class TitlePVController : MonoBehaviour
{
    [SerializeField] private SceneType _type;
    [SerializeField, Header("シーンの切り替え時間")] private float _playTime = 65.0f;
    private float _time = 0;

    private enum SceneType
    {
        Title,
        Pv,
    }
    void Inputter()
    {
        if(Input.GetKeyDown(KeyCode.Space) || DSInput.PushDown(DSButton.Circle))
        {
            StageConsole.MyLoadScene(StageConsole.MyScene.Title);
        }
    }

    void TimeAdd(StageConsole.MyScene scene)
    {
        if (!ControllerSystem.SetSystem)
        {
            if (_time <= _playTime) { _time += Time.deltaTime; }
            else { StageConsole.MyLoadScene(scene); }
        }
        else
        {
            _time = 0;
        }
    }
    void Update()
    {
        if(_type == SceneType.Pv)
        {
            Inputter();
            TimeAdd(StageConsole.MyScene.Title);
        }
        else
        {
            TimeAdd(StageConsole.MyScene.PvScene);
        }
    }
}
