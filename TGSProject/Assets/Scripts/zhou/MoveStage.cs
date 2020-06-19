using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStage : MonoBehaviour
{
    [SerializeField] GameObject floor;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.parent = transform.parent;
            floor.GetComponent<BoxCollider2D>().isTrigger = true;
            // transform.SetParent(col.transform);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.parent = transform.parent;
            floor.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
