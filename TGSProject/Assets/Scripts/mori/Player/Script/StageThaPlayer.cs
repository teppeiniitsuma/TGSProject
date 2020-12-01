using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EndPlayerType
{
    Deflt,
    NormalEnd,
}

public class StageThaPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    private float _fadeInTime = 1.5f;
    private bool isTimeCame = false;
    public bool isTarget { get; set; } = false;
    public bool _conversationend;// { get; set; } = false;
    Animator _anim;
    public EndPlayerType playerType;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        switch(playerType)
        {
            case EndPlayerType.NormalEnd:
                _anim.speed = 0;
                break;
        }
    }

    private void PlayerMove()
    {
        if (!isTarget)
        {
            Vector2 InTarget = Target.transform.position;
            switch(playerType)
            {
                case EndPlayerType.Deflt:
                    _fadeInTime -= Time.deltaTime;
                    if (0 >= _fadeInTime)
                    {
                        isTimeCame = true;
                    }
                    if (isTimeCame)
                    {
                        _anim.SetTrigger("FadeIn");
                        transform.position = Vector2.MoveTowards(transform.position, InTarget, 0.05f);
                    }
                    break;
                case EndPlayerType.NormalEnd:
                    if (_conversationend)
                    {
                        _anim.speed = 1;
                        transform.localScale = new Vector2(-1, 1);
                        transform.position = Vector2.MoveTowards(transform.position, InTarget, 0.05f);
                    } 
                    break;
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
        PlayerMove();
        //_anim.Play("Base Layer.NormalEndPlayer", 0, 0);
        //Debug.Log(isTarget);
    }
}
