using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyState : MonoBehaviour {

    Rigidbody2D RB2D;
    public bool IsDamaged = false;
    int PlayerDamage;
    int PlayerKnockback;
    bool WaitForFixUpdate = true;
    float KnockbackLength = 0.2f;
    float KnockbackCount = 0f;
    public float Speed;
    // Use this for initialization
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }

    public void OnDamage(int Damage, int Knockback)
    {
        IsDamaged = true;
        PlayerDamage = Damage;
        PlayerKnockback = Knockback;
        WaitForFixUpdate = true;

        KnockbackCount = KnockbackLength;
    }

    private void FixedUpdate()
    {
        if(IsDamaged)
             RB2D.velocity = new Vector2( 3, 3 );
        KnockbackCount -= Time.deltaTime;
        WaitForFixUpdate = false;
    }

    // Update is called once per frame
    void Update () {
        if (KnockbackCount <= 0)
        {
            IsDamaged = false;
        }
	}
}
