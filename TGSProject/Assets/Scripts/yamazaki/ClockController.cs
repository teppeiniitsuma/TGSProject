using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    [SerializeField] private Vector3 _center = Vector3.zero; // 中心点
    [SerializeField] private Vector3 _axis = Vector3.up; // 回転軸
    [SerializeField] private float _period = 10; // 円運動周期
    [SerializeField] private ElapseTime elapse;

    private bool _updateRotation = true; // 向きを更新するかどうか
    public bool flag = true;
    public float Value = 100;
    Vector2 startPos;

    void QuaternionSetter()
    {
        var tr = transform;

        // 回転のクォータニオン作成
        var angleAxis = Quaternion.AngleAxis(360 / -(_period) * Time.deltaTime, _axis);
        
        // 円運動の位置計算
        var pos = tr.position;

        pos -= _center;
        pos = angleAxis * pos;
        pos += _center;

        tr.position = pos;

        // 向き更新
        if (_updateRotation)
        {
            tr.rotation = tr.rotation * angleAxis;
        }
        elapse.IncreaseGage();
    }

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (Value < 0) { transform.position = startPos; flag = false; }
        else Value -= Time.deltaTime * _period;

        if (flag)
        {
            QuaternionSetter();
            return;
        }   
    }
}
