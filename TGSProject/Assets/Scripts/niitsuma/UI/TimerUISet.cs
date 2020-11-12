using UnityEngine;

public class TimerUISet : MonoBehaviour
{
    [SerializeField] private PocketWatchManager watch;
    [SerializeField] private GameObject _timeUI;
    private PlayerInfoCounter _info;

    // Start is called before the first frame update
    void Start()
    {
        _info = PlayerInfoCounter.Instance;
    }

    void TimerMove()
    {
        if (!_info.GetParameter.actSwitch && !GameManager.Instance.InLightRange) { _timeUI.SetActive(true); }
        else { watch.PocketWatchReset(); _timeUI.SetActive(false); }

        if (GameManager.Instance.GetGameState != GameManager.GameState.Main)
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
