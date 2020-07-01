using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAnimationController : MonoBehaviour
{
    Animator anime;
    void Start()
    {
        anime = GetComponent<Animator>();
        anime.speed = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") { anime.speed = 1; }
    }
}
