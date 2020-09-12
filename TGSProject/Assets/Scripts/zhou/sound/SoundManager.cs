using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// サウンドマネージャー
/// </summary>
public class SoundManager
{

    //(1)サウンドルートノードのオブジェクト（サウンドルート（ルートノード（英：root node）とは 枝分かれ構造な何かにおける「そこから枝分かれが始まってますよ」な要素のこと。 言い方を変えると 枝分かれ構造における根っこの部分にあたる要素のこと です。））
    //(2)シーン転移の時に、削除されないように
    //すべでのサウンドノードが　このサウンドルートノードに帰属（きぞく）
    static GameObject sound_play_object;//これはサウンドルートノード
    /// <summary>
    /// ゲーム全体のBGMはミュートするかの変量
    /// </summary>
    static bool is_Music_mute = false;
    /// <summary>
    /// 今流してる効果音はミュートするかの変量
    /// </summary>
    static bool is_sffect_mute = false;
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

        sound_play_object.AddComponent<SoundScan>();//インスタンススキャンスクリプト

        GameObject.DontDestroyOnLoad(sound_play_object);//シーン転移しても削除されないように

        //リセットBGM表とSE表
        musics = new Dictionary<string, AudioSource>();
        effects = new Dictionary<string, AudioSource>();
    }

    /// <summary>
    /// BGMのインターフェース
    /// </summary>
    /// <param name="url"></param>
    /// <param name="is_loop"></param>
    public static void PlayMusic(string url, bool is_loop = true)
    {
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
            AudioClip clip = Resources.Load<AudioClip>(url);//BGM

            audio_source.clip = clip;//セットSE
            audio_source.loop = is_loop;//ループ
            audio_source.playOnAwake = true;//True に設定した場合、 AudioSource は自動的に Play On Awake を開始します。
            audio_source.spatialBlend = 0.0f;//2D音声

            musics.Add(url, audio_source);//musics辞典に入れる
        }
        audio_source.mute = is_Music_mute;//
        audio_source.enabled = true;
        audio_source.Play();//再生開始
    }
    /// <summary>
    /// 指定BGMを停止するインターフェース
    /// </summary>
    public static void StopMuisc(string url)
    {
        AudioSource audio_source = null;
        if (!musics.ContainsKey(url))//BGM表内あるか
        {
            return;
        }
        audio_source = musics[url];//あればurl　値を与える
        audio_source.Stop();//BGM停止
    }
    public static void StopAllMusic()
    {
        foreach (AudioSource s in musics.Values)
        {
            s.Stop();
        }
    }

    /// <summary>
    ///指定BGMを削除ノード
    /// </summary>
    /// <param name="url"></param>
    public static void ClearMuisc(string url)
    {
        AudioSource audio_source = null;
        if (!musics.ContainsKey(url))//BGM表内あるか
        {
            return;
        }
        audio_source = musics[url];//あればurl　値を与える
        musics[url] = null;//AudioSourceコンポーネントをリセット
        GameObject.Destroy(audio_source.gameObject);//AudioSourceコンポーネントを削除

    }

    //SE関係-----------------------------------------------------------
    /// <summary>
    /// SEインターフェース
    /// </summary>
    /// <param name="url"></param>
    /// <param name="is_loop"></param>
    public static void PlayEffect(string url, bool is_loop = false)
    {
        AudioSource audio_source = null;
        if (effects.ContainsKey(url))//SE表内あるか
        {
            audio_source = effects[url];//あればurl　値を与える
        }
        else
        {
            GameObject s = new GameObject(url);//新たななノードを作り
            s.transform.parent = sound_play_object.transform;//シーンに入れる

            audio_source = s.AddComponent<AudioSource>();//ノードにAudioSourceコンポーネントセット
            AudioClip clip = Resources.Load<AudioClip>(url);//SE

            audio_source.clip = clip;//セットSE

            audio_source.loop = is_loop;//ループ
            audio_source.playOnAwake = true;//True に設定した場合、 AudioSource は自動的に Play On Awake を開始します。
            audio_source.spatialBlend = 0.0f;//2D音声

            effects.Add(url, audio_source);//effects辞典に入れる
        }
        audio_source.mute = is_Music_mute;//
        audio_source.enabled = true;

        audio_source.Play();//再生開始

    }
    /// <summary>
    /// SEを停止するインターフェース
    /// </summary>
    public static void StopEffect(string url)
    {
        AudioSource audio_source = null;
        if (!effects.ContainsKey(url))//SE表内あるか
        {
            return;
        }
        audio_source = effects[url];//あれば値を与える
        audio_source.Stop();//停止再生
    }

    /// <summary>
    /// SE全体を停止するインターフェース
    /// </summary>
    public static void StopAllEffect()
    {
        foreach (AudioSource s in effects.Values)
        {
            s.Stop();
        }
    }
    /// <summary>
    /// 指定SEを削除するインターフェース
    /// </summary>
    public static void ClearEffect(string url)
    {
        AudioSource audio_source = null;
        if (!effects.ContainsKey(url))//BGM表内あるか
        {
            return;
        }
        audio_source = effects[url];//あればurl　値を与える
        effects[url] = null;// AudioSourceコンポーネントをリセット
        GameObject.Destroy(audio_source.gameObject);// AudioSourceコンポーネントを削除

    }
    /// <summary>
    /// インターフェース優化
    /// </summary>
    public static void DisableOverAudio()
    {//foreach　BGM表
        foreach (AudioSource s in musics.Values)
        {
            if (!s.isPlaying)//再生中か
            {
                s.enabled = false;//してなければ　隠す
            }
        }
        //foreach SE表
        foreach (AudioSource s in effects.Values)
        {
            if (!s.isPlaying)//再生中か
            {
                s.enabled = false;   ////してなければ　隠す
            }
        }
    }
}
