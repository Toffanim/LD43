using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDoorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void open()
    {
        if (!!gameObject)
            Destroy(gameObject);
    }
}
