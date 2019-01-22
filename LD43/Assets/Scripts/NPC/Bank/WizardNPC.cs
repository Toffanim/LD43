using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class WizardNPC : NPC
{
    // SETTABLE
    public int dialogID;
    public bool resetDialog ;
    public GameObject guardedDoor;
    public GameObject dialogUI;

    public bool playerMutilated = false;

    // Start is called before the first frame update
    void Start()
    {
        this.INTList = new List<INPCType>();
        playerMutilated = false;

        DialogNT dialNT = gameObject.AddComponent<DialogNT>();
        dialNT.Init(this, dialogUI, dialogID);
        dialNT.resetDialog = resetDialog;

        DoorguardNT doorNT = gameObject.AddComponent<DoorguardNT>();
        doorNT.Init(this, guardedDoor);

        INTList.Add(dialNT);
        INTList.Add(doorNT);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

