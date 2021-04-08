using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour    
{

    public GameObject player;

    public GameObject enemies;

    GameObject spawned;

    GameManager gm;
    GameObject levelSpawn()
    {
        Instantiate(player);
        return Instantiate(enemies);
        //Instantiate(player, new Vector3(0,0,0), Quaternion.identity, transform);
    }

    void Start()
    {
        gm = GameManager.GetInstance();
    }


    void Update()
    {
        if (GameObject.FindWithTag("Player") == null && gm.gameState == GameManager.GameState.GAME){
            Destroy(spawned);
            spawned = levelSpawn();}      

    }
}
