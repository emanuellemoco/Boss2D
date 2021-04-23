using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    GameObject player;
    // Update is called once per frame
    private static Camera _instance;
    private static bool down;
    void Start(){

        _instance = Camera.main;
        down = false;
    }
    void Update()
    {   
        player = GameObject.FindWithTag("Player");;
        if (player == null) return;

        if(!down) _instance.transform.position = new Vector3 (player.transform.position.x + 3.5f, player.transform.position.y + 2.0f, transform.position.z);
 
        
    }

    public static void LookDown(){
        down = !down;
        _instance.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y -2f, Camera.main.transform.position.z); 

    }
}
