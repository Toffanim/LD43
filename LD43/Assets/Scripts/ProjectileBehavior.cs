using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {
    public Vector2 PlayerDirection;
    Rigidbody2D RB2D;
    bool StopMoving = false;
    float RecoveryLength;
    float RecoveryCount;

    float Speed = 1;

    int Damage = 10;
    int Knockback = 3;

	// Use this for initialization
	void Start () {
        RB2D = GetComponent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Player = GameObject.Find("Player 1");
        if (Player == collision.gameObject)
        {
            Player.GetComponent<PlayerState>().OnDamage(Damage, Knockback);
        }
        Object.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        var RB2D = GetComponent<Rigidbody2D>();
        RB2D.velocity = (PlayerDirection * Speed);
    }
}
