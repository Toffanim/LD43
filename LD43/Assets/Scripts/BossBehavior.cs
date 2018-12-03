using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour {
    float Speed = 0.01f;
    float offsetY = 0;
    GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player 1");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var Dir = new Vector3(this.transform.position.x, this.transform.position.y + offsetY, this.transform.position.z) - Player.transform.position ;
        Dir.Normalize();

        this.transform.position -= Dir * Speed;
	}
}
