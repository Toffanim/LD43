using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour {

    public string teleportID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
            TeleportDestination td = GetComponentInChildren<TeleportDestination>();
            if(!!td)
            {
                pc.teleportToLocation( td.teleportToMe(teleportID) );
            }
        }
    }

}
