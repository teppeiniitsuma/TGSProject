using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ItemValueView : MonoBehaviour
{
    private Text _valueText;
    StringBuilder sb = new StringBuilder(10);
    void Awake()
    {
        _valueText = GetComponent<Text>();
    }

    public void SetItemValue(int value , ItemType item)
    {
        if(item == ItemType.herb)
        {
            sb.Length = 0;
            _valueText.text = sb.Append(value).ToString();
            //value.ToString();
        }
        else
        {
            sb.Length = 0;
            _valueText.text = sb.Append(value).Append("/5").ToString();
            //_valueText.text = value.ToString() + " / 5";
        }
    }
}
