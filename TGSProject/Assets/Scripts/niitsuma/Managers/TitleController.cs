using UnityEngine;
using UnityEngine.SceneManagement;
using DualShockInput;

public class TitleController : MonoBehaviour
{
    [SerializeField] private GameObject _systemUI = null;

    private void Start()
    {
        ScenarioMessageUseCase.scenarioNum = 0;
        _systemUI.SetActive(false);
    }

    void SetingSystem()
    {
        _systemUI.SetActive(true);
        ControllerSystem.SetSystem = true;
    }
    void TitleMove()
    {
        if (Input.GetKeyDown(KeyCode.P) || DSInput.PushDown(DSButton.Option))
        {
            ControllerSystem.SetSystem = true;
        }
        if (!ControllerSystem.SetSystem)
        {
            _systemUI.SetActive(false);
            if (DSInput.PushDown(DSButton.Circle) || Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("StageSelect");
            }
        }
        else
        {
            SetingSystem();
        }
    }

    // Update is called once per frame
    void Update()
    {
        TitleMove();
    }
}
