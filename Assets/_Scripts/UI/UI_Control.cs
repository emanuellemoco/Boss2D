using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Control : MonoBehaviour
{
  GameManager gm;
  bool shiftOn = false; 

  // public Color wantedColor;
  // public Button buttonSound; 


  private void OnEnable()
  {
      gm = GameManager.GetInstance();
  }
 
  public void Exit()
  {
      gm.ChangeState(GameManager.GameState.MENU);
  }

  public void OnOffSound()
  {
    Debug.Log("On Off Sound");
    // shiftOn = !shiftOn;
    // if (shiftOn)
    //     this.GetComponent<Image>().color = Color.gray; 
    // else
    //      this.GetComponent<Image>().color = Color.white;    

    // ColorBlock cb = buttonSound.colors;
    // cb.normalColor = wantedColor;
    // cb.pressedColor = wantedColor;
    // cb.highlightedColor = wantedColor;
    // buttonSound.colors = cb;
  } 


}