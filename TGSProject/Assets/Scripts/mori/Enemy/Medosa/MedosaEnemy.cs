using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedosaEnemy : BaseEnemy
{
    private Animator animetor;
    [SerializeField]
    [Header("↓↓アニメーションの再生速度")]
    private float playSpeed = 1.0f;

    void Start()
    {
        this.animetor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.animetor.speed = playSpeed;
    }
}
