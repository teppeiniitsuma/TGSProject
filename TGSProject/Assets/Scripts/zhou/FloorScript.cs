using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    [SerializeField] GameObject floor;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player") {
            floor.GetComponent<BoxCollider2D>().isTrigger = true;

        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            floor.GetComponent<BoxCollider2D>().isTrigger = false;
     
        }
    }




}
//-3.1
//-1.7+-2.8 -4.5 -1.4