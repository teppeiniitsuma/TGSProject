using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMori : MonoBehaviour
{
    private const float cameraDist = 12.4f; // カメラの幅の憶測

    /// <summary>
    /// カメラの範囲内にいるかをチェックする
    /// </summary>
    /// <param name="pos">チェックするオブジェクトのベクター</param>
    /// <returns></returns>
    public bool CheckCameraPos(Vector3 pos)
    {
        if (transform.position.x - cameraDist < pos.x && pos.x < transform.position.x + cameraDist)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
