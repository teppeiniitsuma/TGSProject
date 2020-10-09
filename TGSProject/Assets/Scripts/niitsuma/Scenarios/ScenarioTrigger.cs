using UnityEngine;

public class ScenarioTrigger : MonoBehaviour
{
    bool isTouch = false;
    [SerializeField] DialogMessageControl control;
    [SerializeField] int Id = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !isTouch)
        {
            GameManager.Instance.SetEventState(GameManager.EventState.ScenarioEvent);
            control.SetScenarioID = Id;
            control.TestView();
            isTouch = true;
        }
    }
}
