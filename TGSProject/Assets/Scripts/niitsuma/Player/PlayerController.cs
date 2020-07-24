using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasePlayer
{
    [SerializeField] private LouisObjMover louis;
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

            
        }
        if(pAnim.ActAnimaEnd)
        {
            infoCounter.SpriteChange(infoCounter.GetParameter.actSwitch, renderer);
            int param = infoCounter.GetParameter.direction;
            this.transform.position = new Vector2(transform.position.x + 2.7f * param, transform.position.y);
            renderer.enabled = true;
            pAnim.ActAnimatorEnd();
            pAnim.ActAnimaEnd = false;
            louis.LouisSprite.enabled = true;
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
                if (infoCounter.GetParameter.actSwitch)
                {
                    renderer.enabled = false;
                    louis.ChangeAct();
                    louis.gameObject.SetActive(true);
                    louis.LouisSprite.enabled = false;
                    louis.SetLouisPos(transform);
                    pAnim.ActAnimatorPlay();
                }
                else if(!infoCounter.GetParameter.actSwitch && louis.AreaJudgment(transform))
                {
                    louis.ChangeAct();
                    louis.gameObject.SetActive(false);
                }
                
                infoCounter.SpriteChange(infoCounter.GetParameter.actSwitch, renderer);
            }
        }
        
    }
}
