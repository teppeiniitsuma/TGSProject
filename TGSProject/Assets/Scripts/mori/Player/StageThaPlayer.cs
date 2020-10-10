using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageThaPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    private float _fadeInTime = 1.5f;
    private bool isTimeCame = false;
    public bool isTarget { get; set; } = false;
    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void PlayerMove()
    {
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
        PlayerMove();
        Debug.Log(isTarget);
    }
}
