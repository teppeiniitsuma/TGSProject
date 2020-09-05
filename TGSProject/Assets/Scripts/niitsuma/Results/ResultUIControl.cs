using System.Collections;
using UnityEngine;

public class ResultUIControl : MonoBehaviour
{
    [SerializeField] private GameObject _resultUI;

    void ResultUISet()
    {
        _resultUI.SetActive(true);
    }
    void Update()
    {
        if (GameManager.Instance.GetGameState == GameManager.GameState.Result)
            ResultUISet();
    }
}
