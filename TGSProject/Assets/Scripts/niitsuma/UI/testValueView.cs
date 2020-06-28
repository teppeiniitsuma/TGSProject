using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testValueView : MonoBehaviour
{
    private Text _valueText;
    void Awake()
    {
        _valueText = GetComponent<Text>();
    }

    public void SetItemValue(int value)
    {
        _valueText.text = "x" + value.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
