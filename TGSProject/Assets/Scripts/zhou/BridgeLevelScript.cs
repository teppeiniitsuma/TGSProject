using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualShockInput;

public class BridgeLevelScript : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    bool isDown;
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player"&& isDown)
        {
            gameObject.GetComponent<BridgeScript>().OpenLevel();
        }
    }
     void GetKey() {
        if (Input.GetKeyDown(KeyCode.Space) || DSInput.PushDown(DSButton.Circle)) {
            isDown = true; 
        } else { isDown = false; }
    }
    private void Update()
    {
        GetKey();
    }
}
