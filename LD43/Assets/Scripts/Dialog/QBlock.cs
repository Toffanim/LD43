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

    public override string getMessage() { return message; }

    // UNITY
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
