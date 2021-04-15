using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Control : MonoBehaviour
{
  GameManager gm;
  bool shiftOn = false; 
 public Sprite OffSprite;
 public Sprite OnSprite;

  // public Color wantedColor;
  public Button buttonSound; 


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

    AudioManager.ToggleSound();

    if (buttonSound.image.sprite == OnSprite)
      buttonSound.image.sprite = OffSprite;
    else {
      buttonSound.image.sprite = OnSprite;
    }
  } 


}