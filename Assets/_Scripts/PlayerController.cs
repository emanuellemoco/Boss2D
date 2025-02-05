﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private GameManager gm;
    
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
    private bool isShield;
    public AudioClip shootSFX; 
    Color colorRed = new Color (154, 0, 11);


    [SerializeField] 
    // private int life = 5;

    void Start()
    {
        gm = GameManager.GetInstance();
        animator = GetComponent<Animator>();
        isDead = false;
        isShield = false;
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        


        
    }
    bool isGrounded(){
        RaycastHit2D rayCastHit2D = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 1f, platformLayer);   
    
        return rayCastHit2D.collider != null;
    }
    

    // Update is called once per frame
    void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
            Time.timeScale = 0;
        }

        
        if (Input.GetKeyDown(KeyCode.DownArrow))
            CameraFocus.LookDown();

        if (Input.GetKeyUp(KeyCode.DownArrow)) 
            CameraFocus.LookUp();

        //Arrumar para permitir pulo duplo e nao infinito.
        if (isGrounded() && (Input.GetKeyDown(KeyCode.UpArrow)  || Input.GetKeyDown(KeyCode.Space) ) && !isShield ){
            animator.SetTrigger("Jump");
            float jumpVelocity = 5f; 
            rigidBody.velocity = Vector2.up * jumpVelocity; 
        }
     
        if (Input.GetKeyDown(KeyCode.Q) && !isShield)
            Attack();
        if (Input.GetKey(KeyCode.F)){
            animator.SetBool("Shield", true); 
            isShield = true;
            }
        else {
            animator.SetBool("Shield", false); 
            isShield = false;
        }


    }

    void FixedUpdate() 
    {
        if (gm.gameState != GameManager.GameState.GAME) return; 

        if (!isDead){
            
        float inputX = Input.GetAxis("Horizontal");
        if (!isShield) transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocity;
        
        if (inputX != 0 && !animator.GetBool("Jump") )
            animator.SetFloat("Velocity", 1.0f);
        else
            animator.SetFloat("Velocity", 0.0f);
        
        if (inputX < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if (inputX > 0 )
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        
    }
    IEnumerator flashRed() {
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer> ().color = colorRed;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer> ().color = Color.white;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer> ().color = colorRed;
        yield return new WaitForSeconds(0.1f); 
        GetComponent<SpriteRenderer> ().color = Color.white;

    }
 

    void Attack(){
        if ( Time.time - _attacktTimestamp < attackDelay) 
            return;
            
        AudioManager.PlaySFX(shootSFX);
    
        _attacktTimestamp = Time.time;
        int attack_anim = Random.Range(0,3);

        if (attack_anim == 0)
            animator.SetTrigger("Attack1");
        if (attack_anim == 1)
            animator.SetTrigger("Attack2");
        if (attack_anim == 2)
            animator.SetTrigger("Attack3");
        
        //Detectando os inimigos
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        //Dano ao inimigo
        foreach(Collider2D enemy in hitEnemies){
            enemy.gameObject.GetComponent<EnemyController>().TakeDamage();
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null )
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    public void TakeDamage()
    {
        if (!isShield){
            gm.life--;
            if (gm.life <=0) Die();
            else StartCoroutine(flashRed());
        }
    }
 
    private void Die()
    {
        gm.life = 0;
        animator.SetTrigger("Death");

        if(gm.gameState == GameManager.GameState.GAME) 
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        } 

    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Food"){            
            gm.life += 1;
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Border")           
            Die();

    }

}
