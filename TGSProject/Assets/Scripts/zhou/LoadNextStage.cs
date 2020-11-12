using UnityEngine;

public class LoadNextStage : MonoBehaviour
{
    PlayerInfoCounter info;

    private void Start()
    {
        info = PlayerInfoCounter.Instance;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && info.GetParameter.actSwitch && info.GetItemValue.herbValue <= 0)
        {
            //StageMove.LoadNextSchene();
            StageConsole.MyLoadScene(StageConsole.MyScene.BetweenStage);
        }
    }
    //void OnTriggerEnter2D(Collider2D coll) {
    //    if (coll.tag == "Player" && GameManager.Instance.Information.GetParameter.actSwitch) {
    //        //StageMove.LoadNextSchene();
    //        StageConsole.MyLoadScene(StageConsole.MyScene.BetweenStage);
    //    }
    //}
}
