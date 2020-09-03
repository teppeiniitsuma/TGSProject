using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputmonitorControlScript : MonoBehaviour
{
    [Header("数字ギミック")]
    [SerializeField]
    GameObject[] inputmonitor = new GameObject[3];
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
    private GameObject playerPos, numberLock_Flag;
    public Space rotateSpace;
    [SerializeField]
    private GameObject[]NumberLock_Button;
   
    void Start()
    {
        animator = animeGameObject.GetComponent<Animator>();
        numberLock_GateAnimator = numberLock_Gate.GetComponent<Animator>();
        //   atext = a.ToString();
    }
    private void Update()
    {
        if (playerPos !=null && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.A)))
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
        }
    }
    void InputmonitorScriptStart() {
        if (inputmonitor[0].GetComponent<InputmonitorScript>().inputON == true &&
        inputmonitor[1].GetComponent<InputmonitorScript>().inputON == true &&
        inputmonitor[2].GetComponent<InputmonitorScript>().inputON == true ) {

            if (playerPos != null &&
                playerPos.transform.position.x > transform.position.x - 0.80f &&
                playerPos.transform.position.x < transform.position.x + 0.80f)
            {
                inputmonitor[1].GetComponent<InputmonitorScript>().InputStart();
                NumberLock_Button[1].transform.Rotate(new Vector3(0, 0, -36), rotateSpace);
            }
            else if (playerPos != null && playerPos.transform.position.x > transform.position.x + 0.80f)
            {
                inputmonitor[2].GetComponent<InputmonitorScript>().InputStart();
                NumberLock_Button[2].transform.Rotate(new Vector3(0, 0, -36), rotateSpace);
            }
            else if ( playerPos != null && playerPos.transform.position.x < transform.position.x - 0.80f ) 
            {
                inputmonitor[0].GetComponent<InputmonitorScript>().InputStart();
                NumberLock_Button[0].transform.Rotate(new Vector3(0, 0, -36), rotateSpace);
            }
        }
    }/*
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "player") {
            Debug.Log("getOnTriggerStay2D");
        }
        if (other.name == "player" &&
            (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.A)))
        {
            if (playerPos==null) {
                playerPos = other.gameObject;
            }
          
            InputmonitorScriptStart();
            Debug.Log("getPlayerOnTriggerStay2D");

        }
    }*/
    
    void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.name == "player")
        {
            playerPos = collision.gameObject;
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            playerPos = null;
        }
    }
    
}


// 数字机关
//桥梁
//场景2
//石碑的消失
//电梯的物体 
//游戏结束关联？？