using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour {

    public int Damage = 10;
    public int Knockback = 3;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var Player = GameObject.Find("Player 1");
        if (Player == collision.gameObject)
        {
            if (collision.transform.position.x > transform.position.x)
                Player.GetComponent<PlayerState>().OnDamage(Damage, Knockback);
            else
                Player.GetComponent<PlayerState>().OnDamage(Damage, -Knockback);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var Player = GameObject.Find("Player 1");
        if (Player == collision.gameObject)
        {
            Player.GetComponent<PlayerState>().OnDamage(Damage, Knockback);
        }
    }

    // Update is called once per frame
    void Update () {
        var T = gameObject.transform.parent.transform;
        T.eulerAngles = new Vector3(0, 0, Mathf.Sin(Time.realtimeSinceStartup) * 45);

        var Dir = -T.up;
        var O = T.position;
        var Hit = Physics2D.Raycast(O, Dir);
        T.localScale = new Vector3(gameObject.transform.localScale.x, Hit.distance+2, gameObject.transform.localScale.z);
    }
}
