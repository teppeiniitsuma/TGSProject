using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField, Tooltip("0, 石 / 1, ハーブ")] private testValueView[] views = new testValueView[2];
    private PlayerInfoCounter _info;

    void Start()
    {
        _info = GameManager.Instance.Information;
        views[0].SetItemValue(_info.GetItemValue.stoneValue);
        views[1].SetItemValue(_info.GetItemValue.herbValue);
    }

    void SetInfo()
    {
        views[0].SetItemValue(_info.GetItemValue.stoneValue);
        views[1].SetItemValue(_info.GetItemValue.herbValue);
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.Main)
            SetInfo();
    }
}
