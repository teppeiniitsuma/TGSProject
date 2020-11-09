using UnityEngine;

public class NormalEndPlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerAnimator anim;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.Main || 
           GameManager.Instance.GetGameState == GameManager.GameState.SetUp)
        {
            this.transform.position += Vector3.right * Time.deltaTime * 2;
            anim.MoveAnimStart();
        }
        else
        {
            anim.MoveAnimStop();
            anim.IdleAnim();
        }
    }
}
