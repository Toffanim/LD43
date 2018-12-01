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

    public bool CanAttack = true;

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
		
	}

    public void mutilate(DBlock.DBLOCK_EFFECTS iBlockEffect)
    {
        switch (iBlockEffect)
        {
            case DBlock.DBLOCK_EFFECTS.LOSE_ARM:
                n_arms--;
                State = processNewPlayerState();
                Debug.Log("MUTILATE ARM");
                break;
            case DBlock.DBLOCK_EFFECTS.LOSE_LEG:
                n_legs--;
                State = processNewPlayerState();
                Debug.Log("MUTILATE LEG");
                break;
            case DBlock.DBLOCK_EFFECTS.LOSE_BODY:
                State = State.CHAIR_BALL;
                break;
            default:
                break;
        }
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
