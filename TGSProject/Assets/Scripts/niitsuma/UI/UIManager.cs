using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private testValueView[] views = new testValueView[1];
    private PlayerInfoCounter _info;

    void Start()
    {
        _info = GameManager.Instance.Information;
        views[0].SetItemValue(_info.GetItemValue.stoneValue);
    }

    void SetInfo()
    {
        views[0].SetItemValue(_info.GetItemValue.stoneValue);
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.Main)
            SetInfo();
    }
}
