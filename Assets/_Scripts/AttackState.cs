using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    Animator animator;
    public float attackDelay = 0.4f;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    private float _attacktTimestamp = 0.0f;
    public float distMax = 4.0f;
    public float distMin = 0.25f;
     
    public override void Awake()
    {
       base.Awake();

       Transition Follow = new Transition();
       Transition Idle = new Transition();

       if (GameObject.FindWithTag("Player") != null){
       Follow.condition = new ConditionFollow(transform, GameObject.FindWithTag("Player").transform, distMax, distMin);
       Follow.target = GetComponent<FollowState>();
       transitions.Add(Follow);

       Idle.condition = new ConditionIdle(transform, GameObject.FindWithTag("Player").transform, distMax);
       Idle.target = GetComponent<IdleState>();
       transitions.Add(Idle);
       }
    }
    void Start() 
    {
        animator = GetComponent<Animator>();
        
    }

    void Attack(){
        if ( Time.time - _attacktTimestamp < attackDelay) 
            return;
            
        _attacktTimestamp = Time.time;
        //Criar para os 3 tipos de ataques e chamar aleaoriamente
        
        animator.SetFloat("Velocity", 0.0f);
        animator.SetTrigger("Attack");
        
        //Detectando o jogador
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        
        //Dano ao inimigo
        foreach(Collider2D player in hitPlayer){
            Debug.Log("Player atingido");
            player.gameObject.GetComponent<PlayerController>().TakeDamage();
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null )
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public override void Update()
    {
        Debug.Log("Estou no attack");
        Attack();

    }
}
