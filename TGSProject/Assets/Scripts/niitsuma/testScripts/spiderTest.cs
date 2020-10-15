using UnityEngine;

public class SpiderTest : MonoBehaviour
{ 
    DisplaySpiderCounter disp;
    NewCameraManager _cameraManager;
    bool count = false;

    private void Awake()
    {
        disp = FindObjectOfType<DisplaySpiderCounter>();
        _cameraManager = FindObjectOfType<NewCameraManager>();
        Debug.Log("flsajl");
    }
    /// <summary>
    /// 蜘蛛が倒されたら呼ぶ
    /// </summary>
    public void DieEnemy()
    {
        disp.ClearSpiders();
        this.transform.parent.gameObject.SetActive(false);
    }
    void Update()
    {
        if (_cameraManager.CheckCameraPos(transform.position) && !count)
        {
            disp.spiderAddCount(transform);
            count = true;
        }
        else if(!_cameraManager.CheckCameraPos(transform.position) && count)
        {
            disp.spiderDelCount(transform);
            count = false;
        }
    }
}
