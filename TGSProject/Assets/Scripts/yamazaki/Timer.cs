using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float countTime = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime; // スタートしてからの秒数を格納

        GetComponent<Text>().text = countTime.ToString("F2"); // 少数2桁にして表示
    }
}
