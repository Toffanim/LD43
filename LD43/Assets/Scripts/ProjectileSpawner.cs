using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {
    public GameObject SpawnObject;

    float CoolDown = 0.5f;
    float CoolDownCount = 0;
	// Use this for initialization
	void Start () {
		
	}

    void SpawnEnnemy()
    {
        GameObject Ennemy = GameObject.Instantiate(SpawnObject, transform.position, new Quaternion()) as GameObject;
        var Dir = GameObject.Find("Player 1").transform.position - Ennemy.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (CoolDownCount <= 0) {
            SpawnEnnemy();
            CoolDownCount = CoolDown;
        }

        CoolDownCount -= Time.deltaTime;        
	}
}
