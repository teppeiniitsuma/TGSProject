using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// サウンドマネージャー
/// </summary>
public class SoundManager : MonoBehaviour
{

    //(1)サウンドルートノードのオブジェクト（サウンドルート（- ルートノード（英：root node）とは 枝分かれ構造な何かにおける「そこから枝分かれが始まってますよ」な要素のこと。 言い方を変えると 枝分かれ構造における根っこの部分にあたる要素のこと です。））
    //(2)シーン転移の時に、削除されないように
    //すべでのサウンドノードが　このサウンドルートノードに帰属（きぞく）
    static GameObject sound_play_object;//これはサウンドルートノード
    static bool is_Music_mute = false;//ゲーム全体のBGMはミュートするかの変量
    static bool is_sffect_mute=false;//今流してる効果音はミュートするかの変量


    // url --> AudioSource 写像, 区別BGM，SE；（写像とは、二つの集合が与えられたときに、一方の集合の各元に対し、他方の集合のただひとつの元を指定して結びつける対応のことである。関数、変換、作用素、射などが写像の同義語として用いられることもある。 ブルバキに見られるように、写像は集合とともに現代数学の基礎となる道具の一つである。）
    /// <summary>
    /// BGM表
    /// </summary>
    static Dictionary<string, AudioSource> musics = null;
    /// <summary>
    /// SE表
    /// </summary>
    static Dictionary<string, AudioSource> effects = null;

    /// <summary>
    /// リセットサウンドルートノード
    /// </summary>
    public static void init()
    {

        sound_play_object = new GameObject("sound_play_object");//セットサウンドルートノード

        //？ sound_play_object.AddComponent<sound_scan>();

        GameObject.DontDestroyOnLoad(sound_play_object);//シーン転移しても削除されないように


        //リセットBGM表とSE表
        musics = new Dictionary<string, AudioSource>();
        effects = new Dictionary<string, AudioSource>();
    }


    public static void PlayerMusic(string url ,bool is_loop=true   ) {

        AudioSource audio_source = null;
        //流したいBGMがBGM表内あるかどうか
        if (musics.ContainsKey(url))//あれば　この値を与える
        {
            audio_source = musics[url];
        }
        else//なっかたら新しいノードを作り、そしてAudioSourceコンポーネントをつけ
        {
            GameObject s = new GameObject(url);//新たななノードを作り
            s.transform.parent = sound_play_object.transform;//シーンに入れる

            audio_source = s.AddComponent<AudioSource>();//ノードにAudioSourceコンポーネントセット
            AudioClip clip = Resources.Load<AudioClip>(url);//セットBGM
            audio_source.loop = is_loop;//ループ
            audio_source.playOnAwake = true;//True に設定した場合、 AudioSource は自動的に Play On Awake を開始します。
            audio_source.spatialBlend = 0.0f;//2D音声
        }
        audio_source.mute = is_Music_mute;
        audio_source.enabled = true;
        audio_source.Play();






    }




  
}
