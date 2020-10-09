using UnityEngine;

public class NewCameraManager : MonoBehaviour
{
    private const float cameraDistance = 8.4f; // カメラの幅の憶測

    /// <summary>
    /// カメラの範囲内にいるかをチェックする
    /// </summary>
    /// <param name="pos">チェックするオブジェクトのベクター</param>
    /// <returns></returns>
    public bool CheckCameraPos(Vector3 pos)
    {
        if(transform.position.x - cameraDistance < pos.x && pos.x < transform.position.x + cameraDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
