using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[Serializable]
public class MessageModel
{
    // サンプル ｛クリアタイム、ハーブ、死敵、石碑、死自｝
    public List<string> messageList = new List<string>() { "00:46:49", "5個", "1体", "1枚", "1回" };
    
    /// <summary>
    /// リザルト画面用のデータセット
    /// </summary>
    /// <param name="list">メッセージリスト</param>
    /// <param name="data">リザルト用データ</param>
    public void ResultDataSetter(List<string> list, ResultData data)
    {
        messageList.Clear();
        messageList.Add(data.playTime.ToString());
        messageList.Add(data.ownHerb.ToString());
        messageList.Add(data.killEnemyCount.ToString());
        messageList.Add(data.stoneMonumentCount.ToString());
        messageList.Add(data.deadCount.ToString());
        list = messageList;
    }
}
