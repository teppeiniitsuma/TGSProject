using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimasions : MonoBehaviour
{
    private Animator _animetor;
    [SerializeField]
    [Header("↓↓アニメーションの速度")]
    protected float playSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        this._animetor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this._animetor.speed = playSpeed;
    }
}
