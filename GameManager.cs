using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameState {
    menu,inGame,gameover

}
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameState currentGameState = GameState.menu;
    public static GameManager instance;
    public string cena;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentGameState = GameState.menu;
      //  StartGame();
    }
    private void Update()
    {
     
    }
    public void StartGame()
    {
        SceneManager.LoadScene(cena);
        SetGameState(GameState.inGame);
        
    }



    public void GameOver()
    {
        SetGameState(GameState.gameover);
    }


    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {

        }
        else if (newGameState==GameState.inGame){
        }
        else if (newGameState == GameState.gameover)
        {

        }
        currentGameState = newGameState;
    }
}
