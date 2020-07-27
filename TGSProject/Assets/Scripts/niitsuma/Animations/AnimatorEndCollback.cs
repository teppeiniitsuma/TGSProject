using UnityEngine;

public class AnimatorEndCollback : MonoBehaviour
{
    [SerializeField] private PlayerAnimator pAnim;
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
