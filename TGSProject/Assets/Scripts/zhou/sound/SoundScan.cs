using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScan : MonoBehaviour
{/// <summary>
/// サウンド　インターフェーススキャン
/// </summary>
    void Start()
    {
        this.InvokeRepeating("Scan", 0, 0.5f);
    }
    // 優化インターフェース
    void Scan()
    {
        SoundManager.DisableOverAudio();//
    }
}
