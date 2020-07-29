using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLevelScript : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] bool ON;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TestViodElevatorON();
        }
    }
    void TestViodElevatorON() {
      //  Debug.Log("ElevatorON");
        gameObject.GetComponent<ElevatorController>().isManual = false;
        this.GetComponent<ElevatorLevelScript>().enabled=false;
    }
    private void Update()
    {
        if (ON) {
            TestViodElevatorON();
        }
        
    }
}
