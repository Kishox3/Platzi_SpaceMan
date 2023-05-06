using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {menu, inGame, gameOver}

public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

    }

    public void GameOver()
    {

    }

    public void BackToMenu()
    {

    }

    private void SetGameState(GameState newGameState)
    { 
        if (newGameState == GameState.menu)
        {
            //TODO: colocar la logica del menu
        }
        else if (newGameState == GameState.inGame)
        {
            //TODO: colocar la logica del game
        }
        else if (newGameState == GameState.gameOver)
        {
            //TODO: colocar la logica del gameover
        }

        this.currentGameState = newGameState;
    }

}
