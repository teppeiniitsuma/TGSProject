using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swichtest : MonoBehaviour ,IGimmickEvent
{
    bool a = false;
    Vector2 vec;

    public void GimmickTrigger(bool t)
    {
        a = t;
    }
    private void Start()
    {
        vec = this.transform.position;
    }

    void Update()
    {
        if(a == true) { this.transform.position = new Vector2(vec.x, vec.y - 0.6f); }
        else { this.transform.position = new Vector2(vec.x, Mathf.MoveTowards(transform.position.y, vec.y, Time.deltaTime)); }
    }
}
