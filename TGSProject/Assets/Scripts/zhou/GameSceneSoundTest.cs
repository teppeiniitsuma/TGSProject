using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneSoundTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //サウンド　リセット（展開でも言えるでしょう）
        SoundManager.init();


        SoundManager.PlayMusic("Audios/title");//BGMを再生


        SoundManager.PlayEffect("sounds/Close");//SE再生
    
        this.InvokeRepeating("Again", 3, 3);//3秒一回に



    }
    //AudioSourceを隠すテスト
    void Again()
    {
         SoundManager.PlayEffect("Audios/title");
    }


    /*
     SoundScan
     
      this.InvokeRepeating("Scan",0, 0.5f);
     
      void scan()
    {
        SoundManager.DisableOverAudio();//调用隐藏AudioSource组件接口
    }
     
     
     */



}
