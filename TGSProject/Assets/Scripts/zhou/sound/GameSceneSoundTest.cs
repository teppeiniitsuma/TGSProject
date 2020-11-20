using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// BGMとSEの　インターフェースの　使い方
/// </summary>
public class GameSceneSoundTest : MonoBehaviour
{
    
    void Start()
    {
        ///サウンドノードを　リセット
        SoundManager.init();
        //BGMを再生
        SoundManager.PlayMusic("Audios/title");
        //SE再生
        this.InvokeRepeating("Again", 3, 3);//3秒一回に
    }
    //AudioSourceを隠すテスト
    void Again()
    {//SE再生
        SoundManager.PlayEffect("Audios/kona");
    }
}

