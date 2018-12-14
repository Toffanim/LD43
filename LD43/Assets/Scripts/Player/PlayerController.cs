using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public bool freezeMovements { get; set; }

    //PV ATTR
    public NPC npcInRange { get; set; }

    private bool AskedForJump = false;

    // Use this for initialization
    void Start()
    {
        State = GetComponent<PlayerState>();
        npcInRange = null;
        freezeMovements = false;
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

        Animator.SetInteger(Animator.StringToHash("PlayerState"), (int)State.State);
    }



    private void Update()
    {
        if (Input.GetKey("escape")) Application.Quit();
        if (npcInRange!=null)
        {
            if (Input.GetButtonDown("Jump") && npcInRange.dialogStarted )
                npcInRange.changeResponse();
            if (Input.GetButtonDown("Talk"))
                npcInRange.dialog();
        }


        if (!freezeMovements)
        {
            if (Input.GetButtonDown("Jump")) AskedForJump = true;
            Inputs.X = Input.GetAxis("Horizontal") >= 0 ? (float)Math.Ceiling(Input.GetAxis("Horizontal")) : (float)Math.Floor(Input.GetAxis("Horizontal"));
            if (State.AnimState != AnimState.JUMP) // Define in PlayerMovement FixedUpdate
            {
                if (Inputs.X == 0) State.AnimState = AnimState.IDLE;
                else State.AnimState = AnimState.WALK;
            }

            State.CanAttack = true;

            if (Inputs.X < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x < 0 ? transform.localScale.x : -transform.localScale.x, transform.localScale.y, transform.localScale.z);
                State.IsFacingRight = false;
                if (State.State == global::State.TWO_ARMS)
                {
                    State.CanAttack = false;
                }
            }
            else if (Inputs.X > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x < 0 ? -transform.localScale.x : transform.localScale.x, transform.localScale.y, transform.localScale.z);
                State.IsFacingRight = true;
                if (State.State == global::State.TWO_ARMS)
                {
                    State.CanAttack = false;
                }
            }

            if (State.State == global::State.CHAIR_BALL)
            {
                Inputs.Y = Input.GetAxis("Vertical") >= 0 ? (float)Math.Ceiling(Input.GetAxis("Vertical")) : (float)Math.Floor(Input.GetAxis("Vertical"));
            }
            else
            {
                // Inputs.Y = Input.GetButtonDown("Jump") ? 1 : 0;//(float)Math.Ceiling((double)Input.GetAxis("Vertical"));
            }

            if (Input.GetButtonDown("Attack") && State.CanAttack)
            {
                State.AnimState = AnimState.ATTACK;
            }
        }// ! player not freezed
        else
        { // PLAYER IZ FREEZED

        }
        ApplyAnimState();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (freezeMovements)
        {
            Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
            if (!!rb2d)
                rb2d.velocity = new Vector2(0,0);
        }

        if(AskedForJump)
        {
            Inputs.Y = 1;
            AskedForJump = false;
        }
    }

    public void kill()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void heal(int iAmount)
    {
        PlayerState ps = GetComponent<PlayerState>();
        if (!!ps)
            ps.HP = ( (ps.HP + iAmount) > ps.MAX_HP ) ? 
                ps.MAX_HP : 
                ps.HP + iAmount ;
    }

    public void teleportToLocation(Transform iTransform)
    {
        //freezeMovements = true;
        gameObject.transform.position = iTransform.position;
        //freezeMovements = false;
    }
}

