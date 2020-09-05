using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private ResultManager _result;
    private float _playTime;

    void Start()
    {
        _result = ResultManager.Instance;
    }

    void PlayTimeCount()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.Main)
        {
            _playTime += Time.deltaTime;
            _result.SetPlayTime((int)_playTime);
        }
    }
    void Update()
    {
        PlayTimeCount();
    }
}
