using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{

    public enum GameState { MENU, GAME, PAUSE, ENDGAME, CONTROL };

    public GameState gameState { get; private set; }
    public GameState lastState { get; private set; }
    public int life;
    public int Maxlife;

    


   
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    private static GameManager _instance;


    public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }

    private GameManager()
   {
       life = 5;
       Maxlife = 5 ;
       
       gameState = GameState.MENU;
       lastState = GameState.MENU;
   }
   
   public void ChangeState(GameState nextState)
    {
    if (nextState == GameState.GAME && gameState == GameState.MENU || nextState == GameState.GAME && gameState == GameState.ENDGAME )  Reset();
        lastState = gameState;
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        life = 5;
    }


}