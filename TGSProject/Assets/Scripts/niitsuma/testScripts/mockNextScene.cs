using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DualShockInput;

public class mockNextScene : MonoBehaviour
{
    void NextScene()
    {
        if (DSInput.PushDown(DSButton.Circle) || Input.GetKeyDown(KeyCode.Space)){ SceneManager.LoadScene("Stage1"); }
    }

    // Update is called once per frame
    void Update()
    {
        NextScene();
    }
}
