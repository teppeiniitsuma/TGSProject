using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemId : BaseItem
{
    [SerializeField] ItemType itemName;
    
    void Start()
    {
        base.item = itemName;
    }

}
