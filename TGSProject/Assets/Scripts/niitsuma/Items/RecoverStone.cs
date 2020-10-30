using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverStone : MonoBehaviour
{
    [SerializeField] private GameObject _stones;
    [SerializeField, Header("石の再生時間")] private float _activeTime = 10f;

    float _time;

    void Update()
    {
        if (!_stones.active)
        {
            if(_time <= _activeTime)
            {
                _time += Time.deltaTime;
            }
            else
            {
                _stones.SetActive(true);
                _time = 0;
            }
        }
    }
}
