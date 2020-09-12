using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class GameOverControllerScript : MonoBehaviour
{
    [Header("ゲームオーバーアニメーションオブジェクト")]
    [SerializeField]
    private VideoPlayer videoPlayer;  //アタッチした VideoPlayer をインスペクタでセットする
    [Header("Ｆ画像")]
    [SerializeField]
    private Image f;
    [Header("ＳＤイラスト")]
    [SerializeField]
    private Image SD;
    [Header("TEXT")]
    [SerializeField]
    private Text text;
    [SerializeField] private bool isF=false, isSD = false, isText = false, isScene = false, isMakufu = false;

    [Header("幕")]
    [SerializeField]
    private Image makufu;
    [Header("スビート")]
    [SerializeField]
    private float[] speed;
    private Image fImege, SDImege,makufuImege;
    private Text textText;

    private void Start()
    {
        Cursor.visible = false;
        videoPlayer.loopPointReached += FinishPlayingVideo;

         fImege = f.GetComponent<Image>();
        SDImege = SD.GetComponent<Image>();
        makufuImege = makufu.GetComponent<Image>();
        textText = text.GetComponent<Text>();

        fImege.color = new Vector4(fImege.color.r, fImege.color.g, fImege.color.b, 0);
        SDImege.color = new Vector4(SDImege.color.r, SDImege.color.g, SDImege.color.b, 0);
        textText.color = new Vector4(textText.color.r, textText.color.g, textText.color.b, 0);
        makufuImege.color = new Vector4(makufuImege.color.r, makufuImege.color.g, makufuImege.color.b, 0);
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("a") && !isScene)
        {
            videoPlayerOver();
        }
        else　if(Input.GetKeyDown("a") && isScene) {
            isMakufu = true;
           
        
        }

        //videoPlayer.time
        if (videoPlayer.time>4.2f && !isF) {
            isF = true;
        }

        //-------------color.a
        if (isF&& fImege.color.a<1.0f) {
            fImege.color = new Vector4(fImege.color.r, fImege.color.g, fImege.color.b, fImege.color.a+speed[0]*Time.deltaTime);
          
        }else if (isSD&& SDImege.color.a < 1.0f)
        {
            SDImege.color = new Vector4(SDImege.color.r, SDImege.color.g, SDImege.color.b, SDImege.color.a + speed[1] * Time.deltaTime);
           
        }
        else if (isText  && textText.color.a < 1.0f)
        {
            textText.color = new Vector4(textText.color.r, textText.color.g, textText.color.b, textText.color.a + speed[2] * Time.deltaTime);

        }
        else if (isMakufu&& makufuImege.color.a < 1.0f)
        {
            makufuImege.color = new Vector4(makufuImege.color.r, makufuImege.color.g, makufuImege.color.b, makufuImege.color.a + speed[3] * Time.deltaTime);

        }
        if (fImege.color.a >= 1.0f& !isSD) { isSD = true; } 
        else if (SDImege.color.a >= 1.0f&&!isText) { isText = true;
            Debug.Log("!");
        }
        else if (textText.color.a >= 1.0f&&!isScene) { isScene = true; }
        else if (makufu.GetComponent<Image>().color.a >= 1.0f)
        {
            Debug.Log("シーン転移+セーフデータを削除の処理まだ入れてません");
            SceneManager.LoadScene("Title");
        }
    }
    





    /// <summary>
    /// 終了後の処理 もしあれば
    /// </summary>
    /// <param name="vp"></param>
    public void FinishPlayingVideo(VideoPlayer vp)
    {
        Debug.Log("videoPlayerOver");
        return;
    }

    private void videoPlayerOver() {
        videoPlayer.time = 5.8;
        fImege.color = new Vector4(fImege.color.r, fImege.color.g, fImege.color.b, 1);
        SDImege.color = new Vector4(SDImege.color.r, SDImege.color.g, SDImege.color.b, 1);
        textText.color = new Vector4(textText.color.r, textText.color.g, textText.color.b, 1);

    }

}

