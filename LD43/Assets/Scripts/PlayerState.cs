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
    NO_LIMBS          // o-|
}

public class PlayerState : MonoBehaviour {

    public State State;

    public float Speed = 10;
    public float accel = 6f;
    public float airAccel = 6f;
    public float jump = 0.1f;

    public bool CanAttack = true;
    // Use this for initialization
    void Start () {
        State = State.FULL_BODY;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
