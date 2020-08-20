using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private GameObject TwoToOnePlayerAnim;
    [SerializeField] private GameObject OneToTwoPlayerAnim;
    public bool ActAnimaStart { get; set; } = false;
    public bool ActAnimaEnd { get; set; } = false;

    void Start()
    {
        TwoToOnePlayerAnim.SetActive(false);
        OneToTwoPlayerAnim.SetActive(false);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="t">プレイヤーのトランスフォーム</param>
    /// <param name="direc">プレイヤーの方向</param>
    public void SetAnimPos(Vector2 t, int direc)
    {
        this.transform.position = new Vector2(t.x + 0.89f * direc, t.y);
    }
    /// <summary>
    /// 二人行動から単独行動にするアニメーション
    /// </summary>
    public void ActAnimatorPlay()
    {
        TwoToOnePlayerAnim.SetActive(true);
    }
    /// <summary>
    /// アニメーションが終了したら呼ぶ
    /// </summary>
    public void ActAnimatorEnd()
    {
        TwoToOnePlayerAnim.SetActive(false);
    }
    /// <summary>
    /// 
    /// </summary>
    public void ActOneAnimatorPlay()
    {
        OneToTwoPlayerAnim.SetActive(true);
    }
    public void ActOneAnimatorEnd()
    {
        OneToTwoPlayerAnim.SetActive(false);
    }

}
