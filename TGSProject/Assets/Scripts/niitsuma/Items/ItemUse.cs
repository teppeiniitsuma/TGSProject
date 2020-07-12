using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualShockInput;

public class ItemUse : MonoBehaviour
{
    PlayerInfoCounter _info;
    [SerializeField] private GameObject stone;

    void Start()
    {
        _info = GetComponent<PlayerInfoCounter>();
    }

    /// <summary>
    /// 石投げ
    /// </summary>
    void ThrowStone()
    {
        Vector2 sponePos = new Vector2(transform.position.x + 1, transform.position.y + 1);
        if (_info.GetItemValue.stoneValue > 0)
        {
            Instantiate(stone, sponePos, transform.rotation);
            _info.UseItem(ItemType.stone);
        }
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || DSInput.PushDown(DSButton.Triangle))
            ThrowStone();
    }
}
