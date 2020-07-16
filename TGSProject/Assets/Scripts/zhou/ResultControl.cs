﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResultControl : MonoBehaviour
{

    [SerializeField] private GameObject rigth, stageBG;
    [SerializeField] private GameObject[] stageImege1;
    [SerializeField] private GameObject[] stageImege2;
    [SerializeField] private GameObject[] stageName;
    // isPlayerOperational
    [SerializeField] private bool isPlayerOperational, SceneMove;
    //  rigthPos
    [SerializeField] private bool isTitle=true;
    // 
    [SerializeField] private int i;

    // Start is called before the first frame update
    void Start()
    {//GetComponent().color = new Color(changeRed, changeGreen, cahngeBlue,
        //stageImege1[1].GetComponent<SpriteRenderer>().color = new Vector4(0, 0, 0, 0);
        stageImege2[1].GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0);

        //Rigth  start Pos
        rigth.GetComponent<Transform>().position = new Vector3(
            stageImege1[0].GetComponent<Transform>().position.x + 1.2f,
             stageImege1[0].GetComponent<Transform>().position.y + 2.0f,
             rigth.GetComponent<Transform>().position.z
            );
        isPlayerOperational = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerOperational();
        ImegeMove();
        stageBGMove();

    }
    private void PlayerOperational()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && isPlayerOperational)
        {
            i++;
            i = i % 2;
            Debug.Log("stage" + i + 1);
            isPlayerOperational = false;
        }
        //✖
        if (Input.GetButtonDown("Fire2"))
        {
            isPlayerOperational = false;
            SceneMove = true;
        }
        //〇
        if (Input.GetButtonDown("Fire3") && isPlayerOperational)
        {
            isPlayerOperational = false;
            isTitle = false;
            SceneMove = true; 
        }
    }
    private void ImegeMove()
    {
        if (!isPlayerOperational)
        {
            stageImege2[i].GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, stageImege2[i].GetComponent<SpriteRenderer>().color.a + Time.deltaTime);
            int a = (i + 1) % 2;
            stageImege2[a].GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, stageImege2[a].GetComponent<SpriteRenderer>().color.a - Time.deltaTime);
             rigth.GetComponent<Transform>().position = new Vector3(
            stageImege1[i].GetComponent<Transform>().position.x + 1.2f,
             stageImege1[i].GetComponent<Transform>().position.y + 2.0f,
             rigth.GetComponent<Transform>().position.z
            );
            if (stageImege2[i].GetComponent<SpriteRenderer>().color.a >= 1.0f)
            {
                isPlayerOperational = true;
            }
            Debug.Log("ステージまでセットしてません。");
            //
        }
    }
    private void stageBGMove()
    {if(SceneMove)
        stageBG.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, stageBG.GetComponent<SpriteRenderer>().color.a + Time.deltaTime);
        if (stageBG.GetComponent<SpriteRenderer>().color.a >= 1.0f)
        {
            if (isTitle) {
                StageConsole.MyLoadScene(StageConsole.MyScene.Title);
            }
            if (i == 0) {
                StageConsole.MyLoadScene(StageConsole.MyScene.Stage1);
            }
            if (i == 1) {
                StageConsole.MyLoadScene(StageConsole.MyScene.Stage2);
            }
           
        }
    }
}
