using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneForAllButPlayer : MonoBehaviour
{
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
        if (pc==null)
        {
            PlayerController pc_ = other.GetComponentInParent<PlayerController>(); // Don't kill weapon :(
            if(pc_ == null) Destroy(other.gameObject);
        }
    }
}