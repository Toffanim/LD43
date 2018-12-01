using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    BoxCollider2D BC;
	// Use this for initialization
	void Start () {
        BC = GetComponent<BoxCollider2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Do dmg!
        Debug.Log("Damage!");
    }
    // Update is called once per frame
    void Update () {
    }

}
