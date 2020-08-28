using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualShockInput;

public class InputmonitorScript : MonoBehaviour
{
    [Header("本体")]
    [SerializeField] GameObject ontology;
    [Header("モニター")]
    [SerializeField] GameObject displayVersion;
    [Header("表示画像配置")]
    public GameObject[] numeralObjects;
    [Header("表示用画像配置")]
    [SerializeField] Sprite[] Sprites;
    [Header("リセットタイム")]
    [SerializeField] float timeMax = 1;
    [SerializeField] float time;
    public float distance1, distance2;//两个物体的距离
    [Header("表示画像配置のStartPosY")]
    [SerializeField] float Posy = 1;
    [Header("今の番号")]
 public int myNumeral = 0;
    [Header("入力できるか")]
    [SerializeField] bool inputON;
    [SerializeField]
    bool isMyPos;

    [Header("animeGameObject")]
    [SerializeField]
    private GameObject animeGameObject;//

    private Animator animator;
    public const string key_isSpot = "isSpot";


    [Header("アルファ設定済みｹﾞｰﾑオブジェクト")]
    [SerializeField] GameObject inputmonitorScriptSprite;
    void Start()
    {
        animator = animeGameObject.GetComponent<Animator>();

        animator.SetBool(key_isSpot, false);
        //ランタン
        //myNumeral = Random.Range(0, 9);
        numeralObjects[0].GetComponent<SpriteRenderer>().sprite = Sprites[myNumeral];
    }
    void Update()
    {
        if (isMyPos &&inputON && (Input.GetKeyDown(KeyCode.Space) || DSInput.PushDown(DSButton.Circle))) {
            InputStart();
        }
        Move();
     //  InputTest();
    }
    void InputStart()
    {
        inputON = false;
        numeralObjects[1] = (GameObject)Instantiate(inputmonitorScriptSprite);
        numeralObjects[1].name = "numeralObjects" + myNumeral;
        //SpriteRenderer spr = numeralObjects[1].AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        myNumeral++;
        myNumeral = myNumeral %10;
        numeralObjects[1].GetComponent<SpriteRenderer>().sprite = Sprites[myNumeral];
        numeralObjects[1].transform.position = new Vector3(
            displayVersion.transform.position.x,
            displayVersion.transform.position.y - Posy,
            displayVersion.transform.position.z);
        numeralObjects[1].transform.parent = displayVersion.transform;
        numeralObjects[0].transform.parent = numeralObjects[1].transform;
        InputON();
    }
    /// <summary>
    /// 入力を受けったからの処理2
    /// </summary>
    private void InputON()
    {
        time = timeMax;
        distance1 = Vector3.Distance(numeralObjects[1].transform.position, displayVersion.transform.position);
    }
    /// <summary>
    /// 処理
    /// </summary>
    private void Move()
    {
        if (numeralObjects[1] != null)
        {
            numeralObjects[1].transform.position = Vector3.MoveTowards(numeralObjects[1].transform.position, displayVersion.transform.position, (distance1 / 1f) * Time.deltaTime);
            animator.SetBool(key_isSpot, true);
            if (numeralObjects[1].transform.position == displayVersion.transform.position)
            {
                GameObject.Destroy(numeralObjects[0]);
                numeralObjects[0] = numeralObjects[1];
                numeralObjects[1] = null;
                End();
            }
        }
    }
    /// <summary>
    /// 完了　
    /// </summary>
    private void End()
    {
        inputON = true;
        animator.SetBool(key_isSpot, false);
        ontology.GetComponent<InputmonitorControlScript>().Certification();
    }
    /// <summary>
    ///   プレイヤーﾄ接続
    /// </summary>
    void OnTriggerStay2D(Collider2D collision)
    {

          if (collision.tag == "Player") {
            Debug.Log("!");
            }

        if (collision.name == "Player" && inputON && (Input.GetKeyDown(KeyCode.Space) || DSInput.PushDown(DSButton.Circle)))
        {
            InputStart();
        }
    }
    //テスト用
    /* void InputTest() {
         if (inputON && (Input.GetKeyDown(KeyCode.Space) || DSInput.PushDown(DSButton.Circle))) {
             InputStart();
         } else if (!inputON && (Input.GetKeyDown(KeyCode.Space) || DSInput.PushDown(DSButton.Circle))) {
             Debug.Log("!inputON");
         }
     }*/

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"&& collision.transform.position.x < displayVersion.transform.position.x + 0.5f && collision.transform.position.x > displayVersion.transform.position.x - 0.5f )
        {
            isMyPos = true;
        }

    }
    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player" && collision.transform.position.x < displayVersion.transform.position.x + 0.5f && collision.transform.position.x > displayVersion.transform.position.x - 0.5f)
        {
            isMyPos = false;
        }
    }


}
