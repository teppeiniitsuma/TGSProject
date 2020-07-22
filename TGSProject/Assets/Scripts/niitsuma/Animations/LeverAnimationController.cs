using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualShockInput;

public class LeverAnimationController : MonoBehaviour
{
    LevelControl lev;
    Animator anime;
    bool touch = false;

    void Start()
    {
        anime = GetComponent<Animator>();
        anime.speed = 0;
        lev = GetComponent<LevelControl>();
    }
    // ここは後にBridgeLevelSciriptをGetしてやるのもOK
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touch = false;
        }
    }
    private void Update()
    {
        if (touch)
        {
            if(Input.GetKeyDown(KeyCode.Z) || DSInput.PushDown(DSButton.Circle))
            {
                anime.speed = 1;
                lev.Actuation = true;
            }
        }
    }
}
