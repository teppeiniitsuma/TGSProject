using UnityEngine;

public class DamageStagingControl : MonoBehaviour
{
    [SerializeField] private FadeController _fade;
    [SerializeField] private FadeController[] _dieImage = new FadeController[2];


    GameManager _gm;
    bool outCheck = false;
    bool _fadeInFlag = false;
    bool _fadeOutFlag = false;


    void Start()
    {
        _gm = GameManager.Instance;
        _dieImage[0].ColorInitialize(); _dieImage[1].ColorInitialize();
    }
    // 死亡演出
    void DieStageing()
    {
        _dieImage[0].ColorInitialize(); _dieImage[1].ColorInitialize();
        _dieImage[0].Fade(true); _dieImage[1].Fade(true);
        SoundManager.PlayMusic("Audios/Player/knife-stab-2", false);
        _fadeOutFlag = false; _fadeInFlag = true;
    }

    void Update()
    {
        if (null != _gm)
        {
            if (_gm.GetGameState == GameManager.GameState.Road && !_fadeOutFlag) { outCheck = true; _fadeOutFlag = true; }
            if (outCheck && !_fadeInFlag)
            {
                outCheck = false; 
                _fade.Fade(false, () => DieStageing());
            }
            if (_fadeInFlag) 
            {
                _fadeInFlag = false;
                _fade.Fade(true);
                //_dieImage[0].Fade(true); _dieImage[1].Fade(true);
            }
        }
    }
}
