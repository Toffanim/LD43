using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEventController : Cinematic {

    // REQUIRED ACTORS
    public GameObject princessGO;
    public GameObject cameraGO;
    public GameObject playerGO;

    private bool cinematicMustBePlayed;
    private bool ableToLaunchSequence;
    private bool cinematicIsPlaying;
    //PV ATTR



    // Use this for initialization
    void Start () {
        ableToLaunchSequence = !!princessGO && !!cameraGO && !!playerGO;
        cinematicMustBePlayed = true && ableToLaunchSequence;
    }
	
	// Update is called once per frame
	void Update () {
        if (cinematicIsPlaying)
            launchCinematic();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc && cinematicMustBePlayed)
        { launchCinematic(); }
        */
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc && cinematicMustBePlayed)
        { cinematicIsPlaying = true; cinematicMustBePlayed = false; }
    }

    public void launchCinematic()
    {
        // GET
        PlayerController pc = playerGO.GetComponent<PlayerController>();
        PlayerFollower playerFollow = cameraGO.GetComponent<PlayerFollower>();
        CinematicFollower CF = cameraGO.GetComponent<CinematicFollower>();

        // LOGIC
        if (!!pc)
        {
            pc.freezeMovements = true;
            if (!!playerFollow)
                playerFollow.paused = true;
        }
        if (!!CF)
        {
            CF.paused = false;
        }

        // [..]
        if (currentCinematicStage == 0)
        {
            moveCameraToPrincess();


            // TALK TO PRINCESS
            NPC talkative = GetComponent<NPC>();
            if (!!talkative)
                talkative.dialog();
        }
        if (currentCinematicStage == 2)
        {
            quitCinematic();
            Destroy(gameObject);
        }
    }

    public void quitCinematic()
    {
        Debug.Log("quitCinematic.....");

        // GET
        PlayerController pc = playerGO.GetComponent<PlayerController>();
        PlayerFollower playerFollow = cameraGO.GetComponent<PlayerFollower>();
        CinematicFollower CF = cameraGO.GetComponent<CinematicFollower>();

        // LOGIC
        if (!!pc)
        {
            pc.freezeMovements = false;
            if (!!playerFollow)
                playerFollow.paused = false;
        }
        if (!!CF)
        {
            CF.paused = true;
        }
        ableToLaunchSequence = true;
        cinematicIsPlaying = false;
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
