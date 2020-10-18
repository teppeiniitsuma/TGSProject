using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDown : MonoBehaviour
{
    [SerializeField]
    private GameObject[] foot = new GameObject[16];
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        DeleteFoot();
    }

    private void DeleteFoot()
    {
        foreach (var g in foot) { Destroy(g); }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("Down");
    }
}
