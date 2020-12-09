using UnityEngine;

// 蜘蛛の位置を確認しDisplaySpiderCounterと情報をやりとりする
public class ConfirmationSpiderPosition : MonoBehaviour
{
    [SerializeField] private StageType _stage;
    DisplaySpiderCounter _disp;
    NewCameraManager _cameraManager;
    bool count = false;

    enum StageType 
    {
        Normal,
        Last,
    }

    private void Awake()
    {
        _disp = FindObjectOfType<DisplaySpiderCounter>();
        _cameraManager = FindObjectOfType<NewCameraManager>();
    }
    /// <summary>
    /// 蜘蛛が倒されたら呼ぶ
    /// </summary>
    public void DieEnemy()
    {
        _disp.ClearSpiders();
        this.transform.parent.gameObject.SetActive(false);
    }
    void Update()
    {
        if (_cameraManager.CheckCameraPos(transform.position) && !count)
        {
            _disp.SpiderAddCount(transform);
            count = true;
        }
        else if(!_cameraManager.CheckCameraPos(transform.position) && count)
        {
            if(_stage == StageType.Normal)
            {
                _disp.SpiderDelCount(transform);
                _disp.ClearSpiders();
                count = false;
            }
        }
    }
}
