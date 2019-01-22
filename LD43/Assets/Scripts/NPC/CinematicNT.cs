using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicNT : MonoBehaviour, INPCType
{
    // INPCType ATTR
    public string typeName { get { return NPCTypeNames.cinematic; } }
    public NPC attachedNPC { get { return _attachedNPC; } set { _attachedNPC = value; } }
    public bool isActive { get { return _isActive; } }

    protected bool _isActive;

    // CinematicNT ATTR
    protected NPC _attachedNPC;

    public void action()
    {
        Cinematic c = _attachedNPC.GetComponent<Cinematic>();
        if (!!c)
        {
            Debug.Log("NEXT CINEMATIC STAGE");
            c.playCinematic();
        }
        _isActive = true;
    }
    public void action2()
    {
        _isActive = true;
    }

    public void exit()
    {
        Cinematic c = _attachedNPC.GetComponent<Cinematic>();
        if (!!c)
        {
            Debug.Log("EXIT CINEMATIC");
            c.quitCinematic();
        }
        _isActive = false;
    }
    public void notifyPlayerPresence(PlayerController pc)
    { }
    public void notifyPlayerLeaving(PlayerController pc)
    {
    }
    //CTOR
    public void Init( NPC iAttachedNPC )
    {
        _attachedNPC = iAttachedNPC;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
