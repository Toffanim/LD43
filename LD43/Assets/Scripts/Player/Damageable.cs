using UnityEngine;
using UnityEngine.Events;
using System;

// IMPORTANT (MTN5): Taken/inspired from Unity GameKit 2D

public class Damageable : MonoBehaviour {

    [Serializable]
    public class HealthEvent : UnityEvent<Damageable>
    { }

    [Serializable]
    public class DamageEvent : UnityEvent<Damager, Damageable>
    { }

    [Serializable]
    public class HealEvent : UnityEvent<int, Damageable>
    { }

    public DamageEvent OnDamage;
    public DamageEvent OnDie;
    public int StartingHealth;
    public int CurrentHealth;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        CurrentHealth = StartingHealth;
    }

    public void TakeDamage(Damager Damager)
    {
        CurrentHealth -= Damager.Damage;
        OnDamage.Invoke(Damager, this);
        if(CurrentHealth < 0)
        {
            OnDie.Invoke(Damager, this);
        }
    }
}
