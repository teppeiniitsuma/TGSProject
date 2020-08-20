using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextStage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Player") {
            //StageMove.LoadNextSchene();
            StageMove.ResultLoad();
        }
    }
}
