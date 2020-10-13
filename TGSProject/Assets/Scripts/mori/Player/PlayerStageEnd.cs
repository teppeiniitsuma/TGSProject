using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStageEnd : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    StageThaPlayer stp;
    [SerializeField] private FadeController _fade;

    private bool IsArrived = false;

    private void Start()
    {
        stp = player.GetComponent<StageThaPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            stp.isTarget = true;
            Debug.Log("f");
        }
    }

    void Update()
    {
        if (stp.isTarget && !IsArrived) { _fade.Fade(false, () => StageConsole.MyLoadScene(StageConsole.MyScene.Result)); IsArrived = true; }
    }
}
