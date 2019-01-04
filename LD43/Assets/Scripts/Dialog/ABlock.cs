using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABlock : DBlock {

    private const string DEFAULT_MUTE_DIALOG = "...";
    public string successor_dcell_ID;


    // CTORS
    public ABlock() : base("")
    {
        successor_dcell_ID = "";
    }

    public ABlock(string iMessage) : base(iMessage)
    {
        successor_dcell_ID = "";
    }

    public ABlock(string iMessage, DBLOCK_EFFECTS iBlockEffect) : base(iMessage, iBlockEffect)
    {
        successor_dcell_ID = "";
    }

    public ABlock(string iMessage, string iSuccessorDCellID) : base(iMessage)
    {
        successor_dcell_ID = iSuccessorDCellID;
    }

    public ABlock(string iMessage, DBLOCK_EFFECTS iBlockEffect, string iSuccessorDCellID) : base(iMessage, iBlockEffect)
    {
        successor_dcell_ID = iSuccessorDCellID;
    }

    public override string getMessage()
    {
        if (message.Length == 0)
            return DEFAULT_MUTE_DIALOG;
        return message;
    }

    public string getDialogCellIDSuccessor()
    {
        return successor_dcell_ID;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
