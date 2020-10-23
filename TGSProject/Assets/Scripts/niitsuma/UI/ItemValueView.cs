using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ItemValueView : MonoBehaviour
{
    [SerializeField] private int _maxCount = 5;
    private Text _valueText;
    private StringBuilder sb = new StringBuilder(10);

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
            _valueText.text = sb.Append(value).Append("/" + _maxCount).ToString();
            //_valueText.text = value.ToString() + " / 5";
        }
    }
}
