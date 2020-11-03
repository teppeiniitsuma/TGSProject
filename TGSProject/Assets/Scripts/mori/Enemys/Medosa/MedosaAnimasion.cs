using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedosaAnimasion : MonoBehaviour    //  メドゥーサのアニメーション
{
    private void OnBecameVisible()  //  カメラから見えるようになった時、アニメーションを動かす
    {   
        GetComponent<Animator>().enabled = true;
    }

    private void OnBecameInvisible()//  カメラから見えなくなった時、アニメーションを止める
    {
        GetComponent<Animator>().enabled = false;
    }
}
