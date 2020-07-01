using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualShockInput;

public class BridgeLevelScript : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] BridgeScript bri;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"/* && (Input.GetKeyDown(KeyCode.Z) || DSInput.PushDown(DSButton.Circle))*/)
        {
            Debug.Log("OpenLevel");
            bri.isLever = true;
            gameObject.GetComponent<BridgeScript>().OpenLevel();
        }
    }

}
