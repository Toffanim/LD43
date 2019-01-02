using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBank : MonoBehaviour {

    public const int ERROR_CODE = -1;
    public const string MONO_DIALOG = "...";

    public static NPCDialogDico getDialogFromID(int iID)
    {
        NPCDialogDico retDialog = null;
        switch (iID)
        {
            case 1:
                retDialog = wizard1();
                break;
            case 2:
                retDialog = wizard2();
                break;
            case 3:
                retDialog = wizard3();
                break;
            case 4:
                retDialog = wizard4();
                break;
            case 5:
                retDialog = wizard5();
                break;
            case 6:
                retDialog = princess();
                break;
            case 7:
                retDialog = endgameBad();
                break;
            case 8:
                retDialog = endgameGood();
                break;
            case ERROR_CODE:
                retDialog = getErrorBlock();
                break;
            default:
                retDialog = getDialogNotFound();
                break;
        }
        if (retDialog != null)
            Debug.Log("RET DBANK from ID" + iID);
        return retDialog;
    }

    public static NPCDialogDico wizard1()
    {
        /*
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
        */
        return null;

    }

    public static NPCDialogDico wizard2()
    {
        /*
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
        */
        return null;
    }

    public static NPCDialogDico wizard3()
    {
        /*
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
        */
        return null;
    }

    public static NPCDialogDico wizard4()
    {
        /*
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
        */
        return null;
    }

    public static NPCDialogDico wizard5()
    {
        /*
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
        */
        return null;
    }

    public static NPCDialogDico princess()
    {
        NPCDialogDico dico = new NPCDialogDico();

        // CREATE CELLS
        QBlock q0 = new QBlock("Help meeeeeeee!");
        DialogCell cell0 = new DialogCell(q0);
        dico.addDialogCell(cell0);

        QBlock q1 = new QBlock("Someone please help me !!", DBlock.DBLOCK_EFFECTS.NEXT_CINEMATIC_STEP);
        DialogCell cell1 = new DialogCell(q1);
        dico.addDialogCell(cell1);

        // UPDATE LINKS
        cell0.defaultSuccessorID = cell1.getID();

        // SET STARTING CELL
        dico.setStartingCellFromID(cell0.getID());

        // 
        dico.finishDicoCreation();

        if (dico != null) // TODO WE HAVE A NULL DICO ROFLMAOOOOOOOOOOOOOOOOO
            Debug.Log("NOT NULL FOR FUCK SAKE");
        else Debug.Log("...");

        return dico;
    }

    public static NPCDialogDico endgameBad()
    {
        /*
        DBlock retBlock = null;

        Dictionary<string, DBlock> dicoA = new Dictionary<string, DBlock>();
        dicoA.Add(MONO_DIALOG, new DBlock("Look at yourself! You're not a hero!"));

        retBlock = new DBlock("You made it.. but at what cost?", dicoA);

        return retBlock;
        */
        return null;
    }

    public static NPCDialogDico endgameGood()
    {
        /*
        DBlock retBlock = null;

        Dictionary<string, DBlock> dicoA = new Dictionary<string, DBlock>();
        dicoA.Add(MONO_DIALOG, new DBlock("I shall be yours as you prove your valor."));

        retBlock = new DBlock("You're a valourous knight!", dicoA);

        return retBlock;
        */
        return null;
    }

    public static NPCDialogDico getErrorBlock()
    {
        /*
        DBlock retval = DialogBank.getDialogFromID(ERROR_CODE);
        return retval;
        */
        return null;
    }

    public static NPCDialogDico getDialogNotFound()
    {
        /*
        DBlock retval = DialogBank.getDialogFromID(ERROR_CODE);
        return retval;
        */
        return null;
    }
}
