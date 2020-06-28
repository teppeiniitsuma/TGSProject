using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElapseTime : MonoBehaviour
{
    //GameObject elapseTime;
    Image image;

    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        //this.elapseTime = GameObject.Find("elapseTime");
        image = GetComponent<Image>();
    }

    public void ClearMover()
    {
        image.fillAmount = 0;
    }
    // 時間経過の度、少しずつ elapseTime を表示していく
    public void IncreaseGage()
    {
        if(GameManager.Instance.GetGameState == GameManager.GameState.Main)
            image.fillAmount += Time.deltaTime / speed;
            /*this.elapseTime.GetComponent<Image>()*/
    }
}
