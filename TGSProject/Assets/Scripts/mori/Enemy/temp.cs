using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            var da = collision.gameObject.GetComponent<BaseEnemy>();
            if (null != da) da.EnemyDamager();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
