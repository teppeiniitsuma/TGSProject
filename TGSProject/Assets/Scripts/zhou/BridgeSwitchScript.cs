using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSwitchScript : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            gameObject.GetComponent<BridgeScript>().isSwitchUp = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            gameObject.GetComponent<BridgeScript>().isSwitchUp = false;
        }
    }
}
