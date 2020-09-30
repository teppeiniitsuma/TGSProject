using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KietanoUseyaro : MonoBehaviour
{
    [SerializeField]
    GameObject aff;
    [SerializeField]
    GameObject ha;
    LastEnemy Last;

    private void Start()
    {
        Last = ha.GetComponent<LastEnemy>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Last.PTA)
        {
            aff.SetActive(true);
            Last.PTA = false;
        }
    }
}
