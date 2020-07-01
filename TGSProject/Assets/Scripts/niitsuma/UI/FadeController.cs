using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField] private float fadeInSpeed = 3;
    [SerializeField] private float fadeOutSpeed = 1;
    private Image _fadeUI;
    private float alpha = 0;
    bool outCheck = false;
    bool test = false;
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
        Debug.Log("ええやん");
        // 念のため初期化
        _fadeUI.color = Color.black;
        alpha = _fadeUI.color.a;
        while (0 < _fadeUI.color.a)
        {
            _fadeUI.color = new Color(_fadeUI.color.r, _fadeUI.color.g, _fadeUI.color.b, alpha);
            alpha -= Time.deltaTime / fadeInSpeed;
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
        while (_fadeUI.color.a < 1)
        {
            _fadeUI.color = new Color(_fadeUI.color.r, _fadeUI.color.g, _fadeUI.color.b, alpha);
            alpha += Time.deltaTime / fadeOutSpeed;
            yield return null;
        }
        GameManager.Instance.SetGameState(GameManager.GameState.SetUp);
        yield return new WaitForSeconds(1);
        test = true;
    }

    void Update()
    {
        if (GameManager.Instance.GetGameState == GameManager.GameState.Road) outCheck = true;
        if (outCheck && !test) { outCheck = false; StartCoroutine(FadeOUT()); }
        if (test) { test = false; StartCoroutine(FadeIN()); }
    }
}
