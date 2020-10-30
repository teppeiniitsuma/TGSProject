using UnityEngine;

public class NewCameraManager : MonoBehaviour
{
    const float CAMERA_DISTANCE = 8.4f; // カメラの幅

    /// <summary>
    /// カメラの範囲内にいるかをチェックする
    /// </summary>
    /// <param name="pos">チェックするオブジェクトのベクター</param>
    /// <returns></returns>
    public bool CheckCameraPos(Vector3 pos)
    {
        if(transform.position.x - CAMERA_DISTANCE < pos.x && pos.x < transform.position.x + CAMERA_DISTANCE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
