using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour {
    public GameObject SpawnObject;

    public float CoolDown = 1f;
    public float CoolDownCount = 0;

    // Use this for initialization
    void Start () {
		
	}

    void SpawnEnnemy()
    {
        GameObject Ennemy = GameObject.Instantiate(SpawnObject, transform.position, new Quaternion()) as GameObject;
        Ennemy.GetComponent<CircleCollider2D>().radius = 10;
    }
	
	// Update is called once per frame
	void Update () {
        BossBehavior bb = GetComponentInParent<BossBehavior>();
        if (!!bb)
        {
            if (!!bb.activate)
            {
                if (CoolDownCount <= 0)
                {
                    SpawnEnnemy();
                    CoolDownCount = CoolDown;
                }

                CoolDownCount -= Time.deltaTime;
            }
        }
     
	}
}
