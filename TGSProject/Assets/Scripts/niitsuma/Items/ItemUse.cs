using UnityEngine;
using DualShockInput;

public class ItemUse : MonoBehaviour
{
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject caterpillar;
    [SerializeField] private DisplaySpiderCounter _counter;
    PlayerInfoCounter _info;

    void Start()
    {
        _info = GetComponent<PlayerInfoCounter>();
    }

    /// <summary>
    /// 石投げ
    /// </summary>
    void ThrowStone()
    {
        
        Vector2 sponePos = new Vector2(transform.position.x + 1, transform.position.y + 0.6f);
        if (0 < _info.GetItemValue.stoneValue)
        {
            Instantiate(stone, sponePos, transform.rotation);
            //SEを再生
            SoundManager.PlayMusic("Audios/Player/throw_stone", false);
            _info.UseItem(ItemType.stone);
        }
    }
    /// <summary>
    /// 毛虫の恩返し
    /// </summary>
    void HelpCaterpiller()
    {
        if (_counter.SpiderInScreen() && 0 <_info.GetItemValue.catepillarValue)
        {
            _counter.CaterpillarAttack();
            //SEを再生
            SoundManager.PlayMusic("Audios/Player/caterpillar_attack", false);
            //ResultManager.Instance.SetEnemyKillCount();
        }
    }
    void Update()
    {
        if (_info.GetParameter.actSwitch && GameManager.Instance.GetGameState == GameManager.GameState.Main)
        {
            if (Input.GetKeyDown(KeyCode.Space) || DSInput.PushDown(DSButton.Triangle))
                ThrowStone();
            if (Input.GetKeyDown(KeyCode.H) || DSInput.PushDown(DSButton.Square))
                HelpCaterpiller();
        }
    }
}
