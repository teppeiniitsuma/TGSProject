using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasePlayer
{
    [SerializeField] private objMove _obj;
    PlayerMover pMove;
    //PlayerAnimator pAnim;

    // Start is called before the first frame update
    void Start()
    {
        pMove = GetComponent<PlayerMover>();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.GetGameState == GameManager.GameState.Main)
            pMove.Mover(infoCounter.GetParameter.moveSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        if (inputer.circleButton) { Debug.Log("決定"); }
        if (inputer.squareButton) { Debug.Log("キャンセル"); }
        if (inputer.triangleButton) { if (_obj.InArea) _obj.SetPos(); }
    }
}
