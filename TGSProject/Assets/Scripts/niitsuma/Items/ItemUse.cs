using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualShockInput;

public class ItemUse : MonoBehaviour
{
    PlayerInfoCounter _info;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject caterpillar;
    [SerializeField] private DisplaySpiderCounter _counter;

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
        if (_info.GetItemValue.stoneValue > 0)
        {
            Instantiate(stone, sponePos, transform.rotation);
            _info.UseItem(ItemType.stone);
        }
    }
    /// <summary>
    /// 毛虫の恩返し
    /// </summary>
    void HelpCaterpiller()
    {
        if (_counter.SpiderInScreen())
        {
            _counter.CaterpillarAttack();
            //ResultManager.Instance.SetEnemyKillCount();
        }
    }
    void Update()
    {
        if (_info.GetParameter.actSwitch)
        {
            if (Input.GetKeyDown(KeyCode.Space) || DSInput.PushDown(DSButton.Triangle))
                ThrowStone();
            if (Input.GetKeyDown(KeyCode.H) || DSInput.PushDown(DSButton.Square))
                HelpCaterpiller();
        }
    }
}
