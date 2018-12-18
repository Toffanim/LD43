using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float Speed = 0.01f;
    public float acceleratedSpeed = 0.05f;
    public float basicSpeed = 0.01f;

    public int HP = 50;

    public float distance_isFarFromPlayer = 100f;
    float offsetY = 0;
    GameObject Player;
    public bool activate;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player 1");
        activate = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateSpeed();

        if (!!activate)
        {
            var Dir = new Vector3(this.transform.position.x, this.transform.position.y + offsetY, this.transform.position.z) - Player.transform.position;
            Dir.Normalize();

            this.transform.position -= Dir * Speed;
        }
    }

    public void OnDamage(int Damage)
    {
        HP -= Damage;
        if (HP <= 0) Destroy(gameObject);
    }

    bool updateSpeed()
    {
        bool rc = false;
        if (!!Player)
        {
            float distance = Vector3.Distance( transform.position, Player.transform.position);
            Speed = (distance >= distance_isFarFromPlayer) ?
                acceleratedSpeed :
                basicSpeed ;
        }
        return rc;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
            activate = true;
        }
    }
}
