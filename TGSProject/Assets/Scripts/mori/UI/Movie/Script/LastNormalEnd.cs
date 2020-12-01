using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastNormalEnd : MonoBehaviour  //  ノーマルEndの処理
{
    [SerializeField] CollectedButterfly _butterfly;
    [SerializeField] FadeController _fade;

    bool endTirgger = false;
    //  ここに会話以降をお願い予定
    private void Normalend()
    {
        Debug.Log("ノーマルエンド");
        if (!endTirgger) { _fade.Fade(false, () => StageConsole.MyLoadScene(StageConsole.MyScene.NormalEnd_Boss)); }
        endTirgger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(2 == _butterfly._collectedButterfly)
        {
            Normalend();
        }
    }
}
