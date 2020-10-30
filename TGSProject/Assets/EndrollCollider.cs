using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndrollCollider : MonoBehaviour
{
    [SerializeField] private FadeController _fade;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _fade.Fade(false, () => StageConsole.MyLoadScene(StageConsole.MyScene.Endroll));
        }
    }
}
