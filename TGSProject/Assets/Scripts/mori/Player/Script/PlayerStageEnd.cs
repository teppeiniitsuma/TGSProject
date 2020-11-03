using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStageEnd : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    StageThaPlayer stp;
    [SerializeField] private FadeController _fade;
    public EndPlayerType playerType;

    private bool IsArrived = false;

    private void Start()
    {
        stp = player.GetComponent<StageThaPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            switch(playerType)
            {
                case EndPlayerType.Deflt:
                    stp.isTarget = true;
                    break;
                case EndPlayerType.NormalEnd:
                    _fade.Fade(false, () => akb());
                    break;
            }
            //Debug.Log("f");
        }
    }

    void akb()
    {
        SceneManager.LoadScene("NormalEnd_Stage1");
    }

    void Update()
    {
        switch (playerType)
        {
            case EndPlayerType.Deflt:
                if (stp.isTarget && !IsArrived) { _fade.Fade(false, () => StageConsole.MyLoadScene(StageConsole.MyScene.Result)); IsArrived = true; }
                break;
            case EndPlayerType.NormalEnd:
                break;
        }
    }
}
