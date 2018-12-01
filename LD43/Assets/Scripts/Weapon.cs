using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Damage!!!!!");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
