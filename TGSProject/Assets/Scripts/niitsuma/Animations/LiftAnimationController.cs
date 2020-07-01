using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftAnimationController : MonoBehaviour
{
    Animator anime;

    float _startTime = 0.0f;
    float stopTime = 0;
    bool change = false;

    void Start()
    {
        anime = GetComponent<Animator>();
    }

    void LiftMove()
    {
        if(GameManager.Instance != null)
        {
            if (GameManager.Instance.GetGameState == GameManager.GameState.Main)
            {
                anime.speed = 1;
                if (stopTime < 5)
                {
                    stopTime += Time.deltaTime;
                }

                else
                {
                    bool temp = anime.GetBool("LiftChange");
                    anime.SetBool("LiftChange", !temp);
                    stopTime = 0;
                }
            }
            else
            {
                anime.speed = 0;
            }
        }
        
        else
        {
            anime.speed = 0.7f;
            if (stopTime < 5)
            {
                stopTime += Time.deltaTime;
            }

            else
            {
                bool temp = anime.GetBool("LiftChange");
                anime.SetBool("LiftChange", !temp);
                stopTime = 0;
            }
            
        }
        
    }

    void Update()
    {
        LiftMove();

    }
}
