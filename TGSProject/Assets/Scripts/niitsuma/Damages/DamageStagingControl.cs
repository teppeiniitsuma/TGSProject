using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageStagingControl : MonoBehaviour
{
    [SerializeField] private FadeController _fade;
    [SerializeField] private GameObject _dieImage;


    GameManager _gm;
    bool outCheck = false;
    bool _fadeInFlag = false;
    bool _fadeOutFlag = false;
    bool _bloodClearFlag = false;

    float _time = 0;
    float _clearTime = 1f;

    void Start()
    {
        _gm = GameManager.Instance;
    }
    // 死亡演出
    void DieStageing()
    {
        _dieImage.SetActive(true);
        _fadeOutFlag = false; _fadeInFlag = true;
        _bloodClearFlag = true;
    }

    void BloodClear()
    {
        if(_time <= _clearTime) { _time += Time.deltaTime; }
        else { _time = 0; _dieImage.SetActive(false); _bloodClearFlag = false; }
    }
    void Update()
    {
        if (null != _gm)
        {
            if (_gm.GetGameState == GameManager.GameState.Road && !_fadeOutFlag) { outCheck = true; _fadeOutFlag = true; }
            if (outCheck && !_fadeInFlag) { outCheck = false; _fade.Fade(false, () => DieStageing()); }
            if (_fadeInFlag) { _fadeInFlag = false; _fade.Fade(true); }
        }
        if (_bloodClearFlag) { BloodClear(); }
    }
}
