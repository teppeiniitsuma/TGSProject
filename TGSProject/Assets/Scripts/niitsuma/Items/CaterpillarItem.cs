using System.Collections;
using UnityEngine;

public class CaterpillarItem : MonoBehaviour
{
    [SerializeField] private float _fadeSpeed = 1.2f;
    private CaterpillarUIControl _uiControl;
    private SpriteRenderer _sprite;
    private float alpha = 0;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _uiControl = FindObjectOfType<CaterpillarUIControl>();
        StartCoroutine(CatepillarFade());
    }
    // 毛虫UIを一定時間かけてフェードする
    IEnumerator CatepillarFade()
    {
        alpha = _sprite.color.a;
        yield return new WaitForSeconds(2f); // 後で変える
        while(0 <= _sprite.color.a)
        {
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, alpha);
            alpha -= Time.deltaTime / _fadeSpeed;
            yield return null;
        }
        _uiControl.CaterpillarUse();
        Destroy(gameObject);
        GameManager.Instance.EventEnd();
    }

}
