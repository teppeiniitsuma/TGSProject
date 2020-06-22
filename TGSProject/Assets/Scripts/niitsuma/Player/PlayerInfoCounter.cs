/*
 プレイヤー情報の窓口
 ここでプレイヤー情報を外部、内部に公開する
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoCounter : MonoBehaviour, IItemGetter
{
    PlayerParameter _parameter = new PlayerParameter();
    public PlayerParameter GetParameter { get { return _parameter; } }

    PossessionItem _items = new PossessionItem();
    public PossessionItem GetItems { get { return _items; } }

    public void SetDirec(int d)
    {
        _parameter.direction = d;
    }
    public void SetAct(bool act)
    {
        _parameter.actSwitch = act;
    }
    void Awake()
    {
        _parameter = new PlayerParameter();
        _items = new PossessionItem();
        Initialize();
    }
    /// <summary>
    /// アイテム取得処理
    /// </summary>
    /// <param name="id"></param>
    public void ItemGet(ItemType id)
    {
        switch (id)
        {
            case ItemType.stone: _items.stoneValue++; break;
            case ItemType.catepillar: _items.catepillarValue++; break;
            case ItemType.herb: _items.herbValue++; break;
            case ItemType.butteflyWing: _items.butteflyWingValue++; break;
            default: break;
        }
    }
    // 初期化
    void Initialize()
    {
        _parameter.hp = 4;
        _parameter.direction = 1;
        _parameter.moveSpeed = 4f;
        _parameter.actSwitch = false;

        _items.stoneValue = 0;
        _items.catepillarValue = 0;
        _items.herbValue = 0;
        _items.butteflyWingValue = 0;

    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(_items.stoneValue);
    }
}
