using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedosaAnimasion : MonoBehaviour
{
    private void OnBecameVisible()
    {   
        GetComponent<Animator>().enabled = true;
    }

    private void OnBecameInvisible()
    {
        GetComponent<Animator>().enabled = false;
    }
}
