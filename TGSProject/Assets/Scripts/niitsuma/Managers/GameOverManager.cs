using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Image _scoreImage;
    float time = 0;

    void Start()
    {
        _scoreImage.gameObject.SetActive(false);
    }

    void SetScoreView()
    {
        time += Time.deltaTime;
        if(time > 4.2f) { _scoreImage.gameObject.SetActive(true); }
    }
    // Update is called once per frame
    void Update()
    {
        SetScoreView();
        if (Input.GetKeyDown(KeyCode.Space) || DualShockInput.DSInput.PushDown(DualShockInput.DSButton.Cross))
            SceneManager.LoadScene("Title");
    }
}
