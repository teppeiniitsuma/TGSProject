/*
 ゲームの初期化などを担う
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return Instance; } }

    public GameState gameState;
    public GameState GetGameState { get { return gameState; }}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // MainとResultだけでいいかも
    public enum GameState
    {
        Main,
        GameOver,
        Result,
    }
    

    void Start()
    {

    }
}
