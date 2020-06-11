using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField] private Transform _playerPos;
    [SerializeField] private Transform _cameraPos;
    [SerializeField] private Transform[] _bgs = new Transform[4];
    [SerializeField] private Transform[] _bgs2 = new Transform[4];
    [SerializeField] private Transform _bgStatic;

    public enum BGType
    {
        player,
        camera,
    }
    public BGType bG;
    void BGMove()
    {
        _bgs[0].position = new Vector2(_playerPos.position.x * -(Time.deltaTime * 12), _bgs[0].position.y);
        _bgs[1].position = new Vector2(_playerPos.position.x * -(Time.deltaTime * 9), _bgs[1].position.y);
        _bgs[2].position = new Vector2(_playerPos.position.x * -(Time.deltaTime * 3), _bgs[2].position.y);
        _bgs[3].position = new Vector2(_playerPos.position.x * -(Time.deltaTime * 2), _bgs[3].position.y);

        _bgs2[0].position = new Vector2(_playerPos.position.x * -(Time.deltaTime * 12), _bgs2[0].position.y);
        _bgs2[1].position = new Vector2(_playerPos.position.x * -(Time.deltaTime * 9), _bgs2[1].position.y);
        _bgs2[2].position = new Vector2(_playerPos.position.x * -(Time.deltaTime * 3), _bgs2[2].position.y);
        _bgs2[3].position = new Vector2(_playerPos.position.x * -(Time.deltaTime * 2), _bgs2[3].position.y);

    }
    void CBGMove()
    {
        _bgs[0].position = new Vector2(_cameraPos.position.x * (Time.deltaTime), _bgs[0].position.y);
        _bgs[1].position = new Vector2(_cameraPos.position.x * (Time.deltaTime * 2), _bgs[1].position.y);
        _bgs[2].position = new Vector2(_cameraPos.position.x * (Time.deltaTime * 3), _bgs[2].position.y);
        _bgs[3].position = new Vector2(_cameraPos.position.x * (Time.deltaTime * 4), _bgs[3].position.y);

    }

    void FixedUpdate()
    {
        _bgStatic.position = new Vector2(_cameraPos.position.x, _bgStatic.position.y);
        
        if (bG == BGType.player)
            BGMove();
        else
            CBGMove();
    }
}
