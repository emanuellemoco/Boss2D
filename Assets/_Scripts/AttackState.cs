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
     
     
    void Start() 
    {
        animator = GetComponent<Animator>();
        
    }

    void Attack(){
        if ( Time.time - _attacktTimestamp < attackDelay) 
            return;
            
        _attacktTimestamp = Time.time;
        //Criar para os 3 tipos de ataques e chamar aleaoriamente
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
        Attack();

    }
}
