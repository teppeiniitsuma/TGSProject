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
            collider.gameObject.transform.parent = transform.parent;
          //  Debug.Log("OnTriggerEnter2D");
        }
      //  Debug.Log(collider.name);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            floor.GetComponent<BoxCollider2D>().isTrigger = false;
            collider.gameObject.transform.parent = null;


         //   Debug.Log(floor.GetComponent<BoxCollider2D>().isTrigger);
     
        }
    }




}
//-3.1
//-1.7+-2.8 -4.5 -1.4