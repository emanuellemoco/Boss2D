using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameManager gm;
    Animator animator;
    [SerializeField]
    private int life = 1;

    Color colorRed = new Color (154, 0, 11);
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

    public void TakeDamage()
    {
        life--;
        StartCoroutine(flashRed()); 
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
