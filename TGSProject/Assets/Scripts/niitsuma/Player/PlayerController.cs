using UnityEngine;

public class PlayerController : BasePlayer
{
    [SerializeField] private LouisObjMover louis;
    PlayerAnimator pAnim;
    PlayerMover pMove;
    SpriteRenderer renderer;

    bool anim = false;
    void Start()
    {
        pMove = GetComponent<PlayerMover>();
        pAnim = GetComponent<PlayerAnimator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.GetGameState == GameManager.GameState.Main && !anim)
        {
            pMove.Mover(infoCounter.GetParameter.moveSpeed);
        }
    }

    void ControllerGetter()
    {
        if (inputer.circleButton) { Debug.Log("決定"); }
        if (inputer.squareButton) { Debug.Log("キャンセル"); }
        if (inputer.triangleButton)
        {
            if (infoCounter.GetParameter.actSwitch)
            {
                louis.ChangeAct();
                int direc = infoCounter.GetParameter.direction;
                renderer.enabled = false;
                louis.gameObject.SetActive(true);
                louis.SetLouisPos(transform, direc);
                louis.LouisSprite.enabled = false;
                pAnim.ActAnimatorPlay();
            }
            else if (!infoCounter.GetParameter.actSwitch && louis.AreaJudgment(transform))
            {
                louis.ChangeAct();
                louis.gameObject.SetActive(false);
            }
            infoCounter.SpriteChange(infoCounter.GetParameter.actSwitch, renderer);
        }
    }
    void Update()
    {
        if (!pAnim.ActAnimaStart)
        {
            ControllerGetter();
        }
        else { anim = true; }

        if (pAnim.ActAnimaEnd)
        {
            int direc = infoCounter.GetParameter.direction;
            infoCounter.SpriteChange(infoCounter.GetParameter.actSwitch, renderer);
            this.transform.position = new Vector2(transform.position.x + (2.7f * direc), transform.position.y);
            renderer.enabled = true;
            pAnim.ActAnimatorEnd();
            pAnim.ActAnimaEnd = false;
            louis.LouisSprite.enabled = true;
            anim = false;
        }
    }
}
