/*
  リザルト用のデータを管理するクラス
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class ResultManager : MonoBehaviour
{
    public static ResultManager Instance { get { return _instance; } }
    private static ResultManager _instance;

    public ResultData GetResultData { get { return _data; } }
    private static ResultData _data = new ResultData();

    void Awake()
    {
        _instance = this;
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
