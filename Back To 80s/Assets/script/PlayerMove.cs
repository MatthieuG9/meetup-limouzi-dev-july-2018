using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState { IDLE, RUN, JUMP, ATTACK, DEAD }

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private float maxSpeed = 20f;
    [SerializeField]
    private float minSpeed = 0.1f;
    [SerializeField]
    private float jumpForce = 2000f;
    [SerializeField]
    private int playerNumber = 1;
    [SerializeField]
    private float attackDuration = 0.25f;
    [SerializeField]
    private int playerLife = 3;

    private bool facingRight = true;
    private bool grounded = false;
    private PlayerState state = PlayerState.IDLE;
    private float attackTimer = 0;

    private Transform top;
    private Transform bottom;
    private int groundMask;
    private Rigidbody2D body;
    private Animator animator;
    private ParticleSystem particle;

    void Start () {

	}
	
	void FixedUpdate () {
      
    }
}
