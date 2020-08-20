﻿using UnityEngine;

public class InjurePlayerCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            GameManager.Instance.Information.DecreaseHP();
        }
    }
}
