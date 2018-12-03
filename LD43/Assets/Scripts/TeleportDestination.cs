using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDestination : MonoBehaviour {

    public GameObject backgroundManagerHolder; // MAIN CAMERA
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Transform teleportToMe(string callerID)
    {
        // CHANGE BACKGROUND IF SPECIFIED
        if ((callerID.Length > 0) && (!!backgroundManagerHolder))
        {
            BackgroundManager bm = backgroundManagerHolder.GetComponent<BackgroundManager>();
            if (!!bm)
                bm.changeBackground(callerID);
        }

        return gameObject.transform;
    }
}
