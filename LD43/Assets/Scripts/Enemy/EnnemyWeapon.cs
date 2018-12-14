using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyWeapon : MonoBehaviour
{
    public int Damage = 10;
    public int Knockback = 50;

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        PlayerState es = go.GetComponent<PlayerState>();
        if (es && !collision.isTrigger)
        {
            //var Dir = GetComponentInParent<EnnemyState>().IsFacingRight ? 1 : -1;
            //es.OnDamage(Damage, Dir * Knockback);
            if (collision.transform.position.x > transform.position.x)
                es.OnDamage(Damage, Knockback);
            else
                es.OnDamage(Damage, -Knockback);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

