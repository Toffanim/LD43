using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Dialog
{

    // ATTRS
    private List<DBlock> dialogResponses{ get; set; }
    private int currentResponseIndex { get; set; }

    public  DBlock       dialogChainCurrentElem { get; set; }
    public  DBlock       responseCurrentElem { get; set; }


    public DBlock       dialogChainRoot { get; set; }

    public Dialog(int iRoot)
    {
        currentResponseIndex = 0;
        dialogChainRoot = DialogBank.getDialogStartFromId(iRoot);
        if (dialogChainRoot!=null)
        {
            dialogChainCurrentElem = dialogChainRoot;
            //dialogResponses = new List<DBlock>();
            //fillResponses();
        }
    }

    public void changeResponse()
    {
        currentResponseIndex++;
        if ( currentResponseIndex >= dialogChainCurrentElem.responses.Count)
            currentResponseIndex = 0;
    }

    public void resetDialog()
    {
        dialogChainCurrentElem = dialogChainRoot;
    }

    public string getMessage()
    {
        string s = dialogChainCurrentElem.message;
        return (s!=null)?s:"not found";
    }

    public string getResponse()
    {
        string s = dialogChainCurrentElem.responses.Values.ElementAt(currentResponseIndex).message;
        return (s != null) ? s : "not found";
    }

    public string getResponseKey()
    {
        string s = (dialogChainCurrentElem.isFinalBlock()) ?
         DialogBank.MONO_DIALOG : 
         dialogChainCurrentElem.responses.Values.ElementAt(currentResponseIndex).rootKey;
        Debug.Log("ID : " + currentResponseIndex + "  msg : " + s);
        return (s != null) ? s : "not found";
    }

    public DBlock.DBLOCK_EFFECTS getBlockEffect()
    {
        return dialogChainCurrentElem.blockEffect;
    }

    public Dictionary<string, DBlock> getChoices()
    { return dialogChainCurrentElem.responses; }
	
    public bool tryPursueDialog()
    {
        if (dialogChainCurrentElem.isFinalBlock())
            return false;
        if (dialogChainCurrentElem.responses.Count==0)
            return false;
        if (dialogChainCurrentElem.responses.Count == 1)
        {
            dialogChainCurrentElem = ((DBlock)dialogChainCurrentElem.responses[DialogBank.MONO_DIALOG]);
            return true;
        }
        else if (dialogChainCurrentElem.responses.Count > 1)
        {
            string response_key = dialogChainCurrentElem.responses.Values.ElementAt(currentResponseIndex).rootKey;
            dialogChainCurrentElem = ((DBlock)dialogChainCurrentElem.responses[response_key]);
            return true;
        }
        return true;
    }
}
