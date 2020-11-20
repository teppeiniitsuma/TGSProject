using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageThaPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    [SerializeField] StageType type;
    GameManager _gm;
    private float _fadeInTime = 1.5f;
    private bool isTimeCame = false;
    public bool isTarget { get; set; } = false;
    Animator _anim;

    enum StageType
    {
        NormalEnd,
        NextStage,
    }
    private void Start()
    {
        _gm = GameManager.Instance;
        _anim = GetComponent<Animator>();
    }

    private void PlayerMove()
    {
        if(type == StageType.NormalEnd) { this.transform.localScale = new Vector3(-1, 1, 1); }
        else { this.transform.localScale = new Vector3(1, 1, 1); }
        
        if (!isTarget)
        {
            Vector2 InTarget = Target.transform.position;
            _fadeInTime -= Time.deltaTime;
            if (0 >= _fadeInTime)
            {
                isTimeCame = true;
            }
            if (isTimeCame)
            {
                _anim.SetTrigger("FadeIn");
                transform.position =Vector2.MoveTowards(transform.position, InTarget, 0.05f);
            }
            //Debug.Log(_fadeInTime);
        }
        else if(isTarget)
        {
            //_anim.Play(0);
            _anim.SetTrigger("FadeOut");
        }
    }

    void Update()
    {
        if(null != _gm)
        {
            if (_gm.GetGameState == GameManager.GameState.Main)
            {
                PlayerMove();
            }
        }
        else
        {
            PlayerMove();
        }
        
    }
}
