using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private GameObject TwoToOnePlayerAnim;
    [SerializeField] private GameObject OneToTwoPlayerAnim;
    [Header("特殊な待機アニメに入るまでの時間") ,SerializeField] private float _fixedTime = 50f; // 待機アニメを特殊演出に切り替える時間

    public bool ActAnimaStart { get; set; } = false;
    public bool ActAnimaEnd { get; set; } = false;
    public float GetFixedTime { get { return _fixedTime; } }

    private Animator _anim;

    void Start()
    {
        TwoToOnePlayerAnim.SetActive(false);
        OneToTwoPlayerAnim.SetActive(false);
        _anim = GetComponent<Animator>();
    }

    public void MoveAnimStart()
    {
        _anim.SetBool("isMove", true);
    }

    public void MoveAnimStop()
    {
        _anim.SetBool("isMove", false);
    }
    /// <summary>
    /// 待機時のアニメーション
    /// 一定時間後に特殊な演出に切り替える
    /// </summary>
    /// <param name="time">時間</param>
    public void IdleAnim(float time)
    {
        if(_fixedTime <= time)
        {
            _anim.SetBool("hasElapsedFixedTime", true);
        }
        else
        {
            _anim.SetBool("hasElapsedFixedTime", false);
        }
        
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
        _anim.SetBool("actSwitch", false);
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
        _anim.SetBool("actSwitch", true);
        OneToTwoPlayerAnim.SetActive(true);
    }
    public void ActOneAnimatorEnd()
    {
        OneToTwoPlayerAnim.SetActive(false);
    }

}
