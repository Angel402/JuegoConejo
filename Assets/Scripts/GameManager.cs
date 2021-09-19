using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu, 
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameState currentGameState = GameState.menu;
    private void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        currentGameState = GameState.menu;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        if (currentGameState != GameState.inGame)
        {
            PlayerController.sharedInstance.StartGame();
            ChangeGameState(GameState.inGame);
        }
    }

    public void GameOver()
    {
        ChangeGameState(GameState.gameOver);
    }

    public void BackToMainMenu()
    {
        ChangeGameState(GameState.menu);
    }

    public void ChangeGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            currentGameState = GameState.menu;
        }
        else
        {
            if (newGameState == GameState.inGame)
            {
                currentGameState = GameState.inGame;
            }
            else
            {
                if (newGameState == GameState.gameOver)
                {
                    currentGameState = GameState.gameOver;
                }
            }
        }
    }

}
