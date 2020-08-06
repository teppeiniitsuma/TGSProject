using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputmonitorControlScript : MonoBehaviour
{
    [Header("数字ギミック")]
    [SerializeField]
    GameObject[]inputmonitor =new GameObject [3];
    [Header("正しい暗証番号")]
    [SerializeField]
    string truePasssword;
    [Header("入力中ﾉ暗証番号")]
    [SerializeField]
    string password;
    [Header("障害物")]
    [SerializeField] GameObject gameObject;
    void Start()
    {
      //   atext = a.ToString();
    }

   /// <summary>
   /// 暗証番号を認識ｽﾙ
   /// </summary>
   public void Certification() {
         password=null;
        for (int i = 0; i < inputmonitor.Length; i++) {
            int num = inputmonitor[i].GetComponent<InputmonitorScript>().myNumeral;
            string text = num.ToString();

            password = password + text;
        }
        if (password == truePasssword && inputmonitor[0].GetComponent<InputmonitorScript>().numeralObjects[1] == null && inputmonitor[1].GetComponent<InputmonitorScript>().numeralObjects[1] == null && inputmonitor[2].GetComponent<InputmonitorScript>().numeralObjects[1] == null ) {

            for (int i = 0; i < inputmonitor.Length; i++)
            {
                inputmonitor[i].GetComponent<InputmonitorScript>().enabled = false;
            }
            GameObject.Destroy(gameObject);
        }
    }
}
