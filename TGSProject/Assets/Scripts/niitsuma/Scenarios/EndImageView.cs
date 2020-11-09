using UnityEngine;

public class EndImageView : MonoBehaviour
{
    [SerializeField] private FadeController _endImagefade;
    [SerializeField] private FadeController _fadeUI;

    float time = 0;
    float endTime = 4f;
    bool endTrigger = false;
    bool isFade = false;

    void Start()
    {
        _endImagefade.ColorInitialize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            endTrigger = true;
        }
    }
    void Update()
    {
        if (endTrigger)
        {
            GameManager.Instance.SetGameState(GameManager.GameState.Result);
            if (!isFade) _endImagefade.Fade(false, () => _fadeUI.Fade(false,
                                             () => StageConsole.MyLoadScene(StageConsole.MyScene.Endroll)));
            isFade = true;
        }
    }
}
