using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBlock {
    public enum     DBLOCK_EFFECTS  { NOTHING, LOSE_ARM, LOSE_LEG, LOSE_BODY, FINISH_CINEMATIC};

    // ATTRS
    public string message;
    public Dictionary<string, DBlock> responses;
    public string rootKey; //responseKey
    public DBLOCK_EFFECTS blockEffect { get; set; }

    public DBlock(string iMessage, DBLOCK_EFFECTS iBlockEffect)
    {
        message = iMessage;
        rootKey = DialogBank.MONO_DIALOG;
        blockEffect = iBlockEffect;
    }

    public DBlock(string iMessage)
    {
        message = iMessage;
        rootKey = DialogBank.MONO_DIALOG;
        blockEffect = DBLOCK_EFFECTS.NOTHING;
    }

    public DBlock(string iMessage, string iRootKey)
    {
        message = iMessage;
        rootKey = iRootKey;
        blockEffect = DBLOCK_EFFECTS.NOTHING;
    }

    public DBlock(string iMessage, string iRootKey, DBLOCK_EFFECTS iBlockEffect)
    {
        message = iMessage;
        rootKey = iRootKey;
        blockEffect = iBlockEffect;
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
        blockEffect = DBLOCK_EFFECTS.NOTHING;
    }

    public DBlock(string iMessage, Dictionary<string, DBlock> iResponses, string iRootKey)
    {
        message = iMessage;
        responses = iResponses;
        rootKey = iRootKey;
        blockEffect = DBLOCK_EFFECTS.NOTHING;
    }

}
