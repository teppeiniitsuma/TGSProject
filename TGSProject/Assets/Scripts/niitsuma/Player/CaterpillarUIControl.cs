using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CaterpillarUIControl : MonoBehaviour
{
    [SerializeField] private float _fadeSpeed = 1.2f;
    // 毛虫の画像を入れる
    [SerializeField] Image[] _caterpillarUI = new Image[3];
    float alpha = 0;
    int count = 0;

    void Awake()
    {
        for (int i = 0; i < _caterpillarUI.Length; i++)
        {
            _caterpillarUI[i] = transform.GetChild(i).gameObject.GetComponent<Image>();
        }
    }
    
    IEnumerator CaterpillarFade()
    {
        count = GameManager.Instance.Information.GetItemValue.catepillarValue;
        Debug.Log(count);
        alpha = _caterpillarUI[count - 1].color.a;
        while (0 < alpha)
        {
            _caterpillarUI[count - 1].color = new Color(_caterpillarUI[count - 1].color.r, _caterpillarUI[count - 1].color.g,
                                                        _caterpillarUI[count - 1].color.b, alpha);
            alpha -= Time.deltaTime / _fadeSpeed;
            yield return null;
        }
        GameManager.Instance.Information.UseItem(ItemType.catepillar);
    }
    /// <summary>
    /// 毛虫を使ったときに呼ぶ
    /// UI画像をフェードさせる処理
    /// </summary>
    public void CaterpillarUse()
    {
        StartCoroutine(CaterpillarFade());
    }

}
