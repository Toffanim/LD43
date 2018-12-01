using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct MovementInputs {
    public float X;
    public float Y;
}

public class PlayerController : MonoBehaviour
{    
    PlayerState State;

    public static KeyCode AccelarationKey = KeyCode.LeftShift;

    public MovementInputs Inputs;
    public bool FrictionOnSides = false;

    //PV ATTR
    public NPC npcInRange { get; set; }

    // Use this for initialization
    void Start()
    {
        State = GetComponent<PlayerState>();
        npcInRange = null;
    }

    private void ApplyAnimState()
    {
        Animator Animator = GetComponent<Animator>();

        if(State.AnimState == AnimState.ATTACK) Animator.SetBool(Animator.StringToHash("IsAttacking"), true);
        else Animator.SetBool(Animator.StringToHash("IsAttacking"), false);

        if (State.AnimState == AnimState.JUMP)
        {
            Animator.SetBool(Animator.StringToHash("IsJumping"), true);
            Animator.SetBool(Animator.StringToHash("IsWalking"), false);
        }

        if (State.AnimState == AnimState.WALK)
        {
            Animator.SetBool(Animator.StringToHash("IsWalking"), true);
            Animator.SetBool(Animator.StringToHash("IsJumping"), false);
        }

        if (State.AnimState == AnimState.IDLE) {
            Animator.SetBool(Animator.StringToHash("IsWalking"), false);
            Animator.SetBool(Animator.StringToHash("IsJumping"), false);
            Animator.SetBool(Animator.StringToHash("IsAttacking"), false);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Talk") && !!npcInRange)
            npcInRange.dialog();

        

        Inputs.X = Input.GetAxis("Horizontal") >= 0 ? (float)Math.Ceiling(Input.GetAxis("Horizontal")) : (float)Math.Floor(Input.GetAxis("Horizontal"));
        if (State.AnimState != AnimState.JUMP) // Define in PlayerMovement FixedUpdate
        {
            if (Inputs.X == 0) State.AnimState = AnimState.IDLE;
            else State.AnimState = AnimState.WALK;
        }

        State.CanAttack = true;

        if (Inputs.X < 0)
        {
            SpriteRenderer SR = GetComponent<SpriteRenderer>();
            SR.flipX = true;
            if (State.State == global::State.TWO_ARMS)
            {
                State.CanAttack = false;
            }
        }
        else if (Inputs.X > 0)
        {
            {
                SpriteRenderer SR = GetComponent<SpriteRenderer>();
                SR.flipX = false;
            }
            if (State.State == global::State.TWO_ARMS)
            {
                State.CanAttack = false;
            }
        }
        Inputs.Y = Input.GetButtonDown("Jump") ? 1 : 0;//(float)Math.Ceiling((double)Input.GetAxis("Vertical"));

        
        if (Input.GetButtonDown("Attack") && State.CanAttack)
        {
            State.AnimState = AnimState.ATTACK;
        }

        ApplyAnimState();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}

