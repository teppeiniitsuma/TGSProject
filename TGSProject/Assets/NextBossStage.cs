using UnityEngine;

public class NextBossStage : MonoBehaviour
{
    [SerializeField] FadeController _fade;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(PlayerInfoCounter.Instance.GetItemValue.butteflyWingValue == 6)
            {
                Debug.Log("ok"); ResultManager.TrueEnd = true;
            }
            
            _fade.Fade(false, () => StageConsole.MyLoadScene(StageConsole.MyScene.BossStageStart));
        }
    }
}
