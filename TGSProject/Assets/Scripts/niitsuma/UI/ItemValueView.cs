using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemValueView : MonoBehaviour
{
    private Text _valueText;
    void Awake()
    {
        _valueText = GetComponent<Text>();
    }

    public void SetItemValue(int value , ItemType item)
    {
        if(item == ItemType.herb)
        {
            _valueText.text = value.ToString();
        }
        else
        {
            _valueText.text = value.ToString() + " / 5";
        }
    }
}
