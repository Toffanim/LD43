using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController2D : MonoBehaviour
{

    [SerializeField] private bool _AllowAirControl = true;
    public PlayerMovement Movement;

    private bool _IsFacingRight = true;

    private float _HorizontalMovement = 0f;
    private bool _WantsJump = false;
    private bool _WantsAttack = false;

    // Parse Input and store desired output to apply in fixed update for Physics.
    void Update()
    {
        // Escape
        if (Input.GetKey("escape")) Application.Quit(); // TODO (MTN5): Remove from here to a global controller
        // Jump
        if (Input.GetButtonDown("Jump")) _WantsJump = true;
        // Attack
        if (Input.GetButtonDown("Attack")) _WantsAttack = true;
        // Accumulate horizontal movement
        _HorizontalMovement = Input.GetAxisRaw("Horizontal"); // NOTE (MTN5): Better to use Raw or Smoothed out?
        if (_HorizontalMovement < 0 && _IsFacingRight) Flip();
        if (_HorizontalMovement > 0 && !_IsFacingRight) Flip();
    }

    private void FixedUpdate()
    {
        Movement.Move(_HorizontalMovement, _WantsJump);
        _WantsJump = false; // Consume jump input this frame
    }

    void Flip()
    {
        _IsFacingRight = !_IsFacingRight; // NOTE(MTN5): Dangerous

        Vector3 CurrentLocalScale = transform.localScale; // NOTE(MTN5): Might be better to rotate 180 degrees
        CurrentLocalScale.x *= -1;
        transform.localScale = CurrentLocalScale;
    }
}
