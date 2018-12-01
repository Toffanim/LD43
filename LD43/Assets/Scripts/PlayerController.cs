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

    private void Update()
    {
        if (Input.GetButtonDown("Talk") && !!npcInRange)
            npcInRange.dialog();

        Inputs.X = Input.GetAxis("Horizontal") >= 0 ? (float)Math.Ceiling(Input.GetAxis("Horizontal")) : (float)Math.Floor(Input.GetAxis("Horizontal"));

        State.CanAttack = true;

        if (Inputs.X < 0)
        {
            SpriteRenderer SR = GetComponent<SpriteRenderer>();
            SR.flipX = true;
            if (State.State == global::State.TWO_LEGS_ONE_ARM)
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

        Animator Animator = GetComponent<Animator>();
        if (Input.GetButtonDown("Attack") && State.CanAttack)
        {
            Animator.SetBool(Animator.StringToHash("IsAttacking"), true);
        }
        else {
            Animator.SetBool(Animator.StringToHash("IsAttacking"), false); 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}

