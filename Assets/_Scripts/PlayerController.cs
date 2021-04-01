﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public int velocity;
    Animator animator;
    
    
    private bool isDead; 


    void Start()
    {
        animator = GetComponent<Animator>();
        isDead = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDead){
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
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //animator.Play("player_dieLeonardoMendes");

    }
}
