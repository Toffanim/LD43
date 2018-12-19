using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

// IMPORTANT (MTN5): Taken/inspired from Unity GameKit 2D

[RequireComponent(typeof(Collider2D))]
public class Damager : MonoBehaviour {
    [Serializable]
    public class DamageableEvent : UnityEvent<Damager, Damageable>
    { }

    public int Damage;
    public DamageableEvent OnDamageable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var Damageable = collision.GetComponent<Damageable>();
        if(Damageable)
        {
            Damageable.TakeDamage(this);
            OnDamageable.Invoke(this, Damageable);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
