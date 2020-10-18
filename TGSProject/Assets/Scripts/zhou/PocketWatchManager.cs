using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI　時計
/// </summary>
public class PocketWatchManager : MonoBehaviour
{   //針と影
    [Header("時計の影")]
    [SerializeField]private Image image;
    [Header("時計の針")]
    [SerializeField] private RectTransform rectTransform;
    [Header("時計の周り速度")]
    [SerializeField] private float speed;
    bool isnoe = false;


    //蓋上げ
    [Header("時計の蓋")]
    [SerializeField] private GameObject lid;

    [Header("上げる速度")]
    [SerializeField] float rotateSpeed = 2f;
    [SerializeField] private Quaternion targetAngels;

    //移動
    [Header("PocketWatchPos")]
    [SerializeField] private GameObject pocketWatchPos;
    [Header("StartPos")]
    [SerializeField] private Transform startMarker;
    [Header("EndPos")]
    [SerializeField] private Transform end1Marker, end2Marker;
    [SerializeField] private bool isDown=true;
    public float moveTIme = 1.0F;
    //二点間の距離を入れる
    private float distance_two, distance_two2;

    private void Start()
    {
        targetAngels = Quaternion.Euler(0, 90f, 0);
        PocketWatchReset();
    }
    void Update()
    {
        LidOpen();
        PocketWatchMoving();
        PocketWatchMove();
    }
    /// <summary>
    /// 時計影と針ををリセット
    /// </summary>
    public void PocketWatchReset()
    {
        // リセットするたびに上に上がるのを防止（後により良い処理に変更）
        this.transform.position = this.transform.parent.position;
        //影
        image.fillAmount = 0;
        isnoe = false;
        //角度リセット
        rectTransform.rotation = Quaternion.Euler(0, 0, 0.0f);
        lid.transform.rotation = Quaternion.Euler(0, 0, 0.0f);
        //ＰＯＳリセット
        transform.position = startMarker.position;
        //二点間の距離を代入(スピード調整に使う)
        distance_two = Vector3.Distance(startMarker.position, end1Marker.position);

        isDown = true;
    }

    void LidOpen() {
        lid.transform.rotation = Quaternion.Slerp(lid.transform.rotation, targetAngels, rotateSpeed * Time.deltaTime);
        // オブジェクの角度と　目標角度の差がより小さい　オブジェク角度＝目標角度　
        if (Quaternion.Angle(targetAngels, lid.transform.rotation) < 1)
        {
            lid.transform.rotation = targetAngels;
        }
    }
    /// <summary>
    /// 時計回る
    /// </summary>
    void PocketWatchMove() {
        if (image.fillAmount < 1.0f) {
        image.fillAmount += Time.deltaTime / speed;
        rectTransform.rotation = Quaternion.Euler(0, 0, -image.fillAmount * 360.0f);

        }else if (image.fillAmount == 1.0f&&!isnoe) {
            isnoe = true;
            //Debug.Log("時計 もう　一輪回りました。時間切りの処理を");
            GameManager.Instance.SetGameState(GameManager.GameState.Damage);
            ///PocketWatchReset();
        }
    }
    /// <summary>
    /// 移動
    /// </summary>
    void PocketWatchMoving() {
        if (isDown)
        {
            // 現在の位置
            float present_Location = (Time.time * (distance_two / moveTIme)) / distance_two;
            // オブジェクトの移動
            pocketWatchPos.transform.position = Vector3.Lerp(startMarker.position, end1Marker.position, present_Location);
            if (pocketWatchPos.transform.position == end1Marker.position) {
                isDown = false;
                //二点間の距離を代入(スピード調整に使う)
                distance_two2 = Vector3.Distance(end1Marker.position, end2Marker.position);
               

            }

        }
        else if (!isDown) {

            float present_Location = (Time.time * (distance_two2/moveTIme/2)) / distance_two2;
            // オブジェクトの移動
            pocketWatchPos.transform.position = Vector3.Lerp(end1Marker.position, end2Marker.position, present_Location);
        }
       
    }
}
