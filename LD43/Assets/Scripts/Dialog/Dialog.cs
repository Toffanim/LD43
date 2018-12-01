using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {

    // ATTRS
    private List<DBlock> dialogChain { get; set; }
    private DBlock       dialogChainCurrentElem { get; set; }
    public  DBlock       dialogChainRoot { get; set; }

    public Dialog()
    {
        if (!!dialogChainRoot)
        {
            dialogChainCurrentElem = dialogChainRoot;
            dialogChain = new List<DBlock>();
            dialogChain.Add(dialogChainCurrentElem);
        }
    }

    // Use this for initialization
    void Start () {

	}

    public Dictionary<string, DBlock> getChoices()
    { return dialogChainCurrentElem.responses; }
	
    public void makeChoice(string iChoiceKey)
    {
        DBlock nextDialog;
        dialogChainCurrentElem.responses.TryGetValue(iChoiceKey,  out nextDialog);
        dialogChainCurrentElem = nextDialog;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
