using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum ItemType
{
    stone = 0, // 石
    herb, // ハーブ
    butteflyWing, // 蝶の羽
    catepillar, // 毛虫
    life, // lifeキノコ
}

public abstract class BaseItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var set = collision.gameObject.GetComponent<IItemGetter>();
        if(null != set) { set.ItemGet(item); GameManager.Instance.UIInfo.SetItemInfo(); this.gameObject.SetActive(false); }
    }

    protected ItemType item;

}
