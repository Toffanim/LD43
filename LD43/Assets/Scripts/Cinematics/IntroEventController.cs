﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEventController : Cinematic {



    // Use this for initialization
    void Start () {
        ableToLaunchSequence = !!princessGO && !!cameraGO && !!playerGO;
        cinematicMustBePlayed = true && ableToLaunchSequence;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public override void play()
    {
        // [..]
        if (currentCinematicStage == 0)
        {
            moveCameraToPrincess();

            // AUTOTALK TO PRINCESS
            DialogNPC talkative = GetComponent<DialogNPC>();
            talkative.capturedPlayerControlled = playerGO.GetComponent<PlayerController>();
            if (!!talkative)
                talkative.interactWithType(NPCTypeNames.dialog);
        }
        if (currentCinematicStage > 1)
        {
            quitCinematic();
            Destroy(gameObject);
        }
    }



    void moveCameraToPrincess()
    {
        Transform target = princessGO.transform;
        CinematicFollower CF = cameraGO.GetComponent<CinematicFollower>();
        if(!!CF)
        {
            CF.setNewTarget(princessGO);
        }
    }

    IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
