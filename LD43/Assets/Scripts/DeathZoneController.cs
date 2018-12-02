using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneController : MonoBehaviour
{
    public GameObject respawnLocationGO;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
            if (!!respawnLocationGO)
            {
                 pc.teleportToLocation(respawnLocationGO.gameObject.transform);
            }
            else
                pc.kill();
        }
    }
}
