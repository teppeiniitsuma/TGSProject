using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndrollLoader : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _coll;
    [SerializeField] private GameObject _audio;
    [SerializeField] LastEnemy lsEnemy;
    void Start()
    {
        _coll.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(lsEnemy.lastBossHp == 0)
        {
            _audio.SetActive(false);
            _coll.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F8)) { lsEnemy.lastBossHp = 1; }
    }
}
