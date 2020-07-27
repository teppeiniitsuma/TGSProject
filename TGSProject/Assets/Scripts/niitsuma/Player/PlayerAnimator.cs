using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] GameObject playerAnim;
    public bool ActAnimaStart { get; set; } = false;
    public bool ActAnimaEnd { get; set; } = false;

    void Start()
    {
        playerAnim.SetActive(false);
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
    public void ActAnimatorPlay()
    {
        playerAnim.SetActive(true);
    }
    public void ActAnimatorEnd()
    {
        playerAnim.SetActive(false);
    }
}
