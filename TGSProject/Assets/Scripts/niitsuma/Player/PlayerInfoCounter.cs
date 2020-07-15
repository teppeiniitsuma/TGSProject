/*
 プレイヤー情報の窓口
 ここでプレイヤー情報を外部、内部に公開する
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInfoCounter : MonoBehaviour, IItemGetter, IDamager
{
    GameManager _gm;

    [SerializeField, Tooltip("プレイヤーのパラメーター")] PlayerParameter _parameter;
    [SerializeField, Tooltip("手に入れなけらばならないハーブの数")] private int _stageHerbs;

    public PlayerParameter GetParameter { get { return _parameter; } }

    PossessionItem _items = new PossessionItem();
    public PossessionItem GetItemValue { get { return _items; } }

    bool damage = false;

    void Awake()
    {
        _items = new PossessionItem();
        _gm = GameManager.Instance;
        Initialize();
    }
    /// <summary>
    /// 方向切り替え
    /// </summary>
    /// <param name="d"></param>
    public void SetDirec(int d)
    {
        _parameter.direction = d;
    }
    /// <summary>
    /// 行動切り替え
    /// </summary>
    /// <param name="act"></param>
    public void SetAct(bool act)
    {
        _parameter.actSwitch = act;
    }
    /// <summary>
    /// アイテム取得処理
    /// </summary>
    /// <param name="id"></param>
    public void ItemGet(ItemType id)
    {
        switch (id)
        {
            case ItemType.stone: if (_items.stoneValue < 5) _items.stoneValue++; break;
            case ItemType.herb: _items.herbValue--; break;
            case ItemType.butteflyWing: if(_items.butteflyWingValue < 5)_items.butteflyWingValue++; break;
            case ItemType.catepillar: _items.catepillarValue++; break;
            case ItemType.life: if (_parameter.hp < 4) _parameter.hp++; break;
            default: break;
        }
    }
    /// <summary>
    /// プレイヤーパラメーターの初期化
    /// </summary>
    public void Initialize()
    {
        _parameter.hp = 4;
        _parameter.direction = 1;
        _parameter.actSwitch = true;

        _items.stoneValue = 0;
        _items.catepillarValue = 0;
        _items.herbValue = _stageHerbs;
        _items.butteflyWingValue = 0;

    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="id">エネミーのID用、エネミー以外は値を入れない</param>
    public void ApplyDamage(int id = 0)
    {
        if(_gm.GetGameState == GameManager.GameState.Main)
        {
            switch (id)
            {
                case 1: DecreaseHP(); break;
                case 2: break;
                case 3: break;
            }
        }

    }
    /// <summary>
    /// HP減少処理
    /// 呼ばれたらHPを-1する
    /// </summary>
    public void DecreaseHP()
    {
        if (_parameter.hp <= 1) { _gm.SetGameState(GameManager.GameState.GameOver); return; }
        if(!damage)　_parameter.hp--;
        damage = true;
        _gm.SetGameState(GameManager.GameState.Road);
    }
    /// <summary>
    /// 石や毛虫が投げられたら呼ぶ
    /// </summary>
    /// <param name="item"></param>
    public void UseItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.stone: _items.stoneValue--; _gm.UIInfo.SetItemInfo(); break;
        }
    }
    void Update()
    {
        if (_gm.GetGameState == GameManager.GameState.Main && damage) damage = false;
    }
}
