using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// チェックポイント的な奴
/// </summary>
public class PlayerReroad : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _playerObj;
    [SerializeField] private Transform _camera;

    Vector2 startPos;

    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetGameState == GameManager.GameState.SetUp)
        {
            _player.position = this.transform.position;
            _playerObj.position = this.transform.position + Vector3.right;
        }
        if(GameManager.Instance.GetGameState == GameManager.GameState.EventEnd)
        {
            this.transform.position = new Vector2(startPos.x + _camera.position.x, _player.position.y);
            Debug.Log(this.transform.position);
        }
    }
}
