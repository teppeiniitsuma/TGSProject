/*
  リザルト用のデータを管理するクラス
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-2)]
public class ResultManager : MonoBehaviour
{
    public static ResultManager Instance { get { return _instance; } }
    private static ResultManager _instance;

    public ResultData GetResultData { get { return _data; } }
    private static ResultData _data = new ResultData();
    public static bool TrueEnd { get; set; } = false;

    void Awake()
    {
        _instance = this;
    }
    /// <summary>
    /// メインステージが始まるときに呼ぶ
    /// リザルト用のデータの初期化
    /// </summary>
    public void DataInitialize()
    {
        _data.playTime = 0;
        _data.ownHerb = 0;
        _data.killEnemyCount = 0;
        _data.stoneMonumentCount = 0;
        _data.deadCount = 0;
    }
    /// <summary>
    /// プレイ時間をデータとしてセットする
    /// </summary>
    /// <param name="time">秒単位のプレイ時間をセット</param>
    public void SetPlayTime(int time)
    {
        _data.playTime = time;
    }
    /// <summary>
    /// エネミーを倒すたびに呼ぶ
    /// </summary>
    public void SetEnemyKillCount()
    {
        _data.killEnemyCount++;
    }
    /// <summary>
    /// ハーブを取得するごとに呼ぶ
    /// </summary>
    public void SetHerbValue()
    {
        _data.ownHerb++;
    }
    /// <summary>
    /// プレイヤーが死ぬたびに呼ぶ
    /// </summary>
    public void SetDeadCount()
    {
        _data.deadCount++;
    }
    /// <summary>
    /// 石碑を解くと呼ばれる
    /// </summary>
    public void SetStoneMonumentCount()
    {
        _data.stoneMonumentCount++;
    }
}
