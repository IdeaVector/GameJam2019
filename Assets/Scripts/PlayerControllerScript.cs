﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
   // private Vector2 speed = new Vector2(2,0);
    private Rigidbody2D rb2d;
    private Animator anim;
    public bool isGround = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public float speed = 5f;
    public LayerMask whatIsGround;
    private int extremJump = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(isGround)
        {
            extremJump = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extremJump > 0)
        {
            anim.SetBool("Ground", false);
            rb2d.AddForce(new Vector2(rb2d.velocity.x, 1000));
            extremJump--;
        }
    }
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", isGround);
        anim.SetFloat("VSpeed", rb2d.velocity.y);
        if (!isGround)
            return;
        anim.SetFloat("Speed", Mathf.Abs(1));
        rb2d.velocity = new Vector2( speed, rb2d.velocity.y);
    }
}
