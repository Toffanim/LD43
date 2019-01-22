using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorguardNT : MonoBehaviour, INPCType
{
    // INPCType ATTR
    public string   typeName { get { return NPCTypeNames.doorguard; } }
    public NPC      attachedNPC { get { return _attachedNPC; } set { _attachedNPC = value; } }
    public bool isActive { get { return _isActive; } }

    protected bool _isActive;

    //DoorguardNT ATTR
    protected NPC _attachedNPC;
    public bool doorIsLocked = true;
    public GameObject guardedDoor;


    public void action()
    {
        if ( !doorIsLocked )
            openDoor();
        _isActive = true;
    }
    public void action2()
    {
        doorIsLocked = false;
        _isActive = true;
    }

    public void exit()
    {
        _isActive = false;
    }
    public void notifyPlayerPresence(PlayerController pc)
    { }
    public void notifyPlayerLeaving(PlayerController pc)
    {
    }
    // CTOR
    public void Init( NPC iAttachedNPC, GameObject iGuardedDoor) 
    {
        _attachedNPC = iAttachedNPC;
        guardedDoor = iGuardedDoor;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void openDoor()
    {
        if (!!guardedDoor)
        {
            MagicDoorController mgc = guardedDoor.GetComponent<MagicDoorController>();
            if (!!mgc)
            { mgc.open(); doorIsLocked = false; }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
