using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SteleText : MonoBehaviour
{
    [SerializeField] Vector2 offset;
    [SerializeField] RectTransform rectTransform; // オブジェクトを追うUI
    [SerializeField] Text myText;
    [SerializeField] Image myImage;

    [SerializeField] bool isMyPos1;
    [SerializeField] string steleText;
    [SerializeField] GameObject louis;
    private void Start()
    {
       
        myText.text = steleText;
        myImage.color = new Vector4(1, 1, 1,0);
        myText.color = new Vector4(1, 1, 1, 0);
        GameObject parentObj = GameObject.Find("Players");
        louis = parentObj.transform.Find("playerObj").gameObject;
    }
    void Update()
    {
        
        TextColorMove();
    }
   // void TextMoveController() { 
   // }
    //色染まれ
    void TextColorMove()
    {
        TextPosMove();
        if (isMyPos1&&louis.activeSelf==false)
        {
            myText.color = new Vector4(1, 1, 1, myText.color.a + Time.deltaTime);
            myImage.color = new Vector4(1, 1, 1, myImage.color.a + Time.deltaTime*1.2f);

        }
        else if (isMyPos1 && myText.color.a > 0)
        {
            myText.color = new Vector4(1, 1, 1, myText.color.a - Time.deltaTime*0.8f);
            myImage.color = new Vector4(1, 1, 1, myImage.color.a - Time.deltaTime);
        }
    }
    //自分のPOSによってカメラに映す
    void TextPosMove()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        rectTransform.position = screenPos + new Vector2(offset.x, offset.y);

        if (screenPos.x > Screen.width || screenPos.x < 0 || screenPos.y > Screen.height || screenPos.y < 0)
        {
            rectTransform.gameObject.SetActive(false);
        }
        else
        {
            rectTransform.gameObject.SetActive(true);
        }
       // Debug.Log("?");
    }
    //離れ
    void OnTriggerExit2D(Collider2D collider)
    {
         if (collider.name == "player"&&isMyPos1)
        {
            isMyPos1 = false;
        }
    }

    // 接続
    void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.name == "player"&&! isMyPos1)
        {
            isMyPos1 = true;
        }
    }
}
