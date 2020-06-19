using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public GameState gameState;
    public GameState GetGameState { get { return gameState; }}

    private void Awake()
    {
        _instance = this;
    }

    public enum GameState
    {
        Main,
        EventStart,
        EventEnd,
        GameOver,
        Result,
    }
    /// <summary>
    /// ゲームステートを書き換える
    /// </summary>
    /// <param name="g"></param>
    public void SetGameState(GameState g)
    {
        gameState = g;
    }
    
}
