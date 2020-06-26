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

    bool isMyPos;
     [SerializeField] string steleText;
    private void Start()
    {
        myText.text = steleText;
    }
    void Update()
    {
        TextPosMove();
        TextColorMove();
    }
   // void TextMoveController() { 
   // }
    //色染まれ
    void TextColorMove()
    {
        if (isMyPos) {
            myText.color = new Vector4(1, 1, 1, myText.color.a + Time.deltaTime);
            myImage.color = new Vector4(1, 1, 1, myImage.color.a + Time.deltaTime*1.2f);

        }
        else if (!isMyPos && myText.color.a > 0) { 
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
    }
    //離れ
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player") {
            isMyPos = false;
        }
    }

    // 接続
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            isMyPos = true;
        }
    }
}
