using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class BossStartEventControl : MonoBehaviour
{
    [SerializeField] private Light2D cameraLight;
    [SerializeField] private Light2D herbLight;
    [SerializeField] private BossEventStart bossEvent;
    [SerializeField] private SpiderYarn yarn;
    bool scenerioEnd = false;

    void Update()
    {
        if(bossEvent.EventStart)
        {
            yarn.enabled = true;
            cameraLight.lightType = Light2D.LightType.Global;
            herbLight.gameObject.SetActive(false);
            scenerioEnd = true;
        }
        if(GameManager.Instance.GetGameState == GameManager.GameState.Main && scenerioEnd)
        {
            StageConsole.MyLoadScene(StageConsole.MyScene.BossStage);
        }
    }
}
