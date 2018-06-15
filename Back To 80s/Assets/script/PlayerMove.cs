using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState { IDLE, RUN, JUMP }

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private float maxSpeed = 20f;
    [SerializeField]
    private float minSpeed = 0.1f;
    [SerializeField]
    private float jumpForce = 2000f;
    [SerializeField]
    private int playerNumber = 1;

    private bool facingRight = true;
    private bool grounded = false;
    private PlayerState state = PlayerState.IDLE;

    private Transform top;
    private Transform bottom;
    private int groundMask;
    private Rigidbody2D body;
    private Animator animator;

    void Start () {
        top = transform.Find("top");
        bottom = transform.Find("bottom");
        groundMask = 1 << LayerMask.NameToLayer("Ground");
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	void FixedUpdate () {
        float hInput = GetAxis("Horizontal");
        float hSpeed = hInput * maxSpeed;

        body.velocity = new Vector2(hSpeed, body.velocity.y);

        grounded = Physics2D.Linecast(top.position, bottom.position, groundMask);
        if (grounded)
        {
            if (GetButtonDown("Jump"))
            {
                body.AddForce(Vector2.up * jumpForce);
                setState(PlayerState.JUMP);
            }
            else if (Mathf.Abs(body.velocity.x) > minSpeed)
            {
                setState(PlayerState.RUN);
            }
            else 
            {
                setState(PlayerState.IDLE);
            }
        }

        if(hInput < 0 && facingRight || hInput > 0 && !facingRight)
        {
            flip();
        }
    }

    private void setState(PlayerState state)
    {
        if (state != this.state)
        {
            this.state = state;
            animator.SetTrigger(state.ToString().ToLowerInvariant());
        }
    }

    void flip()
    {
        var scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
        facingRight = !facingRight;
    }

    float GetAxis(string axisName)
    {
        return Input.GetAxis(axisName + playerNumber);
    }

    bool GetButton(string buttonName)
    {
        return Input.GetButton(buttonName + playerNumber);
    }

    bool GetButtonDown(string buttonName)
    {
        return Input.GetButtonDown(buttonName + playerNumber);
    }
}
