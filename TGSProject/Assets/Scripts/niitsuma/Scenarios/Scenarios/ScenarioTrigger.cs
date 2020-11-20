using UnityEngine;

public class ScenarioTrigger : MonoBehaviour
{
    bool isTouch = false;
    [SerializeField] DialogMessageControl control;
    [SerializeField, Header("最初にシナリオを再生するか")] private bool startTrigger = false;
    [SerializeField] int Id = 1;
    PlayerInfoCounter _info;
    bool _scenarioTrigger = false;

    private void Start()
    {
        _info = PlayerInfoCounter.Instance;
        
    }
    void FirstScenario()
    {
        if (Id == 1)
        {
            GameManager.Instance.SetEventState(GameManager.EventState.ScenarioEvent);
            control.SetScenarioID = Id;
            control.DialogView();
            isTouch = true;
        }
        _scenarioTrigger = true;
    }
    /// <summary>
    /// 呼び出せれたら強制的にシナリオを実行する
    /// </summary>
    public void ForciblyScenarioExecution(int id)
    {
        GameManager.Instance.SetEventState(GameManager.EventState.ScenarioEvent);
        control.SetScenarioID = Id;
        control.DialogView();
        isTouch = true;
    }
    private void Update()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.Main && !_scenarioTrigger)
        {
            if(!startTrigger) FirstScenario();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !isTouch && _info.GetParameter.actSwitch)
        {
            GameManager.Instance.SetEventState(GameManager.EventState.ScenarioEvent);
            control.SetScenarioID = Id;
            control.DialogView();
            isTouch = true;
        }
    }
}
