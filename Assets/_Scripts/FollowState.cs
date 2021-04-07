using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    // Start is called before the first frame update
    GameObject player;
    Vector3 playerPos;
    Vector3 direction;
    GameManager gm;
    
    SteerableBehaviour steerable;
    
    void Start() 
    {
        gm = GameManager.GetInstance();
        steerable = GetComponent<SteerableBehaviour>();

    }
     
    // Update is called once per frame
    public override void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        
        player = GameObject.FindWithTag("Player"); 
        if (player != null)
            playerPos =  player.transform.position;
        
        direction = playerPos - transform.position;
        direction.Normalize();
        steerable.Thrust(direction.x, 0);

    }
} 
