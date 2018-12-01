using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MovementInputs {
    public float X;
    public float y;
}

public class PlayerController : MonoBehaviour
{    
    PlayerState State;

    public static KeyCode AccelarationKey = KeyCode.LeftShift;

    public MovementInputs Inputs;

    // Use this for initialization
    void Start()
    {
        State = GetComponent<PlayerState>();
    }

    private void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Inputs.X = Input.GetAxis("Horizontal");
       Inputs.y = Input.GetAxis("Vertical");
        State.State = Input.GetButtonDown("jump") ? global::State.JUMP : State.State ;
    }
}

