using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualShockInput;

public class BridgeLevelScript : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player"&&(Input.GetKeyDown(KeyCode.Space) || DSInput.PushDown(DSButton.Circle))) { 
                Debug.Log("OpenLevel");
                gameObject.GetComponent<BridgeScript>().OpenLevel();
            }
        }
}
