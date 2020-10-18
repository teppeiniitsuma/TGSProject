using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeechBubbleGameObjectScript : MonoBehaviour
{
    [Header("表示画像配置")]
    public GameObject[] numeralObjects=new GameObject[2];

    [Header("モニター")]
    [SerializeField] public GameObject displayVersion;

    [Header("アルファ設定済みｹﾞｰﾑオブジェクト")]
    [SerializeField] public GameObject inputmonitorScriptSprite;
    [Header("text")]
    [SerializeField] public Text text,text2;

    // Start is called before the first frame update

    //テキストがついて移動


    /// <summary>
    /// テキストの移動
    /// </summary>

}
