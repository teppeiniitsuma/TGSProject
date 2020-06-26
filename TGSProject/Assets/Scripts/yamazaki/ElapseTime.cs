using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElapseTime : MonoBehaviour
{
    GameObject elapseTime;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        this.elapseTime = GameObject.Find("elapseTime");
    }

    // 時間経過の度、少しずつ elapseTime を表示していく
    public void IncreaseGage()
    {
        this.elapseTime.GetComponent<Image>().fillAmount += Time.deltaTime / speed;
    }
}
