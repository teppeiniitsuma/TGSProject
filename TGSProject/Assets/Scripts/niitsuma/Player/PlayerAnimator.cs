using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] GameObject playerAnim;
    public bool ActAnimaStart { get; set; } = false;
    public bool ActAnimaEnd { get; set; } = false;

    void Start()
    {
        playerAnim.SetActive(false);
    }

    public void ActAnimatorPlay()
    {
        playerAnim.SetActive(true);
    }
    public void ActAnimatorEnd()
    {
        playerAnim.SetActive(false);
    }
}
