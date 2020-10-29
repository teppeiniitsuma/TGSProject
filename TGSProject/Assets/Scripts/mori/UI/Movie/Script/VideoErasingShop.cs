using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoErasingShop : MonoBehaviour
{
    [SerializeField]GameObject _video;
    [SerializeField] FadeController _faUI;
    LastTrueMovie _lsMovie;
    private bool _fadeOut;
    void Start()
    {
        _lsMovie = _video.GetComponent<LastTrueMovie>();
    }

    //  ここに会話以降をお願い予定
    private void Action()
    {
        Debug.Log("トゥルーエンド");
    }

    // Update is called once per frame
    void Update()
    {
        if(_lsMovie._videoStop && !_fadeOut)
        {
            _video.transform.parent.gameObject.SetActive(false);
            _faUI.Fade(true, () => Action());
            _fadeOut = true;
        }
    }
}
