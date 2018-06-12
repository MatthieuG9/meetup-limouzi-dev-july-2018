using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private float moveForce = 600f;
    [SerializeField]
    private float maxSpeed = 10f;
    [SerializeField]
    private float jumpForce = 2000f;

    private bool facingRight = true;
    private bool jump = false;
    private bool grounded = false;

    private Transform top;
    private Transform bottom;
    private int groundMask;

    void Start () {
        top = transform.Find("top");
        bottom = transform.Find("bottom");
        groundMask = 1 << LayerMask.NameToLayer("Ground");
	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.Linecast(top.position, bottom.position, groundMask);
        Debug.Log(grounded);
	}
}
