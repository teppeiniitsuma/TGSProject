using UnityEngine;
using UnityEngine.Video;

public class LastTrueMovie : MonoBehaviour
{
    [SerializeField] FadeController _faUI;
    [SerializeField]GameObject lastBossSpider;
    [SerializeField] GameObject medosa;
    [SerializeField] CollectedButterfly butterfly;
    //LastEnemy lsEnemy;
    private bool _videoPlay;
    public bool _videoStop { get; set; }
    float _deletionTime;
    void Start()
    {
        //lsEnemy = lastBossSpider.GetComponent<LastEnemy>();
        _videoPlay = false;
        _deletionTime = 38f;
    }

    private void BossVictory()
    {
        
        if(/*0 == lsEnemy.lastBossHp && */!_videoPlay)
        {
            _faUI.Fade(false, () => Deletion());            
            _videoPlay = true;
        }
    }

    private void Deletion()
    {
        var vdPlay = GetComponent<VideoPlayer>();
        vdPlay.Play();
        lastBossSpider.transform.parent.gameObject.SetActive(false);
        medosa.transform.parent.gameObject.SetActive(false);
    }

    void Update()
    {
        if (1 == butterfly._collectedButterfly)
        {
            BossVictory();
            if (_videoPlay)
            {
                if (0 >= _deletionTime) { _videoStop = true; }
                else { _deletionTime -= Time.deltaTime; }
            }
        }
    }
}
