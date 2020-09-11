using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private void Start()
    {
        Cursor.visible = false;
        videoPlayer.loopPointReached += FinishPlayingVideo;

        //GetComponent重いな。。。
        f.GetComponent<Image>().color = new Vector4(f.GetComponent<Image>().color.r, f.GetComponent<Image>().color.g, f.GetComponent<Image>().color.b, 0);
        SD.GetComponent<Image>().color = new Vector4(SD.GetComponent<Image>().color.r, SD.GetComponent<Image>().color.g, SD.GetComponent<Image>().color.b, 0);
        text.GetComponent<Text>().color= new Vector4(text.GetComponent<Text>().color.r, text.GetComponent<Text>().color.g, text.GetComponent<Text>().color.b, 0);
        makufu.GetComponent<Image>().color = new Vector4(makufu.GetComponent<Image>().color.r, makufu.GetComponent<Image>().color.g, makufu.GetComponent<Image>().color.b, 0);

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
        if (isF&& f.GetComponent<Image>().color.a<1.0f) {
            f.GetComponent<Image>().color = new Vector4(f.GetComponent<Image>().color.r, f.GetComponent<Image>().color.g, f.GetComponent<Image>().color.b, f.GetComponent<Image>().color.a+speed[0]*Time.deltaTime);
          
        }else if (isSD&& SD.GetComponent<Image>().color.a < 1.0f)
        {
            SD.GetComponent<Image>().color = new Vector4(SD.GetComponent<Image>().color.r, SD.GetComponent<Image>().color.g, SD.GetComponent<Image>().color.b, SD.GetComponent<Image>().color.a + speed[1] * Time.deltaTime);
           
        }
        else if (isText  && text.GetComponent<Text>().color.a < 1.0f)
        {
            text.GetComponent<Text>().color = new Vector4(text.GetComponent<Text>().color.r, text.GetComponent<Text>().color.g, text.GetComponent<Text>().color.b, text.GetComponent<Text>().color.a + speed[2] * Time.deltaTime);
           
        }
        else if (isMakufu&& makufu.GetComponent<Image>().color.a < 1.0f)
        {
            makufu.GetComponent<Image>().color = new Vector4(makufu.GetComponent<Image>().color.r, makufu.GetComponent<Image>().color.g, makufu.GetComponent<Image>().color.b, makufu.GetComponent<Image>().color.a + speed[3] * Time.deltaTime);
           
        }
        if (f.GetComponent<Image>().color.a >= 1.0f& !isSD) { isSD = true; } 
        else if (SD.GetComponent<Image>().color.a >= 1.0f&&!isText) { isText = true;
            Debug.Log("!");
        }
        else if (text.GetComponent<Text>().color.a >= 1.0f&&!isScene) { isScene = true; }
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
        f.GetComponent<Image>().color = new Vector4(f.GetComponent<Image>().color.r, f.GetComponent<Image>().color.g, f.GetComponent<Image>().color.b, 1);
        SD.GetComponent<Image>().color = new Vector4(SD.GetComponent<Image>().color.r, SD.GetComponent<Image>().color.g, SD.GetComponent<Image>().color.b, 1);
        text.GetComponent<Text>().color = new Vector4(text.GetComponent<Text>().color.r, text.GetComponent<Text>().color.g, text.GetComponent<Text>().color.b, 1);
    }
    
}

