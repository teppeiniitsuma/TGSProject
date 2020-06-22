using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCameraController : MonoBehaviour
{
    [SerializeField] private Transform _camera;


    int moveCount = 0;

    float myPos = 0;
    float prevPos = 0;
    float nextPos = 0;
    float time = 0;

    int Go = 0;

    void Start()
    {
        myPos = transform.position.x;
        prevPos = this.transform.position.x - 17.7f;
        nextPos = this.transform.position.x + 17.7f;
    }

    public void TauchTest(int n)
    {
        switch (n)
        {
            case 0: if (moveCount > 0) { Go = 1; moveCount--; }; break;
            case 1: Go = 2; moveCount++; break;

            default: break;
        }
    }

    void MoveCamera()
    {
        if (Go == 2)
        {
            GameManager.Instance.SetGameState(GameManager.GameState.EventStart);
            _camera.position = new Vector3(Mathf.MoveTowards(_camera.position.x, nextPos, Time.deltaTime * 5), _camera.position.y, -10);


            if (_camera.position.x == nextPos && GameManager.Instance.GetGameState == GameManager.GameState.EventStart)
            {
                Go = 0;
                this.transform.position = new Vector2(myPos + 17.7f, transform.position.y);
                nextPos = this.transform.position.x + 17.7f;
                prevPos = this.transform.position.x -17.7f;
                myPos = transform.position.x;
                GameManager.Instance.SetGameState(GameManager.GameState.EventEnd);
            }
        }
        else if(Go == 1)
        {
            GameManager.Instance.SetGameState(GameManager.GameState.EventStart);
            _camera.position = new Vector3(Mathf.MoveTowards(_camera.position.x, prevPos, Time.deltaTime * 5), _camera.position.y, -10);

            Debug.Log(prevPos);
            if (_camera.position.x == prevPos && GameManager.Instance.GetGameState == GameManager.GameState.EventStart)
            {
                Go = 0;
                this.transform.position = new Vector2(myPos - 17.7f, transform.position.y);
                prevPos = this.transform.position.x - 17.7f;
                nextPos = this.transform.position.x + 17.7f;
                myPos = transform.position.x;
                GameManager.Instance.SetGameState(GameManager.GameState.EventEnd);
            }
        }
    }
    // Update is called once per frame
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
