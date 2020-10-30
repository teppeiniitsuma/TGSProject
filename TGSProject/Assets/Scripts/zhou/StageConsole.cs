using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class StageConsole
{
    public enum MyScene
    {
        Title,
        StageSelect,
        Scenario,
        BetweenStage,
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Result,
        GameOver,
        BossScene,
        Tutorial,
        PvScene,
        Endroll,
    }
    public static MyScene scene;
    static Dictionary<string, MyScene> sceneDic = new Dictionary<string, MyScene>() {
    {"Title", MyScene.Title },
    {"StageSelect",     MyScene.StageSelect },
    {"Stage1",   MyScene.Stage1 },
    {"Stage2",   MyScene.Stage2 },
    {"Stage3",   MyScene.Stage3 },
    {"Stage4",   MyScene.Stage4 },
    {"Scenario",   MyScene.Scenario },
    {"BetweenStage",   MyScene.BetweenStage },
    {"Result",   MyScene.Result },
    {"GameOver",   MyScene.GameOver },
    {"BossScene",   MyScene.BossScene },
    {"Tutorial", MyScene.Tutorial },
    {"TitlePV", MyScene.PvScene },
    {"Endroll", MyScene.Endroll },
};

    public static MyScene MyGetScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        scene = sceneDic[sceneName];
        return scene;

    }
    // enumのシーンで指定したシーンをロードする
    public static void MyLoadScene(MyScene scene)
    {
        SceneManager.LoadScene(sceneDic.FirstOrDefault(x => x.Value == scene).Key);
    }
  
}
/*
// 現在のシーンを再度ロードする
public void ReloadCurrentSchene()
{
    StageConsole.MyScene scene = StageConsole.MyGetScene();
    StageConsole.MyLoadScene(scene);
}


// 現在のシーンの次のシーンに遷移する



/*
          StageName stageName= StageName.Title;
        //  stageName = StageName.Title++;
        // stageName++;
        //　変数ｂを宣言し　　データの種類　データ名　データ番号
        var b = (StageName)1;
        Debug.Log(b);
       
        //  Debug.Log(stageName);
        */
//public static MyScene scene;
// シーン名とenumのシーンとを対応させる
