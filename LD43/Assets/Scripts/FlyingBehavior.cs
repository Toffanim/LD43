using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBehavior : MonoBehaviour {
    public Vector2 PlayerDirection;
    Rigidbody2D RB2D;
    bool StopMoving = false;
    float RecoveryLength;
    float RecoveryCount;
	// Use this for initialization
	void Start () {
        RB2D = GetComponent<Rigidbody2D>();
        RecoveryLength = 0.1f;
        RecoveryCount = 0;
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        var Player = GameObject.Find("Player 1");
        if (Player == collision.gameObject)
        {
            Vector3 Direction = (Player.transform.position - gameObject.transform.position);
            Direction.Normalize();

            if (!GetComponent<EnnemyState>().IsDamaged && !StopMoving)
            {
                RB2D.AddForce(Direction * GetComponent<EnnemyState>().Speed);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var Player = GameObject.Find("Player 1");
        if (Player == collision.gameObject)
        {
            RB2D.velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        var Player = GameObject.Find("Player 1");
        if (Player == collision.gameObject)
        {
            StopMoving = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        RecoveryCount = RecoveryLength;

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        // RB2D.velocity = (new Vector2(0,0));
        RecoveryCount -= Time.deltaTime;
        if (RecoveryCount <= 0)
        {
                StopMoving = false;
        }
    }
}
