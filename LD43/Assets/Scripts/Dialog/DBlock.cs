using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBlock {

    // ATTRS
    public string message;
    public Dictionary<string, DBlock> responses;
    public string rootKey; //responseKey
    public DBlock(string iMessage)
    {
        message = iMessage;
        rootKey = DialogBank.MONO_DIALOG;
    }

    public DBlock(string iMessage, string iRootKey)
    {
        message = iMessage;
        rootKey = iRootKey;
    }

    public bool isFinalBlock()
    {
        return ( (responses == null)||(responses.Count==0) );
    }

    public DBlock(string iMessage, Dictionary<string, DBlock> iResponses)
    {
        message = iMessage;
        rootKey = DialogBank.MONO_DIALOG;
        responses = iResponses;
    }

    public DBlock(string iMessage, Dictionary<string, DBlock> iResponses, string iRootKey)
    {
        message = iMessage;
        responses = iResponses;
        rootKey = iRootKey;
    }

}
