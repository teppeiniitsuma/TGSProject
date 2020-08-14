using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameOver : MonoBehaviour
{
    bool temp = false;
    private IEnumerator LoadScene()
    {
        var async = SceneManager.LoadSceneAsync("GameOver");

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(1.5f);
        async.allowSceneActivation = true;
    }

    void Update()
    {
        if (GameManager.Instance.GetGameState == GameManager.GameState.GameOver && !temp)
        {
            temp = !temp;
            StartCoroutine(LoadScene());
        }
    }
}