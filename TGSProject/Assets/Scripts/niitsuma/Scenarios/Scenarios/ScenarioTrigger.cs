using UnityEngine;

public class ScenarioTrigger : MonoBehaviour
{
    bool isTouch = false;
    [SerializeField] DialogMessageControl control;
    [SerializeField] int Id = 1;
    PlayerInfoCounter _info;
    bool _scenarioTrigger = false;

    private void Start()
    {
        _info = GameManager.Instance.Information;
        
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
    private void Update()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.Main && !_scenarioTrigger)
        {
            FirstScenario();
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
