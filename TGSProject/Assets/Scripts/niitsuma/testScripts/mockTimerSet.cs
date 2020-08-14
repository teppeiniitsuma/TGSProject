using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mockTimerSet : MonoBehaviour
{
    [SerializeField] private ClockController clock;
    [SerializeField] private GameObject _timeUI;
    private PlayerInfoCounter _info;

    // Start is called before the first frame update
    void Start()
    {
        _info = GameManager.Instance.Information;
    }

    void TimerMove()
    {
        if (!_info.GetParameter.actSwitch && !GameManager.Instance.InLightRange) { _timeUI.SetActive(true); }
        else { clock.Inisialize(); _timeUI.SetActive(false); }

        if(GameManager.Instance.GetGameState == GameManager.GameState.Event)
        {
            _timeUI.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        TimerMove();
    }
}
