using UnityEngine;
using UnityEngine.UI;
public class UI_EndGame : MonoBehaviour
{
   public Text message;

    GameManager gm;
    
    public void Menu()
    {
        gm.ChangeState(GameManager.GameState.MENU);  
    }

   private void OnEnable()
   {
       gm = GameManager.GetInstance();

       message.text = "uwu";
       

   }


}