using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCinematicNPC : NPC
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

        CinematicNT cineNT = gameObject.AddComponent<CinematicNT>();
        cineNT.Init(this);


        INTList.Add(dialNT);
        INTList.Add(cineNT);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
