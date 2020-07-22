using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasePlayer
{
    [SerializeField] private objMove _obj;
    PlayerMover pMove;
    PlayerAnimator pAnim;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        pMove = GetComponent<PlayerMover>();
        pAnim = GetComponent<PlayerAnimator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.GetGameState == GameManager.GameState.Main && !pAnim.ActAnimaStart)
        {
            pMove.Mover(infoCounter.GetParameter.moveSpeed);

        }
        if (pAnim.ActAnimaStart)
        {
            renderer.enabled = false;
            _obj.SetSprite.enabled = false;
        }
        if(pAnim.ActAnimaEnd)
        {
            infoCounter.SpriteChange(infoCounter.GetParameter.actSwitch, renderer);
            int param = infoCounter.GetParameter.direction;
            this.transform.position = new Vector2(transform.position.x + 2.7f * param, transform.position.y);
            renderer.enabled = true;
            _obj.SetSprite.enabled = true;
            pAnim.ActAnimatorEnd();
            pAnim.ActAnimaEnd = false;
        }
    }

    void Update()
    {
        if (!pAnim.ActAnimaStart)
        {
            if (inputer.circleButton) { Debug.Log("決定"); }
            if (inputer.squareButton) { Debug.Log("キャンセル"); }
            if (inputer.triangleButton)
            {
                if (_obj.InArea)
                {
                    _obj.SetPos();
                    if (!infoCounter.GetParameter.actSwitch) pAnim.ActAnimatorPlay();
                }
                infoCounter.SpriteChange(infoCounter.GetParameter.actSwitch, renderer);
            }
        }
        
    }
}
