using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBank {

    public static Dictionary<string, DBlock> RESPONSE_DICO =
        new Dictionary<string, DBlock>
    {
        {"OK, Let's do this !", new DBlock("You made the right decision my friend!") },
        {"No way I'm doing it.", new DBlock("As you wish...") }
    };

    public const int ERROR_CODE = -1;
    public const string MONO_DIALOG = "...";

    public static DBlock getDialogStartFromId(int iID)
    {
        DBlock retBlock = null;
        switch (iID)
        {
            case 3:
                retBlock = introWizard();
                break;
            case ERROR_CODE:
                retBlock = new DBlock("something wrong happened.;.");
                break;
            default:
                retBlock = new DBlock("BLOCK NOT FOUND FOR ID ");
                break;
        }
        return retBlock;
    }

    public static DBlock introWizard()
    {
        DBlock retBlock = null;
        Dictionary<string, DBlock> dicoA = new Dictionary<string, DBlock>();
        DBlock choiceA = new DBlock("You made the right decision my friend!", "OK, Let's do this !", DBlock.DBLOCK_EFFECTS.LOSE_ARM);
        DBlock choiceB = new DBlock("As you wish...", "No way I'm doing it.");
        dicoA.Add(choiceA.rootKey, choiceA);
        dicoA.Add(choiceB.rootKey, choiceB);

        Dictionary<string, DBlock> dicoB = new Dictionary<string, DBlock>();
        dicoB.Add(MONO_DIALOG, new DBlock("I can help you pass this locked door but it will cost you an arm.", dicoA));

        Dictionary<string, DBlock> dicoC = new Dictionary<string, DBlock>();
        dicoC.Add(MONO_DIALOG, new DBlock("Good morning sir. ", dicoB));

        retBlock = new DBlock("TEST ONLY", dicoC);

        return retBlock;

    }

    public static DBlock getErrorBlock()
    {
        DBlock retval = DialogBank.getDialogStartFromId(ERROR_CODE);
        return retval;
    }
}
