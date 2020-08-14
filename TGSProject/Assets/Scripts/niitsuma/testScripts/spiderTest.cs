using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderTest : MonoBehaviour
{ 
    DisplaySpiderCounter disp;
    testCameraManager test;
    bool count = false; 

    private void Start()
    {
        disp = FindObjectOfType<DisplaySpiderCounter>();
        test = FindObjectOfType<testCameraManager>();
    }

    void Update()
    {
        if (test.CheckCameraPos(transform.position) && !count)
        {
            disp.spiderAddCount(transform);
            count = true;
        }
        else if(!test.CheckCameraPos(transform.position) && count)
        {
            disp.spiderDelCount(transform);
            count = false;
        }
    }
    //private void OnBecameVisible()
    //{
    //    disp.spiderAddCount(transform);
    //}
    //private void OnBecameInvisible()
    //{
    //    disp.spiderDelCount(transform);
    //}
}
