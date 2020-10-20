using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumbersPresentationManager : MonoBehaviour
{

    
    /// <summary>
    /// 数字ギミックマネージャー
    /// </summary>
    [SerializeField]
    private InputmonitorControlScript inputmonitorControlScript;
    /// <summary>
    /// 吹き出しオブジェク
    /// </summary>
    [Header("吹き出しオブジェク")]
    [SerializeField] private GameObject speechBubbleGameObject;
    [Header("吹き出しオブジェクのスクリプト")]
    [SerializeField] private SpeechBubbleGameObjectScript speechBubbleGameObjectScript;

    [Header("吹き出し数値オブジェク画像")]
    [SerializeField] private Sprite mySprite;
    [Header("吹き出しオブジェク画像")]
    [SerializeField] private Sprite Sprite;
    [Header("吹き出しオブジェク画像")]
    [SerializeField] private Sprite [] speechBubbleSprite=new UnityEngine.Sprite[2];

    [SerializeField] private InputmonitorScript InputmonitorScript;
    [SerializeField] private int myNumera;

    [SerializeField] private GameObject newSpeechBubbleGameObject;
    [SerializeField]
    private int newSpeechBubbleGameObjectNum;
  //--------
    [Header("リセットタイム")]
    [SerializeField] float timeMax = 1;
    [SerializeField] float time;
    public float distance1, distance2;//两个物体の距离

    [Header("表示画像テキストのStartPosY")]
    [SerializeField] float Posy = 3;
    ///---------------
    [SerializeField] Vector2 offset;
    [Header("表示画像オブジェクトのStartPos")]
    [SerializeField] Vector2 speechBubbleGameObjectScriptPos;
    [SerializeField] RectTransform rectTransform;
    /// <summary>
    /// 吹き出し背景の画像
    /// </summary>
    [SerializeField]
   private Sprite[]backgroundsprite =new Sprite[2];
    //吹き出しの画像---------
  
    [Header("表示用画像配置")]
    [SerializeField] Sprite[] Sprites;
   

    /// <summary>
    /// テキスト----------
    /// </summary>
   
    

    // Start is called before the first frame update
    void Start()
    {
        inputmonitorControlScript = GetComponent<InputmonitorControlScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerPos();
        NumConfirmationMove();
    }
    /// <summary>
    /// ゲットプレイヤーの居場所
    /// </summary>
    void GetPlayerPos() {

        if (inputmonitorControlScript.playerPos != null)
        {
            DivisionPosition();
            Move();
            //TextPosMove();
        }
        else {

            GameObject.Destroy(newSpeechBubbleGameObject);
        }
           
        
    }
    /// <summary>
    /// 今どこのボタンの前に立っているのか
    /// </summary>
    void DivisionPosition()
    {
        if (inputmonitorControlScript.playerPos.transform.position.x >= transform.position.x - 0.50f * transform.localScale.x &&
                    inputmonitorControlScript.playerPos.transform.position.x <= transform.position.x + 0.50f * transform.localScale.x)//中
        {
            if (newSpeechBubbleGameObjectNum != 1 || newSpeechBubbleGameObject == null)
            {
                newSpeechBubbleGameObjectNum = 1;
                newSpeechBubbleGameObjectStart(newSpeechBubbleGameObjectNum);
            }
        }
        else if (inputmonitorControlScript.playerPos.transform.position.x > transform.position.x + 0.50f * transform.localScale.x)//右
        {
            if (newSpeechBubbleGameObjectNum != 2 || newSpeechBubbleGameObject == null)
            {
                newSpeechBubbleGameObjectNum = 2;
                newSpeechBubbleGameObjectStart(newSpeechBubbleGameObjectNum);
            }
        }
        else if (inputmonitorControlScript.playerPos.transform.position.x < transform.position.x - 0.50f * transform.localScale.x)//左
        {
            if (newSpeechBubbleGameObjectNum != 0 || newSpeechBubbleGameObject == null)
            {
                newSpeechBubbleGameObjectNum = 0;
                newSpeechBubbleGameObjectStart(newSpeechBubbleGameObjectNum);
            }
        }

      
    }


    /// <summary>
    /// 場所がわれば吹き出しの画像をリセット/スタート
    /// </summary>
    /// <param name="newSpeechBubbleGameObjectNum"></param>
    void newSpeechBubbleGameObjectStart(int newSpeechBubbleGameObjectNum) {
        GameObject.Destroy(newSpeechBubbleGameObject);
        //新しい　吹き出しのオブジェクを作り
        newSpeechBubbleGameObject = Instantiate(speechBubbleGameObject);

        //Get今立つ場所のボタン
        InputmonitorScript rootString  = inputmonitorControlScript.inputmonitor[newSpeechBubbleGameObjectNum].GetComponent<InputmonitorScript>();

        speechBubbleGameObjectScript = newSpeechBubbleGameObject.GetComponent<SpeechBubbleGameObjectScript>();
        //Get今立つ場所のボタンが持つ番号
        myNumera  = rootString.myNumeral % 10;

        if (newSpeechBubbleGameObject.GetComponent<SpeechBubbleGameObjectScript>().numeralObjects[0] == null)
        {
            speechBubbleGameObjectScript.numeralObjects[0] = (GameObject)Instantiate(speechBubbleGameObjectScript.inputmonitorScriptSprite);

            speechBubbleGameObjectScript.numeralObjects[0].name = "numeralObjects" + myNumera;


            myNumera = inputmonitorControlScript.inputmonitor[newSpeechBubbleGameObjectNum].GetComponent<InputmonitorScript>().myNumeral;
            speechBubbleGameObjectScript.numeralObjects[0].GetComponent<SpriteRenderer>().sprite = Sprites[myNumera];
            speechBubbleGameObjectScript.numeralObjects[0].transform.position = new Vector3(
                speechBubbleGameObjectScript.displayVersion.transform.position.x,
                speechBubbleGameObjectScript.displayVersion.transform.position.y,
                speechBubbleGameObjectScript.displayVersion.transform.position.z);
            speechBubbleGameObjectScript.numeralObjects[0].transform.parent = speechBubbleGameObjectScript.displayVersion.transform;


        }
        Sprite= newSpeechBubbleGameObject.GetComponent<SpriteRenderer>().sprite;
        //吹き出しの画像を一致する

        newSpeechBubbleGameObject.GetComponent<SpeechBubbleGameObjectScript>().numeralObjects[0].GetComponent<SpriteRenderer>().sprite= Sprites[myNumera];

        mySprite = newSpeechBubbleGameObject.GetComponent<SpeechBubbleGameObjectScript>().numeralObjects[0].GetComponent<SpriteRenderer>().sprite;

        InputmonitorScript = inputmonitorControlScript.inputmonitor[newSpeechBubbleGameObjectNum].GetComponent<InputmonitorScript>();

     


    }
    // もし　今の画像番号が　正しい　番号に合わない場合
    void NumConfirmationMove() {

        if (InputmonitorScript != null && mySprite != null && myNumera != InputmonitorScript.myNumeral&& speechBubbleGameObjectScript.numeralObjects[1]==null) {
            Debug.Log(myNumera + "    " + InputmonitorScript.myNumeral);
            NumdrawMove();
        }
    }
    void NumdrawMove() {
        speechBubbleGameObjectScript.numeralObjects[1] = (GameObject)Instantiate(speechBubbleGameObjectScript.inputmonitorScriptSprite);

        speechBubbleGameObjectScript.numeralObjects[1].name = "numeralObjects" + myNumera;

        //SpriteRenderer spr = numeralObjects[1].AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;


        myNumera=inputmonitorControlScript.inputmonitor[newSpeechBubbleGameObjectNum].GetComponent<InputmonitorScript>().myNumeral;
        speechBubbleGameObjectScript.numeralObjects[1].GetComponent<SpriteRenderer>().sprite = Sprites[myNumera];
        speechBubbleGameObjectScript.numeralObjects[1].transform.position = new Vector3(
            speechBubbleGameObjectScript.displayVersion.transform.position.x,
            speechBubbleGameObjectScript.displayVersion.transform.position.y - Posy,
            speechBubbleGameObjectScript.displayVersion.transform.position.z);

        speechBubbleGameObjectScript.numeralObjects[1].transform.parent = speechBubbleGameObjectScript.displayVersion.transform;
        speechBubbleGameObjectScript.numeralObjects[0].transform.parent = speechBubbleGameObjectScript.numeralObjects[1].transform;
        InputON();
    }
    /// <summary>
    ///画像の動き始めた処理
    /// </summary>
    private void InputON()
    {
        time = timeMax;
        distance1 = Vector3.Distance(speechBubbleGameObjectScript.numeralObjects[1].transform.position, speechBubbleGameObjectScript.displayVersion.transform.position);
    }
    //画像動き
    private void Move()
    {//数字画像
        if (speechBubbleGameObjectScript.numeralObjects[1] != null)
        {
            speechBubbleGameObjectScript.numeralObjects[1].transform.position = Vector3.MoveTowards(speechBubbleGameObjectScript.numeralObjects[1].transform.position, speechBubbleGameObjectScript.displayVersion.transform.position, (distance1 / 1f) * Time.deltaTime);

            if (speechBubbleGameObjectScript.numeralObjects[1].transform.position == speechBubbleGameObjectScript.displayVersion.transform.position)
            {
                GameObject.Destroy(speechBubbleGameObjectScript.numeralObjects[0]);
                speechBubbleGameObjectScript.numeralObjects[0] = speechBubbleGameObjectScript.numeralObjects[1];
                speechBubbleGameObjectScript.numeralObjects[1] = null;

            }
        }
        //吹き出しの画像
        if (newSpeechBubbleGameObject != null&&inputmonitorControlScript.playerPos!=null) {
            newSpeechBubbleGameObject.transform.position = new Vector3(
                inputmonitorControlScript.playerPos.transform.position.x + speechBubbleGameObjectScriptPos.x * inputmonitorControlScript.playerPos.transform.localScale.x,
                inputmonitorControlScript.playerPos.transform.position.y + speechBubbleGameObjectScriptPos.y,
                inputmonitorControlScript.playerPos.transform.position.z);
        }

        if (Sprite != speechBubbleSprite[0] && inputmonitorControlScript.playerPos.transform.localScale.x < 0.0f)
        {
           newSpeechBubbleGameObject.GetComponent<SpriteRenderer>().sprite = speechBubbleSprite[0];
        }
        else if (Sprite != speechBubbleSprite[1] && inputmonitorControlScript.playerPos.transform.localScale.x > 0.0f)
        {
            newSpeechBubbleGameObject.GetComponent<SpriteRenderer>().sprite = speechBubbleSprite[1];
        }

      

    }


    void TextPosMove()
    {
        if (rectTransform != null)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(newSpeechBubbleGameObject.transform.position);
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

    }


}
