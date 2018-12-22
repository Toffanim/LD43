using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABlock : DBlock {

    private const string DEFAULT_MUTE_DIALOG = "...";

    // CTORS
    public ABlock(string iMessage) : base(iMessage)
    {
    }

    public ABlock(string iMessage, DBLOCK_EFFECTS iBlockEffect) : base(iMessage, iBlockEffect)
    {
    }

    public ABlock(string iQuestion, string iAnswer) : base(iQuestion, iAnswer)
    {
    }

    public ABlock(string iQuestion, List<string> iResponses) : base(iQuestion, iResponses)
    {
    }

    public ABlock(string iQuestion, string iAnswer, DBLOCK_EFFECTS iBlockEffect) : base(iQuestion, iAnswer, iBlockEffect)
    {
    }

    public ABlock(string iQuestion, List<string> iResponses, DBLOCK_EFFECTS iBlockEffect) : base(iQuestion, iResponses, iBlockEffect)
    {
    }

    // PU METHODS
    public string getRelatedQuestion()
    {
        if ((successors != null) && (successors.Count > 0))
            return successors[0];
        return "";
    }

    public string getRelatedQuestion(int iIndex)
    {
        if ( (successors != null) && (successors.Count > 0) && (successors.Count < iIndex) )
            return successors[iIndex];
        return "";
    }

    public override string getMessage()
    {
        if (predecessor.Length == 0)
            return DEFAULT_MUTE_DIALOG;
        return predecessor;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
