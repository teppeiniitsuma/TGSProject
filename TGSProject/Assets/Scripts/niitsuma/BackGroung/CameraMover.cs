using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    float myPos;
    float nextPos;
    float time = 0;
    bool touch = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { touch = true; }
    }

    void Start()
    {
        myPos = transform.position.x;
        nextPos = this.transform.position.x + 7f;
    }


    void MoveCamera()
    {
        if (touch)
        {
            GameManager.Instance.SetGameState(GameManager.GameState.EventStart);
            _camera.position = new Vector3(Mathf.MoveTowards(_camera.position.x, nextPos, Time.deltaTime * 5), _camera.position.y, -10);


            if (_camera.position.x >= nextPos && GameManager.Instance.GetGameState == GameManager.GameState.EventStart)
            {
                touch = false;
                this.transform.position = new Vector2(myPos + 16f, transform.position.y);
                nextPos = this.transform.position.x + 7f;
                myPos = transform.position.x;
                GameManager.Instance.SetGameState(GameManager.GameState.EventEnd);
            }
        }
    }
    void Update()
    {

        MoveCamera();
        if (GameManager.Instance.GetGameState == GameManager.GameState.EventEnd)
        {
            if (time > 0.1f)
            {
                time = 0;
                GameManager.Instance.SetGameState(GameManager.GameState.Main);
            }
            time += Time.deltaTime;
        }
    }
}
