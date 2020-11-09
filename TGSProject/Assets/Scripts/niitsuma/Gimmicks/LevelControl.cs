using UnityEngine;

public class LevelControl : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _actionUI;
    [SerializeField] private Animator _keyAnim;
    int count = 0;

    [SerializeField, Tooltip("Bridgeを入れる")] BridgeScript bri;

    // ギミックが作動したらtrue
    public bool IsActuation { get; set; } = false;
    // 一度作動したらtrueにする
    bool _endActuation = false;

    
    void Start()
    {
        _actionUI.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
        _actionUI.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        count--;
        _actionUI.enabled = false;
    }
    private void Update()
    {
        if (_endActuation) return;

        if (IsActuation && !_endActuation)
        {
            SoundManager.PlayMusic("Audios/Gimmick/level", false);
            bri.isLever = true;
            bri.OpenLevel();
            _endActuation = true;
            if(null != _keyAnim) _keyAnim.gameObject.SetActive(true);
            SoundManager.PlayMusic("Audios/Gimmick/bridrg_locked", false);
        }
    }
}
