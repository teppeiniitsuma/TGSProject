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

    void UseItem()
    {
        Vector2 sponePos = new Vector2(transform.position.x + 1, transform.position.y + 1);
        if (_info.GetItemValue.stoneValue > 0) Instantiate(stone, sponePos, transform.rotation);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || DSInput.PushDown(DSButton.Triangle))
            UseItem();
    }
}
