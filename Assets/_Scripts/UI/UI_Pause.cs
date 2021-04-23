using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{

  GameManager gm;

  private void OnEnable()
  {
      gm = GameManager.GetInstance();
  }
 
  public void Return()
  {
      Time.timeScale = 1;
      gm.ChangeState(GameManager.GameState.GAME);
  }

  public void Begin()
  {
      Time.timeScale = 1;
      Destroy(GameObject.FindWithTag("Player"));
      gm.ChangeState(GameManager.GameState.MENU);
  }

}