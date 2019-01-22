using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPrincessController : MonoBehaviour
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
        PlayerState ps = other.GetComponent<PlayerState>();
        DialogNT npc = gameObject.GetComponent<DialogNT>();
        if (!!ps && !!npc)
            npc.loadNewDialog( (ps.State != State.CHAIR_BALL) ? 
                8 /* GOOD ENDING :) */ : 
                7 /* BAD  ENDING :( */ );
        Debug.Log("DIALOG ID : " + npc.dialogID);
    }
}
