using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputmonitorControlScript : MonoBehaviour
{
    [Header("数字ギミック")]
    [SerializeField]
    public　GameObject[] inputmonitor = new GameObject[3];
    [Header("数字ギミックスクリプト")]
    [SerializeField]
    InputmonitorScript[] inputMonitorSprite = new InputmonitorScript[3];
    [Header("正しい暗証番号")]
    [SerializeField]
    string truePasssword;
    [Header("入力中ﾉ暗証番号")]
    [SerializeField]
    string password;

    bool isMyPos;


    [Header("animeGameObject")]
    [SerializeField]
    private GameObject animeGameObject;//

    private Animator animator;
    public const string key_isEnd = "isEnd";
    [Header("NumberLock_Gate")]
    [SerializeField]
    private GameObject numberLock_Gate;//

    private Animator numberLock_GateAnimator;
    public const string key_isON = "isON";
    [SerializeField]
    private GameObject  numberLock_Flag;

    public GameObject playerPos;
    public Space rotateSpace;
    [SerializeField]
    private GameObject[]NumberLock_Button;
   
    void Start()
    {
        animator = animeGameObject.GetComponent<Animator>();
        numberLock_GateAnimator = numberLock_Gate.GetComponent<Animator>();
        playerPos = null;
        //   atext = a.ToString();
        for (int i = 0; i < inputmonitor.Length; i++) {
            inputMonitorSprite[i] = inputmonitor[i].GetComponent<InputmonitorScript>();
        }
            
    }
    private void Update()
    {

       // Debug.Log(transform.localScale.x);
        if (password != truePasssword&& playerPos !=null && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.A)))
        {
            InputmonitorScriptStart();
            Debug.Log("Update");
        }
    }
    /// <summary>
    /// 暗証番号を認識
    /// </summary>
    public void Certification()
    {
        password = null;
        for (int i = 0; i < inputmonitor.Length; i++)
        {
            int num = inputmonitor[i].GetComponent<InputmonitorScript>().myNumeral;
            string text = num.ToString();

            password = password + text;
        }
        if (password == truePasssword && inputmonitor[0].GetComponent<InputmonitorScript>().numeralObjects[1] == null && inputmonitor[1].GetComponent<InputmonitorScript>().numeralObjects[1] == null && inputmonitor[2].GetComponent<InputmonitorScript>().numeralObjects[1] == null)
        {

            for (int i = 0; i < inputmonitor.Length; i++)
            {
                inputmonitor[i].GetComponent<InputmonitorScript>().enabled = false;
            }
            animator.SetBool(key_isEnd, true);
            numberLock_GateAnimator.SetBool(key_isON, true);
            //旗
            numberLock_Flag.GetComponent<SpriteRenderer>().enabled = true;
            // GameObject.Destroy(gameObject);
            //吹き出しオブジェクトを削除
      
            GetComponent<NumbersPresentationManager>().enabled = false;
            Destroy(GetComponent<NumbersPresentationManager>().newSpeechBubbleGameObject,0.5f);
            //スクリプト　を止める
            GetComponent<InputmonitorControlScript>().enabled = false;
        }
    }
    void InputmonitorScriptStart() {
        if (inputMonitorSprite[0].inputON == true &&
        inputMonitorSprite[1].inputON == true &&
        inputMonitorSprite[2].inputON == true ) {

            if (playerPos != null &&
                playerPos.transform.position.x >= transform.position.x - 0.50f*transform.localScale.x &&
                playerPos.transform.position.x <= transform.position.x + 0.50f * transform.localScale.x)
            {
                inputMonitorSprite[1].InputStart();
                NumberLock_Button[1].transform.Rotate(new Vector3(0, 0, -36), rotateSpace);
            }
            else if (playerPos != null && playerPos.transform.position.x > transform.position.x + 0.50f * transform.localScale.x)
            {
                inputMonitorSprite[2].InputStart();
                NumberLock_Button[2].transform.Rotate(new Vector3(0, 0, -36), rotateSpace);
            }
            else if ( playerPos != null && playerPos.transform.position.x < transform.position.x - 0.50f * transform.localScale.x) 
            {
                inputMonitorSprite[0].InputStart();
                NumberLock_Button[0].transform.Rotate(new Vector3(0, 0, -36), rotateSpace);
            }
        }
    }

   /*
    * void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "player")
        {
            Debug.Log("OnTriggerEnter2D");
            playerPos = collider.gameObject;
        }
    }*/
    
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name == "player")
        {
          //  Debug.Log("OnTriggerStay2D");
            playerPos = collider.gameObject;
        }

    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "player")
        {
           // Debug.Log("OnTriggerExit2D");
            playerPos = null;
        }
    }




}

