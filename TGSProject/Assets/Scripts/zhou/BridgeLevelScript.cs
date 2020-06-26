using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeLevelScript : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (Input.GetButtonDown("Fire3") || Input.GetKey(KeyCode.Space)) {
                Debug.Log("もし入力が欲しい場合");
                gameObject.GetComponent<BridgeScript>().OpenLevel();
            }
        }
    }
   /* private void Update()
    {
        if (Input.GetButtonDown("Fire3")){
            Debug.Log("3");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space");
        }
    }*/
}
