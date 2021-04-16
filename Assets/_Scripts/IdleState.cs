using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    // Start is called before the first frame update


    Vector3 direction;
    Vector3 playerPos;
    GameManager gm; 
    Animator animator;

    GameObject player;

    public float distMax = 4.0f;
    public float distMin = 1.0f;


    public Transform[] waypoints;  
    bool folloWPoint0 ;
    bool folloWPoint1;

    SteerableBehaviour steerable;

    public override void Awake()
    {
       base.Awake();

       Transition Follow = new Transition();

       if (GameObject.FindWithTag("Player") != null){
            Follow.condition = new ConditionFollow(transform, GameObject.FindWithTag("Player").transform, distMax, distMin);
            Follow.target = GetComponent<FollowState>();
            transitions.Add(Follow);
       }
    }

    void Start() 
    {
        folloWPoint0 = true;
        folloWPoint1 = false;    

        gm = GameManager.GetInstance();
        steerable = GetComponent<SteerableBehaviour>();
        animator = GetComponent<Animator>();

    }
     
    // Update is called once per frame
    public override void Update()
    {
        animator.SetFloat("Velocity", 1.0f);

        if (gm.gameState != GameManager.GameState.GAME) return;
        
        player = GameObject.FindWithTag("Player"); 
        if (player != null)
            playerPos =  player.transform.position;

        //se a distancia para o waypoints[0] for 0, anda pro way point 1
        if(folloWPoint0) {
            // Debug.Log(Vector3.Distance(transform.position, waypoints[0].position));
            direction = waypoints[0].position - transform.position;
 
            // se a distancia for 0, deve seguir o outro ponto
            if(Vector3.Distance(transform.position, waypoints[0].position) <= 2.5f){
                folloWPoint0 = false;
                folloWPoint1 = true;
            }
        }
        

        if(folloWPoint1) {
            direction = waypoints[1].position - transform.position;

            // se a distancia for 0, deve seguir o outro ponto 
            if(Vector3.Distance(transform.position, waypoints[1].position) <= 2.5f){
            folloWPoint0 = true;
            folloWPoint1 = false;
            }
        }


         if (direction.x < 0) 
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        direction.Normalize();
        transform.position += new Vector3(direction.x, 0, 0) * Time.deltaTime ;
    }

}

