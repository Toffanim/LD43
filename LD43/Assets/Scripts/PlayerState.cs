using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    IDLE,
    WALK,
    JUMP
}

public class PlayerState : MonoBehaviour {

    public State State;

    public float Speed = 10;
    public float accel = 6f;
    public float airAccel = 6f;
    public float jump = 0.1f;
    // Use this for initialization
    void Start () {
        State = State.IDLE;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
