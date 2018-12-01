using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog
{

    // ATTRS
    private List<DBlock> dialogChain { get; set; }
    public  DBlock       dialogChainCurrentElem { get; set; }
    public  DBlock       dialogChainRoot { get; set; }

    public Dialog(int iRoot)
    {
        dialogChainRoot = DialogBank.getDialogStartFromId(iRoot);
        if (dialogChainRoot!=null)
        {
            dialogChainCurrentElem = dialogChainRoot;
            dialogChain = new List<DBlock>();
            dialogChain.Add(dialogChainCurrentElem);
        }
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

    public Dictionary<string, DBlock> getChoices()
    { return dialogChainCurrentElem.responses; }
	
    public bool tryPursueDialog(string iChoiceKey)
    {
        Debug.Log("tryPursueDialog");

        if (dialogChainCurrentElem.isFinalBlock())
        {
            Debug.Log("rtrtrt");
            return false;
        }
        if (dialogChainCurrentElem.responses.Count==0)
        {
            Debug.Log("gnhyntyhn");
            return false;
        }
        if (dialogChainCurrentElem.responses.Count == 1)
        {
            Debug.Log("MONO REPOZNZZ");
            dialogChainCurrentElem = ((DBlock)dialogChainCurrentElem.responses[DialogBank.MONO_DIALOG]);
            return true;
        }
        else if (iChoiceKey != null)
        {
            DBlock nextDialogBlock;
            dialogChainCurrentElem.responses.TryGetValue(iChoiceKey, out nextDialogBlock);
            dialogChainCurrentElem = nextDialogBlock;
            return true;
        }
        return true;
    }
}
