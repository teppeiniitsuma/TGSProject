/*
 プレイヤー情報の窓口
 ここでプレイヤー情報を外部、内部に公開する
 */

using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlayerInfoCounter : MonoBehaviour, IItemGetter, IDamager
{
    GameManager _gm;
    CapsuleCollider2D coll;
    static PlayerInfoCounter _instance;

    [SerializeField, Tooltip("プレイヤーのパラメーター")] PlayerParameter _parameter;
    [SerializeField, Tooltip("手に入れなけらばならないハーブの数")] private int _stageHerbs;
    [SerializeField, Tooltip("0, 二人行動画像/ 1, 単独行動画像/ 2, 石化画像")] Sprite[] playerSprite = new Sprite[3];

    public static PlayerInfoCounter Instance { get => _instance; }
    public PlayerParameter GetParameter { get { return _parameter; } }

    PossessionItem _items = new PossessionItem();
    public PossessionItem GetItemValue { get { return _items; } }
    PlayerState pState;
    public PlayerState GetPlayerState { get => pState; }
    public bool IsMovable { get; set; } = false; // プレイヤーが動ける状態か判断
    public bool IsSwitchedable { get; set; } = true; // 行動切り替えができる状態か
    public int GetStageHarb { get => _stageHerbs; }
    public StageType sType;

    int _maxHp = 4;
    bool damage = false;
    bool medBoolen = false;
    float medTime = 0;// 消す

    public enum PlayerState
    {
        Default,
        Petrification, // 石化
        ItemUse,
        InSwitching, // 行動切り替え中
        Damage,
    }
    public enum StageType
    {
        Stage1,
        Stage2,
    }

    void Awake()
    {
        _instance = this;
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
    /// プレイヤーの状態切り替え
    /// </summary>
    /// <param name="p">切り替える状態</param>
    public void SetPlayerState(PlayerState p)
    {
        pState = p;
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
            case ItemType.herb: if(0 < _items.herbValue) _items.herbValue--; break;
            case ItemType.butteflyWing: _items.butteflyWingValue++; break;
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
        _parameter.hp = _maxHp;
        _parameter.direction = 1;
        _parameter.actSwitch = true;

        _items.stoneValue = 0;
        _items.catepillarValue = 3;
        _items.herbValue = _stageHerbs;

        if (sType == StageType.Stage1) { _items.butteflyWingValue = 0; }
        else { _items.butteflyWingValue = 1; }
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
        if (!damage) { _parameter.hp = Mathf.Clamp(_parameter.hp - 1, 0, _maxHp); }
        if (_parameter.hp == 0) { _gm.SetGameState(GameManager.GameState.GameOver); return; }
        _gm.SetGameState(GameManager.GameState.Road);
        damage = true;
        ResultManager.Instance.SetDeadCount();
    }
    // 石化ダメージ
    void PetrificationDamage()
    {
        var s = GetComponent<SpriteRenderer>();
        medBoolen = true;
        IsMovable = true;
        pState = PlayerState.Petrification;
        SoundManager.PlayEffect("Audios/Enemy/medusa_attack_spell", false);
        SoundManager.PlayEffect("Audios/Enemy/medusa_attack_stoned", false);
        ResultManager.Instance.SetDeadCount();
    }

    void Update()
    {
        if (_gm.GetGameState == GameManager.GameState.Main && damage) damage = false;
        if(_gm.GetGameState == GameManager.GameState.Road)
        {
            if (GetParameter.actSwitch)
            {
                pState = PlayerState.Default;
                //var i = GetComponent<SpriteRenderer>();
                //i.sprite = playerSprite[0];
                IsMovable = false;
            }
            else
            {
                pState = PlayerState.Default;
                //var i = GetComponent<SpriteRenderer>();
                //i.sprite = playerSprite[1];
                IsMovable = false;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.L)) { _items.stoneValue++; }
        // クソ処理
        if (medBoolen) { medTime += Time.deltaTime; }
        if(medTime  > 2) 
        {
            medTime = 0; medBoolen = false;
            DecreaseHP();
        }
    }
}
