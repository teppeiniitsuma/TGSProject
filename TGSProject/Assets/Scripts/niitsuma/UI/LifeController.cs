using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 正確にはLifeViewかPresenterかも
public class LifeController : MonoBehaviour
{
    PlayerParameter parameter;
    // ライフの画像を入れる
    Image[] _lifeUI = new Image[3];

    void Awake()
    {
        parameter = PlayerInfoCounter.Instance.GetParameter;
        for(int i = 0; i < _lifeUI.Length; i++)
        {
            _lifeUI[i] = transform.GetChild(i).gameObject.GetComponent<Image>();
        }
    }
    /// <summary>
    /// ダメージ受けたらLifeUIを消していく（後修正）
    /// </summary>
    void LifeView()
    {
        parameter.hp = PlayerInfoCounter.Instance.GetParameter.hp;
        switch (parameter.hp)
        {
            case 1: _lifeUI[0].fillAmount = 0; _lifeUI[1].fillAmount = 0; _lifeUI[2].fillAmount = 0; break;
            case 2: _lifeUI[0].fillAmount = 1; _lifeUI[1].fillAmount = 0; _lifeUI[2].fillAmount = 0; break;
            case 3: _lifeUI[0].fillAmount = 1; _lifeUI[1].fillAmount = 1; _lifeUI[2].fillAmount = 0; break;
            case 4: _lifeUI[0].fillAmount = 1; _lifeUI[1].fillAmount = 1; _lifeUI[2].fillAmount = 1; break;
        }

    }
    // Update is called once per frame
    void Update()
    {
        LifeView();
    }
}
