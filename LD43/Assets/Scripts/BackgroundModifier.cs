using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundModifier : MonoBehaviour {

    public string backgroundID;
    public GameObject backgroundManagerHolder; // MAIN CAMERA

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        // CHANGE BACKGROUND IF SPECIFIED
        if ((backgroundID.Length > 0) && (!!backgroundManagerHolder))
        {
            BackgroundManager bm = backgroundManagerHolder.GetComponent<BackgroundManager>();
            if (!!bm)
                bm.changeBackground(backgroundID);
        }
    }
}
