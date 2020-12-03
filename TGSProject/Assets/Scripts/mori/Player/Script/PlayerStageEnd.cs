using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStageEnd : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    StageThePlayer stp;
    [SerializeField] private FadeController _fade;
    public EndPlayerType playerType;

    private bool IsArrived = false;

    private void Start()
    {
        stp = player.GetComponent<StageThePlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            switch (playerType)
            {
                case EndPlayerType.Default:
                    stp.isTarget = true;
                    break;
                case EndPlayerType.NormalEnd:
                    _fade.Fade(false, () => akb());
                    break;
            }
            //Debug.Log("f");
        }
    }
    //PlayerStageEnd
    void akb()
    {
        SceneManager.LoadScene("NormalEnd");
    }

    void Update()
    {
        switch (playerType)
        {
            case EndPlayerType.Default:
                if (stp.isTarget && !IsArrived) { _fade.Fade(false, () => StageConsole.MyLoadScene(StageConsole.MyScene.Result)); IsArrived = true; }
                break;
            case EndPlayerType.NormalEnd:
                break;
        }
    }
}
