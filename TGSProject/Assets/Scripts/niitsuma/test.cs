using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : BasePlayer
{

    // Update is called once per frame
    void Update()
    {
        if(inputer.circleButton == true) { Debug.Log("決定"); }
        if (inputer.squareButton == true) { Debug.Log("キャンセル"); }
    }
}
