using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){            
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }
}
