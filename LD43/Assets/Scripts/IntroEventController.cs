using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEventController : MonoBehaviour {

    // REQUIRED ACTORS
    public GameObject princessGO;
    public GameObject cameraGO;
    public GameObject playerGO;

    private bool cinematicMustBePlayed;
    private bool ableToLaunchSequence;

    //PV ATTR
    private Vector3 Velocity = Vector3.zero;
    float SmoothSpeed = 0.3f;


    // Use this for initialization
    void Start () {
        ableToLaunchSequence = !!princessGO && !!cameraGO && !!playerGO;
        cinematicMustBePlayed = true && ableToLaunchSequence;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc && cinematicMustBePlayed)
        { launchCinematic(); }
    }

    public void launchCinematic()
    {
        cinematicMustBePlayed = false;

        // GET
        PlayerController pc = playerGO.GetComponent<PlayerController>();
        PlayerFollower playerFollow = cameraGO.GetComponent<PlayerFollower>();

        // LOGIC
        if (!!pc)
        {
            pc.freezeMovements = true;
            if (!!playerFollow)
                playerFollow.paused = true;
        }

        // [..]
        moveCameraToPrincess();

        Debug.Log("HELLO WORLD.....");

        // TALK TO PRINCESS
        NPC talkative = GetComponent<NPC>();
        if (!!talkative)
            talkative.dialog();

        Wait(2);

        quitCinematic();

    }

    public void quitCinematic()
    {
        // GET
        PlayerController pc = playerGO.GetComponent<PlayerController>();
        PlayerFollower playerFollow = cameraGO.GetComponent<PlayerFollower>();

        // LOGIC
        if (!!pc)
        {
            pc.freezeMovements = false;
            if (!!playerFollow)
                playerFollow.paused = false;
        }
        ableToLaunchSequence = true;
    }

    void moveCameraToPrincess()
    {
        Transform target = princessGO.transform;
        Vector3 DesiredPosition;
        if (!!target)
        {
            DesiredPosition = target.position;
            Vector3 SmoothedPosition = Vector3.SmoothDamp(transform.position, DesiredPosition, ref Velocity, SmoothSpeed);
            transform.position = new Vector3(SmoothedPosition.x, SmoothedPosition.y, transform.position.z);
        }
    }

    IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
