using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastNormalEnd : MonoBehaviour
{
    [SerializeField] CollectedButterfly _butterfly;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //  ここに会話以降をお願い予定
    private void Normalend()
    {
        Debug.Log("ノーマルエンド");
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
