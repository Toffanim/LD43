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
    public int HP;
    bool IsAlive = true;
    public bool CanBeDamaged = true;
    bool IsDamageOnRight = true;
    bool IsFacingRight = false;
    // Use this for initialization
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        HP = 1;
    }

    public void OnDamage(int Damage, int Knockback)
    {
        if (CanBeDamaged)
        {
            IsDamaged = true;
            PlayerDamage = Damage;
            PlayerKnockback = Knockback;
            WaitForFixUpdate = true;

            KnockbackCount = KnockbackLength;

            HP -= Damage;
        }
    }



    private void FixedUpdate()
    {
        if (CanBeDamaged)
        {
            if (IsDamaged)
                RB2D.velocity = new Vector2(PlayerKnockback, PlayerKnockback <= 0 ? -PlayerKnockback : PlayerKnockback);
            KnockbackCount -= Time.deltaTime;
            WaitForFixUpdate = false;
        }
    }

    // Update is called once per frame
    void Update () {

        if(HP <= 0)
        {
            Object.Destroy(gameObject);
        }

        if(KnockbackCount <= 0) IsDamaged = false;
    }
}
