using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI　時計
/// </summary>
public class PocketWatchManager : MonoBehaviour
{
    [Header("時計の影")]
    [SerializeField]private Image image;
    [Header("時計の針")]
    [SerializeField] private RectTransform rectTransform;
    [Header("時計の周り速度")]
    [SerializeField] private float speed;
    /// <summary>
    /// 時計影と針ををリセット
    /// </summary>
    void PocketWatchReset()
    {
        image.fillAmount = 0;
        rectTransform.rotation = Quaternion.Euler(0, 0, 0.0f);
    }
    void Update()
    {
        PocketWatchMove();
    }
    /// <summary>
    /// 時計回る
    /// </summary>
    public void PocketWatchMove() {
        image.fillAmount += Time.deltaTime / speed;
        rectTransform.rotation = Quaternion.Euler(0, 0, -image.fillAmount * 360.0f);
        if (image.fillAmount == 1.0f) {
            Debug.Log("時計　もう一輪回りました。");
        }
    }
}
