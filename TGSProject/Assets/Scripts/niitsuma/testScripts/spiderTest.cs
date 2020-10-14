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
    }

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
