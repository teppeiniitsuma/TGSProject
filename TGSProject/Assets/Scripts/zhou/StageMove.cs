using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

static public class StageMove
{/*
   public enum MyScene
    {
        Title,
        StageSelect,
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Result,
        GameOver
    }
  */
    static public void ReloadCurrentSchene()
    {
        StageConsole.MyScene scene = StageConsole.MyGetScene();
        StageConsole.MyLoadScene(scene);
        
    }

    static public void ResultLoad()
    {
        StageConsole.MyLoadScene(StageConsole.MyScene.Result);
    }
    //ある程度の順番にロードする
    static public  void LoadNextSchene()
    {
        StageConsole.MyScene scene = StageConsole.MyGetScene();

        if (scene == StageConsole.MyScene.Title)
        {
            StageConsole.MyLoadScene(StageConsole.MyScene.StageSelect);
        }
        else if (scene == StageConsole.MyScene.StageSelect)
        {
            StageConsole.MyLoadScene(StageConsole.MyScene.Stage1);
        }
        else if (scene == StageConsole.MyScene.Stage1)
        {
            StageConsole.MyLoadScene(StageConsole.MyScene.Stage2);
        }
        else if (scene == StageConsole.MyScene.Stage2)
        {
            StageConsole.MyLoadScene(StageConsole.MyScene.Stage3);
        }
        else if (scene == StageConsole.MyScene.Stage3)
        {
            StageConsole.MyLoadScene(StageConsole.MyScene.Stage4);
        }
        else if (scene == StageConsole.MyScene.Stage4)
        {
            StageConsole.MyLoadScene(StageConsole.MyScene.Result);
        }
        else if (scene == StageConsole.MyScene.Result || scene == StageConsole.MyScene.GameOver)
        {
            StageConsole.MyLoadScene(StageConsole.MyScene.Title);
        }
    }
    // 特定のステージをロードする
    static public void LoadGameOverSchene() {
        StageConsole.MyLoadScene(StageConsole.MyScene.GameOver);
    }

}
