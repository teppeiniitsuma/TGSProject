using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSwitchScript : MonoBehaviour
{
    //[SerializeField] GameObject gameObject;
    // 通れん壁
    [SerializeField] GameObject coll;

    [SerializeField] BridgeScript bri;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            bri.isSwitchUp = true;
            coll.gameObject.SetActive(false);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (!bri.isLever)
            {
                bri.isSwitchUp = false;
                coll.gameObject.SetActive(true);
            }

        }
    }
}
