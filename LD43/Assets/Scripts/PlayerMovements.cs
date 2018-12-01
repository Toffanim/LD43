using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    // Jump Logic
    public bool CanDoubleJump { get; set; }
    public bool AskedForJump { get; set; }

    // Physics Data
    Rigidbody2D RB2D;
    //   Collision ray options
    float RayOffsetX;
    float RayOffsetY;
    float RayLength;

    // Jump parameters


    // Player data
    PlayerState State;
    PlayerController Controller;

    // Use this for initialization
    void Start()
    {
        State = GetComponent<PlayerState>();
        Controller = GetComponent<PlayerController>();
        RB2D = GetComponent<Rigidbody2D>();
        CapsuleCollider2D collider2D = GetComponent<CapsuleCollider2D>();

        RayOffsetX = collider2D.bounds.extents.x + 0.1f;
        RayOffsetY = collider2D.bounds.extents.y + 0.1f;
        RayLength = 0.01f;

        AskedForJump = false;
        CanDoubleJump = true;
    }

    public bool IsOnWall()
    {
        bool HitLeft = Physics2D.Raycast(
            new Vector2(transform.position.x - RayOffsetX, transform.position.y),
                -Vector2.right, RayOffsetY);
        bool HitRight = Physics2D.Raycast(
            new Vector2(transform.position.x + RayOffsetX, transform.position.y),
                Vector2.right, RayOffsetY);

        return (HitLeft || HitRight);
    }

    public bool IsGrounded()
    {
        bool RayDown1 = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - RayOffsetY),
               -Vector2.up, RayLength);
        bool RayDown2 = Physics2D.Raycast(
            new Vector2(transform.position.x + (RayOffsetX - 0.2f), transform.position.y - RayOffsetY),
               -Vector2.up, RayLength);
        bool RayDown3 = Physics2D.Raycast(
            new Vector2(transform.position.x - (RayOffsetX - 0.2f), transform.position.y - RayOffsetY),
               -Vector2.up, RayLength);
        return (RayDown1 || RayDown2 || RayDown3);
    }

    //Returns whether or not player is touching wall or ground.
    public bool IsTouchingSomething()
    {
        return (IsGrounded() || IsOnWall());
    }

    //Returns direction of wall.
    public int wallDirection()
    {
        bool left = Physics2D.Raycast(
            new Vector2(transform.position.x - RayOffsetX, transform.position.y),
               -Vector2.right, RayLength);
        bool right = Physics2D.Raycast(
            new Vector2(transform.position.x + RayOffsetX, transform.position.y),
            Vector2.right, RayLength);

        if (left)
            return -1;
        else if (right)
            return 1;
        else
            return 0;
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsGrounded())
            CanDoubleJump = true;
        if (State.MoveSet == 1)
        {
            RB2D.AddForce(new Vector2(((Controller.Inputs.X * State.Speed) - RB2D.velocity.x) * (IsGrounded() ? State.accel : State.airAccel),
                                        0));
        RB2D.velocity = new Vector2((Controller.Inputs.X == 0 && IsGrounded()) ? 0 : RB2D.velocity.x,
                                    (Controller.Inputs.Y == 1 && (IsTouchingSomething() || CanDoubleJump)) ? State.jump : RB2D.velocity.y);

            if (Controller.Inputs.Y == 1 && !IsTouchingSomething() && CanDoubleJump) CanDoubleJump = false;

            if (IsOnWall() && !IsGrounded() && Controller.Inputs.Y == 1)
                RB2D.velocity = new Vector2(-wallDirection() * State.Speed * 0.75f, RB2D.velocity.y);

            //Debug.Log(RB2D.velocity.x);
            Controller.Inputs.Y = 0;
        }
        else if (State.MoveSet == 2)
        {
            RB2D.AddForce(new Vector2(((Controller.Inputs.X * State.Speed) - RB2D.velocity.x) * State.airAccel,
                            0));

            RB2D.velocity = new Vector2((Controller.Inputs.X == 0 && IsGrounded()) ? 0 : RB2D.velocity.x,
                                         IsTouchingSomething() ? State.jump : RB2D.velocity.y);

            Controller.Inputs.Y = 0;
        }
        else if (State.MoveSet == 3)
        {
            RB2D.AddForce(new Vector2(((Controller.Inputs.X * State.Speed) - RB2D.velocity.x) * (IsGrounded() ? State.accel*2 : State.airAccel),
                                        0));

            RB2D.velocity = new Vector2((Controller.Inputs.X == 0 && IsGrounded()) ? 0 : RB2D.velocity.x,
                                        (Controller.Inputs.Y == 1 && (IsTouchingSomething() || CanDoubleJump)) ? State.jump : RB2D.velocity.y);

            if (Controller.Inputs.Y == 1 && !IsTouchingSomething() && CanDoubleJump) CanDoubleJump = false;

            if (IsOnWall() && !IsGrounded() && Controller.Inputs.Y == 1)
                RB2D.velocity = new Vector2(-wallDirection() * State.Speed * 0.75f, RB2D.velocity.y);

            Controller.Inputs.Y = 0;
        }
    }
}
