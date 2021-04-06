using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameManager gm;
    Animator animator;
    [SerializeField]
    private int life = 1;

    public void TakeDamage()
    {
        life--;
        if (life <=0) Die();
    }

    public void Die(){
        
        animator.SetTrigger("Death");
    }
    void Start()
    {
        animator = GetComponent<Animator>();     
        gm = GameManager.GetInstance();   
    }

    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
    }
}
