using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public int Damage = 10;
    public int Knockback = 50;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        EnnemyState es = go.GetComponent<EnnemyState>();
        if(es && !collision.isTrigger)
        {
            var Dir = GetComponentInParent<PlayerState>().IsFacingRight ? 1 : -1;
            es.OnDamage( Damage, Knockback );
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
