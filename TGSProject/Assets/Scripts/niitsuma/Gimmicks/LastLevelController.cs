using DualShockInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _actionUI;
    [SerializeField] private GameObject[] _defaultLevels = new GameObject[3];
    [SerializeField] private GameObject _breakLevel;
    [SerializeField] private CameraEvent _cameraEvent;
    [SerializeField]
    LastEnemy lastEne;

    Animator anime;
    bool touch = false;

    // ギミックが作動したらtrue
    public bool IsActuation { get; set; } = false;
    // 一度作動したらtrueにする
    bool _endActuation = false;

    void Start()
    {
        _actionUI.enabled = false;
        anime = GetComponent<Animator>();
        anime.speed = 0;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touch = false;
        }
    }
    void LevelMove()
    {
        if (touch && !_endActuation)
        {
            _actionUI.enabled = true;
            if (!lastEne.isLeverLaunched)
            {
                if (Input.GetKeyDown(KeyCode.Z) || DSInput.PushDown(DSButton.Circle))
                {
                    anime.speed = 1;
                    _endActuation = true;
                    _cameraEvent.SwayingCamera();
                    StartCoroutine(BreakLevel());
                    lastEne.isLeverLaunched = true;
                }
            }
        }
        else if (!touch && !_endActuation)
        {
            _actionUI.enabled = false;
        }
    }

    IEnumerator BreakLevel()
    {
        yield return new WaitForSeconds(2.0f);
        _actionUI.enabled = false;
        anime.enabled = false;
        for(int i = 0; i < _defaultLevels.Length; i++)
        {
            _defaultLevels[i].gameObject.SetActive(false);
        }
        _breakLevel.SetActive(true);
    }
    private void Update()
    {
        LevelMove();
    }
}
