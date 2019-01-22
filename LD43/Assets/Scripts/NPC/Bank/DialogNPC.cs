using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : NPC
{
    // SETTABLE
    public int dialogID;
    public bool resetDialog;
    public GameObject dialogUI;

    // Start is called before the first frame update
    void Start()
    {
        this.INTList = new List<INPCType>();

        DialogNT dialNT = gameObject.AddComponent<DialogNT>();
        dialNT.Init(this, dialogUI, dialogID);
        dialNT.resetDialog = resetDialog;

        INTList.Add(dialNT);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
