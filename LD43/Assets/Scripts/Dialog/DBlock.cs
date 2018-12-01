using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBlock {

    // ATTRS
    public string message;
    public Dictionary<string, DBlock> responses;

    public DBlock(string iMessage)
    {
        message = iMessage;
    }
    public bool isFinalBlock()
    {
        return ( (responses == null)||(responses.Count==0) );
    }

    public DBlock(string iMessage, Dictionary<string, DBlock> iResponses)
    {
        message = iMessage;
        responses = iResponses;
        /*
        if (iResponses != null)
        {
            responses = iResponses;
            isFinalBlock = false;
            DBlock futureBlock = null;
            foreach (string k in responses.Keys)
            {
                responses.TryGetValue(k, out futureBlock);
                isFinalBlock |= (futureBlock!=null);
                futureBlock = null;
            }
        }
        else
        {
            isFinalBlock = true;
        }
        */
    }
}
