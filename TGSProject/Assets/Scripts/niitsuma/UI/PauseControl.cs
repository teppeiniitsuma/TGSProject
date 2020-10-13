using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    [SerializeField] private Image _panelImage;
    [SerializeField] private Image[] _yesImage = new Image[2];
    [SerializeField] private Image[] _noImage = new Image[2];
    [SerializeField] FadeController _fade;


    bool _selects = true; // yes == false , no == true

    void Start()
    {
        PanelReset();
    }

    void PanelReset()
    {
        _yesImage[0].gameObject.SetActive(false);
        _yesImage[1].gameObject.SetActive(true);
        _noImage[0].gameObject.SetActive(true);
        _noImage[1].gameObject.SetActive(false);
    }
    void PauseView()
    {
        _panelImage.gameObject.SetActive(true);
        if (_selects) 
        {
            _yesImage[0].gameObject.SetActive(true);
            _yesImage[1].gameObject.SetActive(false);
            _noImage[0].gameObject.SetActive(false);
            _noImage[1].gameObject.SetActive(true);
        }
        else
        {
            PanelReset();
        }
    }

    void PauseNotView()
    {
        PanelReset();
        _panelImage.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) { GameManager.Instance.SetGameState(GameManager.GameState.Pause); }
        if(GameManager.Instance.GetGameState == GameManager.GameState.Pause)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)) { _selects = true; }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { _selects = false; }
            PauseView();

            if (_selects) 
            {
                if (Input.GetKeyDown(KeyCode.Z)) 
                {
                    PanelReset(); GameManager.Instance.SetGameState(GameManager.GameState.Main);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    PanelReset();
                    _fade.Fade(false, () => StageConsole.MyLoadScene(StageConsole.MyScene.Title));
                }
            }
        }
        else
        {
            PauseNotView();
        }
    }
}
