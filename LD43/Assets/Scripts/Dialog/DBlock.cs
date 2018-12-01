using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBlock : MonoBehaviour {

    // ATTRS
    public string                       message         { get; set; }
    public Dictionary<string, DBlock>   responses       { get; set; }
    public bool                         isFinalBlock    { get; set; }

    // Use this for initialization
    void Start () {

        if (responses!=null )
        {
            isFinalBlock = false;
            DBlock futureBlock = null;
            foreach (string k in responses.Keys)
            {
                responses.TryGetValue(k, out futureBlock);
                isFinalBlock |= (!!futureBlock);
                futureBlock = null;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
