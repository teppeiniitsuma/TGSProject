using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjurePlayerCollider : MonoBehaviour
{
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "Player")
            {
                Debug.Log("HP減り処理");
            GameManager.Instance.Information.DecreaseHP();
                //float x, y;
                //-2 2
                //-5 5
                //if (collider.gameObject.transform.position.x > gameObject.transform.position.x) { x = 5; } else { x = -5; }
                //if (collider.gameObject.transform.position.y > -1) { y = 2; } else { y=-2; }
                //collider.transform.position = new Vector3(gameObject.transform.position.x+x,y,0);
            }
        }
}
