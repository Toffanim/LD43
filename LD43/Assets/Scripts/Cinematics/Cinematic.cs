using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour {


    // REQUIRED ACTORS
    public GameObject princessGO;
    public GameObject cameraGO;
    public GameObject playerGO;

    // PR ATTR
    protected bool cinematicMustBePlayed;
    protected bool ableToLaunchSequence;
    protected bool cinematicIsPlaying;
    
    // PU ATTR
    public int currentCinematicStage { get; set; }

    // VIRTUAL
    public virtual void play() { }

    // GENERIC
    public void playCinematic() { currentCinematicStage++; play(); }

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

        playCinematic();
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
        cinematicMustBePlayed = false;
    }

    // UNITY
    void Start () {
        currentCinematicStage = 0;
    }
	
	void Update () {
        if (cinematicIsPlaying)
            playCinematic();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc && cinematicMustBePlayed)
        { cinematicIsPlaying = true; launchCinematic(); }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc && cinematicMustBePlayed)
        { cinematicIsPlaying = false; quitCinematic(); }
    }
}
