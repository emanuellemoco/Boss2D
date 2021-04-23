using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    GameObject player;
    // Update is called once per frame
    private static Camera _instance;

    private static CameraFocus _coroutine;
    public static bool down; 
    void Start(){
 
        _instance = Camera.main;
        down = false;
        _coroutine = this;
    }
    void Update()
    {   
        player = GameObject.FindWithTag("Player");;
        if (player == null) return;

        if(!down) _instance.transform.position = new Vector3 (player.transform.position.x + 3.5f, player.transform.position.y + 2.0f, transform.position.z);
 
        
    }
 
    public static void LookDown(){
        down = true;
        for (int i =0; i<300;i++){
        _coroutine.StartCoroutine("downCamera");
        }}
    public static void LookUp(){
        for (int i =0; i<300;i++){
            _coroutine.StartCoroutine("upCamera");
        }
        down = false;
 
    }
  
    IEnumerator downCamera() {
        _instance.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y -0.01f, Camera.main.transform.position.z); 
            yield return new WaitForSeconds(20);  
    }
    IEnumerator upCamera() {  
            _instance.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y +0.01f, Camera.main.transform.position.z);
            yield return new WaitForSeconds(20); 
    }
}


