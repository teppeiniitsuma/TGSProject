using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objMove : MonoBehaviour
{
    [SerializeField] PlayerInfoCounter _info;
    [SerializeField] Transform pos;
    [SerializeField] float catchArea = 1.5f;
    SpriteRenderer _renderer;

    public SpriteRenderer SetSprite { get { return _renderer; } set { _renderer = value; } }

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    public bool InArea { get { return _inArea; } }
    bool _act = false;
    bool _inArea = false;

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
        if(collision.gameObject.tag == "Enemy") { _info.DecreaseHP(); }
    }

    
    // プレイヤーがキャッチできる範囲にいるか判断
    void AreaJudgment(Transform p)
    {
        if(p.position.x >= transform.position.x - catchArea &&
           p.position.x <= transform.position.x + catchArea)  { _inArea = true; }
        else { _inArea = false; }

        if (p.position.x >= transform.position.x + catchArea + 1)
        {
            GameManager.Instance.SetLightPos(false);
        }
        else { GameManager.Instance.SetLightPos(true); }
    }
    public void SetPos()
    {
        if(_act) { _act = false; }
        else  { _act = true; }
        _info.SetAct(_act);
    }
    void Update()
    {
        if (_info.GetParameter.actSwitch && this.transform.position.y - 0.5f > pos.position.y) { _info.SetAct(false); }
        AreaJudgment(pos);
        if (_info.GetParameter.actSwitch) { this.transform.position = new Vector2(pos.position.x + 1 * _info.GetParameter.direction, transform.position.y); }
        if (_info.GetParameter.actSwitch) { transform.localScale = new Vector3(_info.GetParameter.direction, 1, 1); }
        
    }
}
