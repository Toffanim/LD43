using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBlock : DBlock {

    // CTORS
    public QBlock(string iMessage) : base(iMessage)
    {
    }

    public QBlock(string iMessage, DBLOCK_EFFECTS iBlockEffect) : base(iMessage, iBlockEffect)
    {
    }

    public QBlock(string iQuestion, string iAnswer) : base(iQuestion, iAnswer)
    {
    }

    public QBlock(string iQuestion, List<string> iResponses) : base(iQuestion, iResponses)
    {
    }

    public QBlock(string iQuestion, string iAnswer, DBLOCK_EFFECTS iBlockEffect) : base(iQuestion, iAnswer, iBlockEffect)
    {
    }

    public QBlock(string iQuestion, List<string> iResponses, DBLOCK_EFFECTS iBlockEffect) : base(iQuestion, iResponses, iBlockEffect)
    {
    }

    public override string getMessage() { return predecessor; }

    // UNITY
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
