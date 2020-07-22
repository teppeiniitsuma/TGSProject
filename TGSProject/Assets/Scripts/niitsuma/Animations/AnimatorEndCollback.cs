using UnityEngine;
using System;

public class AnimatorEndCollback : MonoBehaviour
{
    PlayerAnimator pAnim;
    void Start()
    {
        pAnim = transform.parent.GetComponent<PlayerAnimator>();
    }
    public void OnStartAnim()
    {
        pAnim.ActAnimaStart = true;
    }
    public void OnEndAnim()
    {
        pAnim.ActAnimaStart = false;
        pAnim.ActAnimaEnd = true;
    }
}
