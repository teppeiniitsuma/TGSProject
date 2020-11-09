using UnityEngine;

public class SeInitialize : MonoBehaviour
{
    void Awake()
    {
        ///サウンドノードを　リセット
        SoundManager.init();
    }

}
