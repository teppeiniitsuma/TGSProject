using UnityEngine;

public class EndSelecter : MonoBehaviour
{

    void Start()
    {
        if (ResultManager.TrueEnd) { ScenarioMessageUseCase.scenarioNum = 1; }
        else { Debug.Log("normalEnd"); }
    }

}
