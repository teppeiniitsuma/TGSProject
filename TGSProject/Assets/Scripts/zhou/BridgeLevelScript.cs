using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualShockInput;

public class BridgeLevelScript : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] BridgeScript bri;
    // ギミックが作動したらtrue
    public bool Actuation { get; set; } = false;
    // 一度作動したらtrueにする
    bool _endActuation = false;

    private void Update()
    {
        if (Actuation && !_endActuation)
        {
            Debug.Log("OpenLevel");
            bri.isLever = true;
            gameObject.GetComponent<BridgeScript>().OpenLevel();
            _endActuation = true;
        }
    }

}
