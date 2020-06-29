using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 3;
    private Image _fadeUI;
    private float alpha = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _fadeUI = GetComponent<Image>();
    }

    void Start()
    {
        StartCoroutine(FadeIN());
    }
    /// <summary>
    /// 明るくする
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeIN()
    {
        // 念のため初期化
        _fadeUI.color = Color.black;
        alpha = _fadeUI.color.a;
        while (0 < _fadeUI.color.a)
        {
            _fadeUI.color = new Color(_fadeUI.color.r, _fadeUI.color.g, _fadeUI.color.b, alpha);
            alpha -= Time.deltaTime / fadeSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        GameManager.Instance.SetGameState(GameManager.GameState.Main);
    }
    /// <summary>
    /// 暗くする
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOUT()
    {
        // 念のため初期化
        _fadeUI.color = Color.clear;
        alpha = _fadeUI.color.a;
        while (_fadeUI.color.a < 255)
        {
            _fadeUI.color = new Color(_fadeUI.color.r, _fadeUI.color.g, _fadeUI.color.b, alpha);
            alpha += Time.deltaTime / fadeSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1);
    }

    void Update()
    {
        
    }
}
