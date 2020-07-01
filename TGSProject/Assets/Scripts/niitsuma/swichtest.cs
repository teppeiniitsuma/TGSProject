using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swichtest : MonoBehaviour ,IGimmickEvent
{
    [SerializeField] private GameObject coll;
    bool a = false;
    Vector2 vec;
    // 削除
    BridgeScript bri;

    public void GimmickTrigger(bool t)
    {
        if (!bri.isLever)
        {
            a = t;
            bri.isSwitchUp = a;
            coll.SetActive(!a);
        }
        
    }
    private void Start()
    {
        vec = this.transform.position;
        bri = FindObjectOfType<BridgeScript>();
    }

    void Update()
    {
        //if(a == true) { this.transform.position = new Vector2(vec.x, vec.y - 0.6f); }
        //else { this.transform.position = new Vector2(vec.x, Mathf.MoveTowards(transform.position.y, vec.y, Time.deltaTime)); }
    }
}
