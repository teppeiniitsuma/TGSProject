using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D ri2d;
    [SerializeField]
    private float walk = 0f;
    [SerializeField]
    private float max = 2.0f;
    private int key = 0;
    void Start() { ri2d = GetComponent<Rigidbody2D>(); }
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) { walk = 30f; key = 1; } 
        else if (Input.GetKey(KeyCode.A)) { walk = 30f; key = -1; } else { walk = 0f; }
        float xWalk = Mathf.Abs(this.ri2d.velocity.x);
        if (xWalk < this.max) { this.ri2d.AddForce(transform.right * key * this.walk); }
        if(key != 0) { transform.localScale = new Vector3(key, 1, 1); }
    }
}
