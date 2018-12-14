using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPController : MonoBehaviour {

    public GameObject trackedPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!!trackedPlayer)
        {
            PlayerState ps = trackedPlayer.GetComponent<PlayerState>();
            Text textComp = GetComponent<Text>();
            if (!!ps && !!textComp)
            { int val = ps.HP; textComp.text = val.ToString(); }
        }
	}
}
