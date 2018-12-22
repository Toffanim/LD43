using System.Collections;
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

    public override void playCinematic()
    {
        // [..]
        if (currentCinematicStage == 0)
        {
            moveCameraToPrincess();

            // TALK TO PRINCESS
            NPC talkative = GetComponent<NPC>();
            if (!!talkative)
                talkative.dialog();
        }
        if (currentCinematicStage >= 2)
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
