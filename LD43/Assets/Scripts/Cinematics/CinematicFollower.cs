﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicFollower : MonoBehaviour {

    public bool paused { get; set; }

    float SmoothSpeed = 0.3f;
    Transform target;
    private Vector3 Velocity = Vector3.zero;
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Princess").transform;
        paused = true;
    }

    public void setNewTarget(GameObject targetGO)
    {
        target = targetGO.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!paused)
        {
            Vector3 DesiredPosition;
            if (target)
            {
                DesiredPosition = target.position;
                Vector3 SmoothedPosition = Vector3.SmoothDamp(transform.position, DesiredPosition, ref Velocity, SmoothSpeed);
                transform.position = new Vector3(SmoothedPosition.x, SmoothedPosition.y, transform.position.z);
            }
        }
    }
}
