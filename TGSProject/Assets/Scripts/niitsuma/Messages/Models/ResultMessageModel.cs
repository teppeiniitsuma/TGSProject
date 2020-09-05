using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResultMessageModel
{
    //｛クリアタイム、ハーブ、死敵、石碑、死自｝
    public List<string> messageList = new List<string>() { "00:46:49", "5個", "1体", "1枚", "1回" };

    int hour, min, sec;

    /// <summary>
    /// リザルト画面用のデータセット
    /// </summary>
    /// <param name="list">メッセージリスト</param>
    /// <param name="data">リザルト用データ</param>
    public void ResultDataSetter(List<string> list, ResultData data)
    {
        sec = data.playTime;
        //sec = 120;
        hour = sec / 3600;
        min = (sec % 3600) / 60;
        sec = sec % 60;

        messageList.Clear();
        messageList.Add(hour.ToString("D2") +":" + min.ToString("D2") + ":" + sec.ToString("D2"));
        messageList.Add(data.ownHerb.ToString() + "個");
        messageList.Add(data.killEnemyCount.ToString() + "体");
        messageList.Add(data.stoneMonumentCount.ToString() + "枚");
        messageList.Add(data.deadCount.ToString() + "回");
        list = messageList;
    }
}
