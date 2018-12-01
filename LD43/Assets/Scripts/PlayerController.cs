﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct MovementInputs {
    public float X;
    public float Y;
}

public class PlayerController : MonoBehaviour
{    
    PlayerState State;

    public static KeyCode AccelarationKey = KeyCode.LeftShift;

    public MovementInputs Inputs;

    //PV ATTR
    public NPC npcInRange { get; set; }

    // Use this for initialization
    void Start()
    {
        State = GetComponent<PlayerState>();
        npcInRange = null;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Talk") && !!npcInRange)
            npcInRange.dialog();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Inputs.X = Input.GetAxis("Horizontal") >= 0 ? (float) Math.Ceiling(Input.GetAxis("Horizontal")) : (float)Math.Floor(Input.GetAxis("Horizontal"));
        Inputs.Y = Input.GetButtonDown("Jump") ? 1 : 0;//(float)Math.Ceiling((double)Input.GetAxis("Vertical"));
        State.State = Input.GetButtonDown("Jump") ? global::State.JUMP : State.State ;

    }
}

