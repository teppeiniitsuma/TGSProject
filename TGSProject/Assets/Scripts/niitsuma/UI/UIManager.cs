using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField, Tooltip("0, 石 / 1, ハーブ / 2, 蝶の羽")] private ItemValueView[] views = new ItemValueView[3];
    private PlayerInfoCounter _info;

    void Start()
    {
        _info = PlayerInfoCounter.Instance;
        SetItemInfo();
    }

    public void SetItemInfo()
    {
        views[(int)ItemType.stone].SetItemValue(_info.GetItemValue.stoneValue, ItemType.stone);
        views[(int)ItemType.herb].SetItemValue(_info.GetItemValue.herbValue, ItemType.herb);
        views[(int)ItemType.butteflyWing].SetItemValue(_info.GetItemValue.butteflyWingValue, ItemType.butteflyWing);
    }
    
}
