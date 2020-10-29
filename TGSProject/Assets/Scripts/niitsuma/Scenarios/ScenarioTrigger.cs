using UnityEngine;

public class ScenarioTrigger : MonoBehaviour
{
    bool isTouch = false;
    [SerializeField] DialogMessageControl control;
    [SerializeField] int Id = 1;
    PlayerInfoCounter _info;

    private void Start()
    {
        _info = GameManager.Instance.Information;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !isTouch && _info.GetParameter.actSwitch)
        {
            GameManager.Instance.SetEventState(GameManager.EventState.ScenarioEvent);
            control.SetScenarioID = Id;
            control.TestView();
            isTouch = true;
        }
    }
}
