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

    public float Speed;
    public float accel = 6f;
    public float airAccel = 3f;
    public float jump = 14f;
    // Use this for initialization
    void Start () {
        State = State.IDLE;
        Speed = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
