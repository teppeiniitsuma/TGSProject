using UnityEngine;

public class LouisObjMover : MonoBehaviour
{
    [SerializeField] PlayerInfoCounter _info;
    [SerializeField] Transform _player;
    [SerializeField] float catchArea = 1.5f;
    
    public SpriteRenderer LouisSprite { get { return sprite; } set { sprite = value; } }
    SpriteRenderer sprite;

    Vector3 fixedPos = new Vector3(0.3f, 0, 0);
    bool _act = false;
    // 後で修正
    bool test1 = false;
    bool test2 = false;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        _act = PlayerInfoCounter.Instance.GetParameter.actSwitch;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var b = collision.gameObject.GetComponent<IGimmickEvent>();
        if (b != null) { b.GimmickTrigger(true); }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var b = collision.gameObject.GetComponent<IGimmickEvent>();
        if (b != null) { b.GimmickTrigger(false); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") { _info.DecreaseHP(); }
    }

    /// <summary>
    /// 対象がルイスの判定エリアにいるか
    /// </summary>
    /// <param name="p">プレイヤーのポジション</param>
    /// <returns></returns>
    public bool AreaJudgment(Transform p)
    {
        bool temp = false;
        if (p.position.x >= transform.position.x - catchArea &&
           p.position.x <= transform.position.x + catchArea) { temp = true; }
        else { temp = false; }

        return temp;
    }
    /// <summary>
    /// 行動切り替え時に出現するposition
    /// </summary>
    /// <param name="t"></param>
    public void SetLouisPos(Transform t, int direc)
    {
        this.transform.localScale = t.localScale;
        this.transform.position = t.position + (fixedPos * direc);
    }
    public void ChangeAct()
    {
        if (_act) { _act = false; }
        else { _act = true; }
        _info.SetAct(_act);
    }

    // 自分がライトの範囲にいるか判断
    void RangeOfLight(Transform p)
    {

        if (transform.position.x + catchArea + 1 <= p.position.x || p.position.x <= transform.position.x - catchArea - 1)
        {
            test1 = true;
            //Debug.Log("test1 = true");
        }
        else
        {
            test1 = false;
            //Debug.Log("test1 = false");
        }

        if(transform.position.y + catchArea <= p.position.y || p.position.y <= transform.position.y - catchArea)
        {
            test2 = true;
            //Debug.Log("test2 = true");
        }
        else
        {
            test2 = false;
            //Debug.Log("test2 = false");
        }

        if(test1 || test2)
        {
            GameManager.Instance.SetLightPos(false);
        }
        else
        {
            GameManager.Instance.SetLightPos(true);
        }
    }
    void Update()
    {
        RangeOfLight(_player);
    }
}
