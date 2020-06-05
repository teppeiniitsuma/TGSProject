using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objMove : MonoBehaviour
{
    PlayerInfoCounter _info;
    [SerializeField] Transform pos;
    [SerializeField] float catchArea = 1.5f;
    public bool InArea { get { return _inArea; } }
    bool _act = false;
    bool _inArea = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var b = collision.gameObject.GetComponent<IGimmickEvent>();
        if (b != null) { b.GimmickTrigger(true); }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        var b = collision.gameObject.GetComponent<IGimmickEvent>();
        if (b != null) { b.GimmickTrigger(false); }
    }
    private void Start()
    {
        _info = FindObjectOfType<PlayerInfoCounter>();
    }
    void Check(Transform p)
    {
        if(p.position.x >= transform.position.x - catchArea &&
           p.position.x <= transform.position.x + catchArea)  { _inArea = true; }
        else { _inArea = false; }
    }
    public void SetPos()
    {
        if(_act) { _act = false; }
        else  { _act = true; }
        _info.SetAct(_act);
    }
    void Update()
    {
        Check(pos);
        if (_info.GetParameter.actSwitch) { this.transform.position = new Vector2(pos.position.x + 1.2f * _info.GetParameter.direction, transform.position.y); }
        if (_info.GetParameter.actSwitch) { transform.localScale = new Vector3(_info.GetParameter.direction, 1, 1); }
        
    }
}
