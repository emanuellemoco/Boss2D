﻿using UnityEngine;
using UnityEngine.UI;
public class UI_EndGame : MonoBehaviour
{
   public Text message;

    GameManager gm;
    

    public void PlayAgain()
  {      
      Destroy(GameObject.FindWithTag("Player"));
      gm.ChangeState(GameManager.GameState.GAME);
  }

  public void Begin()
  {
      Destroy(GameObject.FindWithTag("Player"));
      gm.ChangeState(GameManager.GameState.MENU);
  }

   private void OnEnable()
   {
       gm = GameManager.GetInstance();

       if (gm.life > 0){
           message.text = "YOU WON";
           Destroy(GameObject.FindWithTag("Player"));
           }
        else 
            message.text = "YOU LOST";  
          

   }


}