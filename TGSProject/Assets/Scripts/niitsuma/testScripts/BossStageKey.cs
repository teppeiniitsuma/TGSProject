using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageKey : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ResultManager.TrueEnd = true;
            StageConsole.MyLoadScene(StageConsole.MyScene.BossStageStart);
        }
    }
}
