﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Tutorial para fazer o Jump: https://www.youtube.com/watch?v=ptvK4Fp5vRY
    public int velocity;

    public LayerMask platformLayer;

    public float attackDelay = 0.4f;
    public Transform attackPoint; 
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private float _attacktTimestamp = 0.0f;
    Animator animator;
    
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private bool isDead; 

    void Start()
    {
        animator = GetComponent<Animator>();
        isDead = false;
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        
    }
    bool isGrounded(){
        RaycastHit2D rayCastHit2D = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 1f, platformLayer);   
    
        return rayCastHit2D.collider != null;
    }
    


    // Update is called once per frame
    void Update(){
        //Arrumar para permitir pulo duplo e nao infinito.
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space)){
            animator.SetBool("Jump", true);
            float jumpVelocity = 5f; 
            rigidBody.velocity = Vector2.up * jumpVelocity;
        }
    }


    void FixedUpdate()
    {
        if (!isDead){
        if (!isGrounded()) 
            animator.SetBool("Jump", false);
        float inputX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocity;
        
        if (inputX != 0) 
            animator.SetFloat("Velocity", 1.0f);
        
        else
            animator.SetFloat("Velocity", 0.0f);
        
        if (inputX < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }


        if (Input.GetKeyDown(KeyCode.Q))
            Attack();
        
    }


    void Attack(){
        if ( Time.time - _attacktTimestamp < attackDelay) 
            return;
            
        _attacktTimestamp = Time.time;
        //Criar para os 3 tipos de ataques e chamar aleaoriamente
        animator.SetTrigger("Attack");
        
        //Detectando os inimigos
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        //Dano ao inimigo
        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("Bati no inimigo");
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null )
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //animator.Play("player_dieLeonardoMendes");

    }
}
