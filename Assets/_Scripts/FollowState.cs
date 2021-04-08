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
    Animator animator;
    public float distMax = 4.0f;
    public float distMin = 1.0f;
     
    
    
    SteerableBehaviour steerable;

    public override void Awake()
    {
       base.Awake();

       Transition Idle = new Transition();

       Transition Attack = new Transition();

       if (GameObject.FindWithTag("Player") != null){ 
       Attack.condition = new ConditionAttack(transform, GameObject.FindWithTag("Player").transform, distMin);
       Attack.target = GetComponent<AttackState>();
       transitions.Add(Attack);

       Idle.condition = new ConditionIdle(transform, GameObject.FindWithTag("Player").transform, distMax);
       Idle.target = GetComponent<IdleState>();
       transitions.Add(Idle);
       }
    }

    void Start() 
    {
        gm = GameManager.GetInstance();
        steerable = GetComponent<SteerableBehaviour>();
        animator = GetComponent<Animator>();

    }
     
    // Update is called once per frame
    public override void Update()
    {
        Debug.Log("Estou no follow state");

        animator.SetFloat("Velocity", 1.0f);

        if (gm.gameState != GameManager.GameState.GAME) return;
        
        player = GameObject.FindWithTag("Player"); 
        if (player != null)
            playerPos =  player.transform.position;
        
        direction = playerPos - transform.position;
        direction.Normalize();
        steerable.Thrust(direction.x, 0);

         if (direction.x < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else
            transform.localRotation = Quaternion.Euler(0, 0, 0);

    }
} 
