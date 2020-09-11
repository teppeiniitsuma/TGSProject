/*
 プレイヤー情報の窓口
 ここでプレイヤー情報を外部、内部に公開する
 */

using UnityEngine;


public class PlayerInfoCounter : MonoBehaviour, IItemGetter, IDamager
{
    GameManager _gm;
    CapsuleCollider2D coll;

    [SerializeField, Tooltip("プレイヤーのパラメーター")] PlayerParameter _parameter;
    [SerializeField, Tooltip("手に入れなけらばならないハーブの数")] private int _stageHerbs;
    [SerializeField, Tooltip("0, 二人行動画像/ 1, 単独行動画像/ 2, 石化画像")] Sprite[] playerSprite = new Sprite[3];

    public PlayerParameter GetParameter { get { return _parameter; } }

    PossessionItem _items = new PossessionItem();
    public PossessionItem GetItemValue { get { return _items; } }
    public bool IsMovable { get; private set; } = false; // プレイヤーが動ける状態か判断

    bool damage = false;
    bool medBoolen = false;
    float medTime = 0;// 消す

    void Awake()
    {
        _items = new PossessionItem();
        _gm = GameManager.Instance;
        Initialize();
        coll = GetComponent<CapsuleCollider2D>();
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
        _items.catepillarValue = 3;
        _items.herbValue = _stageHerbs;
        _items.butteflyWingValue = 0;

    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="id">エネミーのID用、エネミー以外は値を入れない</param>
    public void ApplyDamage(EnemyType id)
    {
        if(_gm.GetGameState == GameManager.GameState.Main)
        {
            switch (id)
            {
                case EnemyType.None: DecreaseHP(); break;
                case EnemyType.SpiderNormal: DecreaseHP(); break;
                case EnemyType.SpiderBoss: DecreaseHP(); break;
                case EnemyType.Medosa: if(_parameter.actSwitch) PetrificationDamage(); break;
                case EnemyType.Plant: break;
            }
        }

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
            case ItemType.catepillar: _items.catepillarValue--; break;
        }
    }
    /// <summary>
    /// 行動切り替え時にプレイヤーの画像を変える
    /// </summary>
    /// <param name="act"></param>
    /// <param name="ren"></param>
    public void SpriteChange(bool act, SpriteRenderer ren)
    {
        if (act) { ren.sprite = playerSprite[0]; coll.size = new Vector2(2.3f, 2.3f); }
        else { ren.sprite = playerSprite[1]; coll.size = new Vector2(1, 2.3f); }
    }

    /// <summary>
    /// HP減少処理
    /// 呼ばれたらHPを-1する
    /// </summary>
    public void DecreaseHP()
    {
        if (_parameter.hp <= 1) { _gm.SetGameState(GameManager.GameState.GameOver); return; }
        if (!damage) _parameter.hp--;
        _gm.SetGameState(GameManager.GameState.Road);
        damage = true;
    }
    // 石化ダメージ
    void PetrificationDamage()
    {
        var s = GetComponent<SpriteRenderer>();
        s.sprite = playerSprite[2];
        medBoolen = true;
        IsMovable = true;
    }
    void Update()
    {
        if (_gm.GetGameState == GameManager.GameState.Main && damage) damage = false;
        if(_gm.GetGameState == GameManager.GameState.Road)
        {
            if (GetParameter.actSwitch)
            {
                var i = GetComponent<SpriteRenderer>();
                i.sprite = playerSprite[0];
                IsMovable = false;
            }
            else
            {
                var i = GetComponent<SpriteRenderer>();
                i.sprite = playerSprite[1];
                IsMovable = false;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.L)) { _items.stoneValue++; }
        // クソ処理（時間内から書いただけ）
        if (medBoolen) { medTime += Time.deltaTime; }
        if(medTime  > 2) 
        {
            medTime = 0; medBoolen = false;
            DecreaseHP();
        }
    }
}
