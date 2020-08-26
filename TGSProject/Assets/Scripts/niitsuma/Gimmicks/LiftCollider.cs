using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftCollider : MonoBehaviour
{
    [SerializeField] private PositionType _pos;
    //[SerializeField] private Transform _player;
    Transform _player;
    GameManager gM = GameManager.Instance;

    float _moveValue = 0.2f;

    public bool moveCheck { get; set; }

    private enum PositionType
    {
        Left,
        Right,
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gM.Information.GetParameter.actSwitch)
        {
            if (collision.gameObject.tag == "Player" && _pos == PositionType.Right)
            {
                _player.position = new Vector2(_player.position.x - _moveValue, _player.position.y);
            }
            else if (collision.gameObject.tag == "Player" && _pos == PositionType.Left)
            {
                _player.position = new Vector2(_player.position.x + _moveValue, _player.position.y);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player" && _pos == PositionType.Right)
            {
                Vector2 pos = collision.gameObject.transform.position;
                collision.gameObject.transform.position = new Vector2(pos.x - 1, pos.y);
            }
            else if (collision.gameObject.tag == "Player" && _pos == PositionType.Left)
            {
                Vector2 pos = collision.gameObject.transform.position;
                collision.gameObject.transform.position = new Vector2(pos.x + 1, pos.y);
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
        _player = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
