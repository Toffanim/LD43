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
            case 1:
                retBlock = wizard1();
                break;
            case 2:
                retBlock = wizard2();
                break;
            case 3:
                retBlock = wizard3();
                break;
            case 4:
                retBlock = wizard4();
                break;
            case 5:
                retBlock = wizard5();
                break;
            case 6:
                retBlock = princess();
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

    public static DBlock wizard1()
    {
        DBlock retBlock = null;
        Dictionary<string, DBlock> dicoA = new Dictionary<string, DBlock>();
        DBlock choiceA = new DBlock("You made the right decision my friend!", "OK, Let's do this !", DBlock.DBLOCK_EFFECTS.LOSE_ARM);
        DBlock choiceB = new DBlock("As you wish...", "No way I'm doing it.");
        dicoA.Add(choiceA.rootKey, choiceA);
        dicoA.Add(choiceB.rootKey, choiceB);

        Dictionary<string, DBlock> dicoB = new Dictionary<string, DBlock>();
        dicoB.Add(MONO_DIALOG, new DBlock("I can help you pass this weird door but it will cost you an arm.", dicoA));

        Dictionary<string, DBlock> dicoC = new Dictionary<string, DBlock>();
        dicoC.Add(MONO_DIALOG, new DBlock("Beautiful Princess, heh?", dicoB));

        retBlock = new DBlock("Wizard1 : Good morning sir.", dicoC);

        return retBlock;

    }

    public static DBlock wizard2()
    {
        DBlock retBlock = null;
        Dictionary<string, DBlock> dicoA = new Dictionary<string, DBlock>();
        DBlock choiceA = new DBlock("You made the right decision my friend!", "OK, Let's do this !", DBlock.DBLOCK_EFFECTS.LOSE_LEG);
        DBlock choiceB = new DBlock("As you wish...", "No way I'm doing it.");
        dicoA.Add(choiceA.rootKey, choiceA);
        dicoA.Add(choiceB.rootKey, choiceB);

        Dictionary<string, DBlock> dicoB = new Dictionary<string, DBlock>();
        dicoB.Add(MONO_DIALOG, new DBlock("I can help you pass this weird door but it will cost you a leg.", dicoA));

        Dictionary<string, DBlock> dicoC = new Dictionary<string, DBlock>();
        dicoC.Add(MONO_DIALOG, new DBlock("Beautiful Princess, heh?", dicoB));

        retBlock = new DBlock("Wizard2 : Good morning sir.", dicoC);

        return retBlock;

    }

    public static DBlock wizard3()
    {
        DBlock retBlock = null;
        Dictionary<string, DBlock> dicoA = new Dictionary<string, DBlock>();
        DBlock choiceA = new DBlock("You made the right decision my friend!", "OK, Let's do this !", DBlock.DBLOCK_EFFECTS.LOSE_LEG);
        DBlock choiceB = new DBlock("As you wish...", "No way I'm doing it.");
        dicoA.Add(choiceA.rootKey, choiceA);
        dicoA.Add(choiceB.rootKey, choiceB);

        Dictionary<string, DBlock> dicoB = new Dictionary<string, DBlock>();
        dicoB.Add(MONO_DIALOG, new DBlock("I can help you pass this weird door but it will cost you a leg.", dicoA));

        Dictionary<string, DBlock> dicoC = new Dictionary<string, DBlock>();
        dicoC.Add(MONO_DIALOG, new DBlock("Beautiful Princess, heh?", dicoB));

        retBlock = new DBlock("Wizard3 : Good morning sir.", dicoC);

        return retBlock;

    }

    public static DBlock wizard4()
    {
        DBlock retBlock = null;
        Dictionary<string, DBlock> dicoA = new Dictionary<string, DBlock>();
        DBlock choiceA = new DBlock("You made the right decision my friend!", "OK, Let's do this !", DBlock.DBLOCK_EFFECTS.LOSE_ARM);
        DBlock choiceB = new DBlock("As you wish...", "No way I'm doing it.");
        dicoA.Add(choiceA.rootKey, choiceA);
        dicoA.Add(choiceB.rootKey, choiceB);

        Dictionary<string, DBlock> dicoB = new Dictionary<string, DBlock>();
        dicoB.Add(MONO_DIALOG, new DBlock("I can help you pass this weird door but it will cost you an arm.", dicoA));

        Dictionary<string, DBlock> dicoC = new Dictionary<string, DBlock>();
        dicoC.Add(MONO_DIALOG, new DBlock("Beautiful Princess, heh?", dicoB));

        retBlock = new DBlock("Wizard4 : Good morning sir.", dicoC);

        return retBlock;

    }

    public static DBlock wizard5()
    {
        DBlock retBlock = null;
        Dictionary<string, DBlock> dicoA = new Dictionary<string, DBlock>();
        DBlock choiceA = new DBlock("You made the right decision my friend!", "OK, Let's do this !", DBlock.DBLOCK_EFFECTS.LOSE_BODY);
        DBlock choiceB = new DBlock("As you wish...", "No way I'm doing it.");
        dicoA.Add(choiceA.rootKey, choiceA);
        dicoA.Add(choiceB.rootKey, choiceB);

        Dictionary<string, DBlock> dicoB = new Dictionary<string, DBlock>();
        dicoB.Add(MONO_DIALOG, new DBlock("I can help you beat this abomination but it will cost your humanity.", dicoA));

        Dictionary<string, DBlock> dicoC = new Dictionary<string, DBlock>();
        dicoC.Add(MONO_DIALOG, new DBlock("Beautiful Princess, heh?", dicoB));

        retBlock = new DBlock("Wizard4 : Good morning sir.", dicoC);

        return retBlock;

    }

    public static DBlock princess()
    {
        DBlock retBlock = null;

        retBlock = new DBlock("Help meeeeeeee!.");

        return retBlock;
    }

    public static DBlock getErrorBlock()
    {
        DBlock retval = DialogBank.getDialogStartFromId(ERROR_CODE);
        return retval;
    }
}
