using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private float maxSpeed = 20f;
    [SerializeField]
    private float jumpForce = 2000f;
    [SerializeField]
    private int playerNumber = 1;

    private bool facingRight = true;
    private bool jump = false;
    private bool grounded = false;

    private Transform top;
    private Transform bottom;
    private int groundMask;
    private Rigidbody2D body;
    private Collider2D collider2D;

    void Start () {
        top = transform.Find("top");
        bottom = transform.Find("bottom");
        groundMask = 1 << LayerMask.NameToLayer("Ground");
        body = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
	}
	
	void FixedUpdate () {
        float hInput = GetAxis("Horizontal");
        float hSpeed = hInput * maxSpeed;

        body.velocity = new Vector2(hSpeed, body.velocity.y);

        grounded = Physics2D.Linecast(top.position, bottom.position, groundMask);
        if (GetButtonDown("Jump") && grounded)
        {
            jump = true;
            body.AddForce(Vector2.up * jumpForce);
        }
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
