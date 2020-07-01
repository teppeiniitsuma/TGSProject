/*
 プレイヤー情報の窓口
 ここでプレイヤー情報を外部、内部に公開する
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfoCounter : MonoBehaviour, IItemGetter, IDamager
{
    PlayerParameter _parameter = new PlayerParameter();
    public PlayerParameter GetParameter { get { return _parameter; } }

    PossessionItem _items = new PossessionItem();
    public PossessionItem GetItemValue { get { return _items; } }

    bool damage = false;

    void Awake()
    {
        _parameter = new PlayerParameter();
        _items = new PossessionItem();
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
            case ItemType.stone: _items.stoneValue++; break;
            case ItemType.catepillar: _items.catepillarValue++; break;
            case ItemType.herb: _items.herbValue++; break;
            case ItemType.butteflyWing: _items.butteflyWingValue++; break;
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
        _parameter.moveSpeed = 4f;
        _parameter.actSwitch = true;

        _items.stoneValue = 0;
        _items.catepillarValue = 0;
        _items.herbValue = 0;
        _items.butteflyWingValue = 0;

    }
    /// <summary>
    /// ダメージ処理
    /// </summary>
    public void ApplyDamage()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.Main)
        DecreaseHP();
        Debug.Log("on");
    }
    /// <summary>
    /// HP減少処理
    /// 呼ばれたらHPを-1する
    /// </summary>
    public void DecreaseHP()
    {
        if (_parameter.hp <= 1) { Debug.Log("YOU ARE DIE"); SceneManager.LoadScene("GameOver"); return; }
        if(!damage)
            _parameter.hp--;
        damage = true;
        GameManager.Instance.SetGameState(GameManager.GameState.Road);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetGameState == GameManager.GameState.Main) damage = false;
    }
}
