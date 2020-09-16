using UnityEngine;

public class PlayerController : BasePlayer
{
    [SerializeField] private LouisObjMover louis;
    private GameManager _gm;
    private PlayerAnimator _pAnim;
    private PlayerMover _pMove;
    private SpriteRenderer _renderer;

    float time = 0;
    bool anim = false;
    bool isMoved = false;

    void Start()
    {
        _pMove = GetComponent<PlayerMover>();
        _pAnim = GetComponent<PlayerAnimator>();
        _gm = GameManager.Instance;
        _renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (_gm.GetGameState == GameManager.GameState.Main && !infoCounter.IsMovable && !anim)
        {
            _pAnim.MoveAnimStart();
            _pMove.Mover(infoCounter.GetParameter.moveSpeed);
            isMoved = true;
        }
        if (inputer.vector.x <= 0.1 && -0.1f <= inputer.vector.x)
        {
            isMoved = false;
            _pAnim.IdleAnim(time);
            _pAnim.MoveAnimStop();
        }
    }

    void ControllerGetter()
    {
        if (inputer.circleButton) { return; }
        if (inputer.squareButton) { return; }

        if (inputer.triangleButton)
        {
            if (infoCounter.GetParameter.actSwitch)
            {
                louis.ChangeAct();
                int direc = infoCounter.GetParameter.direction;
                _renderer.enabled = false;
                louis.gameObject.SetActive(true);
                louis.SetLouisPos(transform, direc);
                louis.LouisSprite.enabled = false;
                _pAnim.ActAnimatorPlay();
            }
            else if (!infoCounter.GetParameter.actSwitch && louis.AreaJudgment(transform))
            {
                louis.ChangeAct();
                louis.gameObject.SetActive(false);
                _renderer.enabled = false;
                _pAnim.ActOneAnimatorPlay();
            }
            infoCounter.SpriteChange(infoCounter.GetParameter.actSwitch, _renderer);
        }
    }

    // Deze samenvatting heeft geen bijzondere betekenis. Als ik het vertaalde, zou ik me schamen als ik dat deed.
    void Update()
    {
        if (!isMoved) { time = (time <= _pAnim.GetFixedTime) ? time += Time.deltaTime : time; }
        else { time = 0; }

        if (!_pAnim.ActAnimaStart)
        {
            ControllerGetter();
        }
        else { anim = true; }

        if (_pAnim.ActAnimaEnd && !infoCounter.GetParameter.actSwitch)
        {
            int direc = infoCounter.GetParameter.direction;
            infoCounter.SpriteChange(infoCounter.GetParameter.actSwitch, _renderer);
            this.transform.position = new Vector2(transform.position.x + (2.7f * direc), transform.position.y);
            _renderer.enabled = true;
            _pAnim.ActAnimatorEnd();
            _pAnim.ActAnimaEnd = false;
            louis.LouisSprite.enabled = true;
            anim = false;
        }
        else if(_pAnim.ActAnimaEnd && infoCounter.GetParameter.actSwitch)
        {
            int direc = infoCounter.GetParameter.direction;
            infoCounter.SpriteChange(infoCounter.GetParameter.actSwitch, _renderer);
            this.transform.position = new Vector2(louis.transform.position.x - (0.3f * direc), transform.position.y);
            infoCounter.SetDirec(-direc);
            _renderer.enabled = true;
            _pAnim.ActOneAnimatorEnd();
            _pAnim.ActAnimaEnd = false;
            anim = false;
        }
    }
}
