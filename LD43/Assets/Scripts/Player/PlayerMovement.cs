using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float _JumpForce = 300f;
    [SerializeField] private float _MaxSpeed = 10f;

    [SerializeField] private bool _CanDoubleJump = true;
    private bool _HasDoubleJumped = false;

    [SerializeField] private Transform _GroundCheck;
    private bool _IsGrounded = false;
    private const float CHECK_RADIUS = 0.2f; 

    private Vector3 _Velocity = Vector3.zero;


    private Rigidbody2D _RB;

    private void Awake()
    {
        _RB = GetComponent<Rigidbody2D>();
    }

    public void Move( float HorizontalMovement, bool Jump )
    {
        _RB.velocity = new Vector2(HorizontalMovement * _MaxSpeed, _RB.velocity.y);
        if      (Jump && _IsGrounded)       _RB.AddForce(new Vector2(0f, _JumpForce));
        else if (Jump && !_HasDoubleJumped)
        {
            _RB.AddForce(new Vector2(0f, _JumpForce));
            _HasDoubleJumped = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        bool wasGrounded = _IsGrounded;
        _IsGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_GroundCheck.position, CHECK_RADIUS);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _IsGrounded = true;
                _HasDoubleJumped = false;
            }
        }
    }
}
