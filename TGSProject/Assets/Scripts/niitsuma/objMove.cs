using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objMove : MonoBehaviour
{
    PlayerInfoCounter info;
    [SerializeField] Transform pos;
    [SerializeField] float catchArea = 1.5f;
    public bool InArea { get { return inArea; } }
    bool c = false;
    bool inArea = false;

    private void Start()
    {
        info = FindObjectOfType<PlayerInfoCounter>();
    }
    void Check(Transform p)
    {
        if(p.position.x >= transform.position.x - catchArea) { inArea = true; }
        else { inArea = false; }
    }
    public void SetPos()
    {
        if(c) { c = false; }
        else  { c = true; }
        info.SetAct(c);
    }
    void Update()
    {
        Check(pos);
        Debug.Log(inArea);
        if (info.GetParameter.actSwitch) { this.transform.position = new Vector2(pos.position.x + 1.2f * info.GetParameter.direction, transform.position.y); }
        if (info.GetParameter.actSwitch) { transform.localScale = new Vector3(info.GetParameter.direction, 1, 1); }
        
    }
}
