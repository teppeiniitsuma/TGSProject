using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeLevelScript : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("もし入力が欲しい場合");
            gameObject.GetComponent<BridgeScript>().OpenLevel();
            
        }
    }
}
