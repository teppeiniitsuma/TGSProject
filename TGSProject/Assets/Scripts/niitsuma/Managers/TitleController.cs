using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DualShockInput;

public class TitleController : MonoBehaviour
{
    private void Start()
    {
        ScenarioMessageUseCase.scenarioNum = 0;
    }
    void NextScene()
    {
        if (DSInput.PushDown(DSButton.Circle) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("StageSelect");
        }
    }

    // Update is called once per frame
    void Update()
    {
        NextScene();
    }
}
