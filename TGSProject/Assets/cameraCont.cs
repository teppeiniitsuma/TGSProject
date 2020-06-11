using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCont : MonoBehaviour
{
    [SerializeField] Transform camera;
    bool tach = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") { tach = true; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tach) { camera.position = new Vector3(Mathf.MoveTowards(camera.position.x, 16f, Time.deltaTime * 3), camera.position.y, -10); }
    }
}
