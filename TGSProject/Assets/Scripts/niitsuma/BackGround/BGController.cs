using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField] private Transform _cameraPos;
    [SerializeField, Tooltip("背景の子要素を入れる")] private Transform[] _bgMember = new Transform[3];
    [SerializeField, Range(0, 1), Tooltip("背景の動くスピード")] private float _speed = 0.5f;

    private Transform _player;
    private InfoGetter _info;

    const int width = 28;
    int count = -1;

    Vector3 offset;
    Vector3 startPos;

    public Transform Camera { get { return _cameraPos; } }
    public bool MoveSwitch { get; set; }
    public bool Direction { get { return _info.Direction; } }

    private void Start()
    {
        _player = GameObject.Find("player").transform;
        offset = _player.position;
        startPos = this.transform.position;
        _info = transform.parent.GetComponent<InfoGetter>();
    }
    /// <summary>
    /// 背景がカメラに映らなくなったら呼ばれる
    /// </summary>
    /// <param name="num"></param>
    public void SetNumber(int num)
    {
        this.count = num - 1;
    }
    /// <summary>
    /// バックグラウンドを前後を入れ替える
    /// </summary>
    void SetPosition()
    {
        PositionCheck(_bgMember);
    }

    /// <summary>
    /// 一定範囲外に出たら bg の位置を前後に持ってくる
    /// </summary>
    /// <param name="bg"></param>
    void PositionCheck(Transform[] bg)
    {
        if (Direction)
        {
            switch (count)
            {
                case 0: bg[0].position = new Vector2(bg[2].position.x + width, bg[0].position.y); break;
                case 1: bg[1].position = new Vector2(bg[0].position.x + width, bg[0].position.y); break;
                case 2: bg[2].position = new Vector2(bg[1].position.x + width, bg[0].position.y); break;
                default: break;
            }
        }
        else
        {
            switch (count)
            {
                case 0: bg[0].position = new Vector2(bg[1].position.x - width, bg[0].position.y); break;
                case 1: bg[1].position = new Vector2(bg[2].position.x - width, bg[0].position.y); break;
                case 2: bg[2].position = new Vector2(bg[0].position.x - width, bg[0].position.y); break;
                default: break;
            }
        }
        count = -1;

    }
    void MoveBack()
    {
        Vector3 v = new Vector3((_player.position.x - offset.x), 0, 0) * _speed;
        this.transform.position = startPos + v;

        if (GameManager.Instance.GetGameState == GameManager.GameState.SetUp)
        {
            v = new Vector3((_player.position.x - offset.x), 0, 0) * _speed;
            this.transform.position = startPos + v;
        }
    }
    void BGMove()
    {
        // 同時行動時には背景を動かす
        if (_info.MoveSwitch)
        {
            SetPosition();
            MoveBack();
        }
        else
        {
            SetPosition();
        }
    }

    void FixedUpdate()
    {
        BGMove();
    }
}