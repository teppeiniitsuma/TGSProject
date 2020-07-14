/*****************************
 
正確にはMainGameManager 

 *****************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    public GameState GetGameState { get { return _gameState; }}
    public PlayerInfoCounter Information { get { return _info; } }
    public UIManager UIInfo { get { return _uiManager; } }


    [SerializeField] private GameState _gameState;
    static GameManager _instance;
    private PlayerInfoCounter _info;
    private UIManager _uiManager;

    private void Awake()
    {
        _instance = this;
        _info = FindObjectOfType<PlayerInfoCounter>();
        _uiManager = FindObjectOfType<UIManager>();
        _info.Initialize();
    }

    public enum GameState
    {
        SetUp = 0,
        Main,
        Road,
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
        _gameState = g;
    }
    
}
