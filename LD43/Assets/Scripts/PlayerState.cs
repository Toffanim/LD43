using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    FULL_BODY,
    TWO_LEGS_ONE_ARM, // _o-|=
    ONE_LEG_ONE_ARM,  // _o-|_
    TWO_LEGS,         // o-|=
    TWO_ARMS,         // =o-|
    ONE_ARM,          // _o-|
    ONE_LEG,          // o-=|_
    ONE_LEG_TWO_ARMS, // =o-|_
    NO_LIMBS,          // o-|
    CHAIR_BALL       // CTHULHU
}

public enum AnimState
{
    IDLE,
    WALK,
    JUMP,
    ATTACK
}

public class PlayerState : MonoBehaviour {

    public State State;
    public AnimState AnimState;

    public float Speed = 10;
    public float accel = 6f;
    public float airAccel = 6f;
    public float jump = 0.1f;
    float KnockbackLength = 0.2f;
    public float KnockbackCount = 0f;
    public int EnnemyKnockback;
    int EnnemyDamage;
    public bool IsFacingRight = true;

    public int HP =  100;

    public bool CanAttack = true;
    public bool IsDamaged;

    // PV STATS
    private int n_arms = 2;
    private int n_legs = 2;


    // Use this for initialization
    void Start () {
        State = State.FULL_BODY;
        n_arms = 2;
        n_legs = 2;
        AnimState = AnimState.IDLE;
	}
	
	// Update is called once per frame
	void Update () {
		if( HP <= 0 )
        {
            Debug.Log("PLEAYER DEAD");
            Object.Destroy(gameObject);
        }

        if (KnockbackCount <= 0)
        {
            IsDamaged = false;
        }
    }

    private void FixedUpdate()
    {
        KnockbackCount -= Time.deltaTime;
    }

    public void OnDamage(int Damage, int Knockback)
    {
        IsDamaged = true;
        EnnemyDamage = Damage;
        EnnemyKnockback = Knockback;

        KnockbackCount = KnockbackLength;
        HP -= Damage;
    }

    public bool mutilate(DBlock.DBLOCK_EFFECTS iBlockEffect)
    {
        bool rc = false;
        switch (iBlockEffect)
        {
            case DBlock.DBLOCK_EFFECTS.LOSE_ARM:
                n_arms--;
                State = processNewPlayerState();
                rc = true;
                break;
            case DBlock.DBLOCK_EFFECTS.LOSE_LEG:
                n_legs--;
                State = processNewPlayerState();
                rc = true;
                break;
            case DBlock.DBLOCK_EFFECTS.LOSE_BODY:
                State = State.CHAIR_BALL;
                rc = true;
                break;
            default:
                rc = false;
                break;
        }
        return rc;
    }

    private State processNewPlayerState()
    {
        Debug.Log("processNewPlayerState");

        State retval = State;
        if ((n_arms == 2) && (n_legs == 2))
            retval = State.FULL_BODY;
        else if ((n_arms == 2) && (n_legs == 1))
            retval = State.ONE_LEG_TWO_ARMS;
        else if ((n_arms == 2) && (n_legs == 0))
            retval = State.TWO_ARMS;
        else if ((n_arms == 1) && (n_legs == 2))
            retval = State.TWO_LEGS_ONE_ARM;
        else if ((n_arms == 1) && (n_legs == 1))
            retval = State.ONE_LEG_ONE_ARM;
        else if ((n_arms == 1) && (n_legs == 0))
            retval = State.ONE_ARM;
        else if ((n_arms == 0) && (n_legs == 0))
            retval = State.NO_LIMBS;
        else
            retval = State;
        return retval;
    }
}
