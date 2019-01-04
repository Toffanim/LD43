using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBank {

    public const int ERROR_CODE = -1;
    public const string MONO_DIALOG = "...";

    public static void loadDicoFromID(int iDialogID, out NPCDialogDico iDico)
    {
        switch (iDialogID)
        {
            case 1:
                iDico = wizard1();
                break;
            case 2:
                iDico = wizard2();
                break;
            case 3:
                iDico = wizard3();
                break;
            case 4:
                iDico = wizard4();
                break;
            case 5:
                iDico = wizard5();
                break;
            case 6:
                iDico = princess();
                break;
            case 7:
                iDico = endgameBad();
                break;
            case 8:
                iDico = endgameGood();
                break;
            case ERROR_CODE:
                iDico = getErrorBlock();
                break;
            default:
                iDico = getDialogNotFound();
                break;
        }
        if (iDico != null)
            Debug.Log("RET DBANK from ID" + iDialogID);

    }

    public static NPCDialogDico wizard1()
    {
        NPCDialogDico dico = new NPCDialogDico();

        // CREATE CELLS
        QBlock q0 = new QBlock("Wizard : Good morning sir.");
        DialogCell cell0 = new DialogCell(q0);
        dico.addDialogCell(cell0);

        QBlock q1 = new QBlock("Beautiful Princess, heh?");
        DialogCell cell1 = new DialogCell(q1);
        dico.addDialogCell(cell1);

        QBlock q2 = new QBlock("I can help you pass this weird door but it will cost you an arm.");
        ABlock a21 = new ABlock("OK, Let's do this !");
        ABlock a22 = new ABlock("No way I'm doing it." );
        DialogCell cell2 = new DialogCell(q2);
        cell2.addAnswer(a21);
        cell2.addAnswer(a22);
        dico.addDialogCell(cell2);

        QBlock q3 = new QBlock("You made the right decision my friend!", DBlock.DBLOCK_EFFECTS.LOSE_ARM);
        DialogCell cell3 = new DialogCell(q3);
        dico.addDialogCell(cell3);

        QBlock q4 = new QBlock("As you wish...");
        DialogCell cell4 = new DialogCell(q4);
        dico.addDialogCell(cell4);

        // UPDATE LINKS
        cell0.defaultSuccessorID = cell1.getID();
        cell1.defaultSuccessorID = cell2.getID();
        a21.successor_dcell_ID = cell3.getID();
        a22.successor_dcell_ID = cell4.getID();

        // SET STARTING CELL
        dico.setStartingCellFromID(cell0.getID());

        dico.finishDicoCreation();

        return dico;
    }

    public static NPCDialogDico wizard2()
    {
        NPCDialogDico dico = new NPCDialogDico();

        // CREATE CELLS
        QBlock q0 = new QBlock("Wizard : Good morning sir.");
        DialogCell cell0 = new DialogCell(q0);
        dico.addDialogCell(cell0);

        QBlock q1 = new QBlock("Beautiful Princess, heh?");
        DialogCell cell1 = new DialogCell(q1);
        dico.addDialogCell(cell1);

        QBlock q2 = new QBlock("I can help you pass this weird door but it will cost you a leg.");
        ABlock a21 = new ABlock("OK, Let's do this !");
        ABlock a22 = new ABlock("No way I'm doing it.");
        DialogCell cell2 = new DialogCell(q2);
        cell2.addAnswer(a21);
        cell2.addAnswer(a22);
        dico.addDialogCell(cell2);

        QBlock q3 = new QBlock("You made the right decision my friend!", DBlock.DBLOCK_EFFECTS.LOSE_LEG);
        DialogCell cell3 = new DialogCell(q3);
        dico.addDialogCell(cell3);

        QBlock q4 = new QBlock("As you wish...");
        DialogCell cell4 = new DialogCell(q4);
        dico.addDialogCell(cell4);

        // UPDATE LINKS
        cell0.defaultSuccessorID = cell1.getID();
        cell1.defaultSuccessorID = cell2.getID();
        a21.successor_dcell_ID = cell3.getID();
        a22.successor_dcell_ID = cell4.getID();

        // SET STARTING CELL
        dico.setStartingCellFromID(cell0.getID());

        dico.finishDicoCreation();

        return dico;
    }

    public static NPCDialogDico wizard3()
    {
        NPCDialogDico dico = new NPCDialogDico();

        // CREATE CELLS
        QBlock q0 = new QBlock("Wizard : Good morning sir.");
        DialogCell cell0 = new DialogCell(q0);
        dico.addDialogCell(cell0);

        QBlock q1 = new QBlock("Beautiful Princess, heh?");
        DialogCell cell1 = new DialogCell(q1);
        dico.addDialogCell(cell1);

        QBlock q2 = new QBlock("I can help you pass this weird door but it will cost you a leg.");
        ABlock a21 = new ABlock("OK, Let's do this !");
        ABlock a22 = new ABlock("No way I'm doing it.");
        DialogCell cell2 = new DialogCell(q2);
        cell2.addAnswer(a21);
        cell2.addAnswer(a22);
        dico.addDialogCell(cell2);

        QBlock q3 = new QBlock("You made the right decision my friend!", DBlock.DBLOCK_EFFECTS.LOSE_LEG);
        DialogCell cell3 = new DialogCell(q3);
        dico.addDialogCell(cell3);

        QBlock q4 = new QBlock("As you wish...");
        DialogCell cell4 = new DialogCell(q4);
        dico.addDialogCell(cell4);

        // UPDATE LINKS
        cell0.defaultSuccessorID = cell1.getID();
        cell1.defaultSuccessorID = cell2.getID();
        a21.successor_dcell_ID = cell3.getID();
        a22.successor_dcell_ID = cell4.getID();

        // SET STARTING CELL
        dico.setStartingCellFromID(cell0.getID());

        dico.finishDicoCreation();

        return dico;
    }

    public static NPCDialogDico wizard4()
    {
        NPCDialogDico dico = new NPCDialogDico();

        // CREATE CELLS
        QBlock q0 = new QBlock("Wizard : Good morning sir.");
        DialogCell cell0 = new DialogCell(q0);
        dico.addDialogCell(cell0);

        QBlock q1 = new QBlock("Beautiful Princess, heh?");
        DialogCell cell1 = new DialogCell(q1);
        dico.addDialogCell(cell1);

        QBlock q2 = new QBlock("I can help you pass this weird door but it will cost you an arm.");
        ABlock a21 = new ABlock("OK, Let's do this !");
        ABlock a22 = new ABlock("No way I'm doing it.");
        DialogCell cell2 = new DialogCell(q2);
        cell2.addAnswer(a21);
        cell2.addAnswer(a22);
        dico.addDialogCell(cell2);

        QBlock q3 = new QBlock("You made the right decision my friend!", DBlock.DBLOCK_EFFECTS.LOSE_ARM);
        DialogCell cell3 = new DialogCell(q3);
        dico.addDialogCell(cell3);

        QBlock q4 = new QBlock("As you wish...");
        DialogCell cell4 = new DialogCell(q4);
        dico.addDialogCell(cell4);

        // UPDATE LINKS
        cell0.defaultSuccessorID = cell1.getID();
        cell1.defaultSuccessorID = cell2.getID();
        a21.successor_dcell_ID = cell3.getID();
        a22.successor_dcell_ID = cell4.getID();

        // SET STARTING CELL
        dico.setStartingCellFromID(cell0.getID());

        dico.finishDicoCreation();

        return dico;
    }

    public static NPCDialogDico wizard5()
    {
        NPCDialogDico dico = new NPCDialogDico();

        // CREATE CELLS
        QBlock q0 = new QBlock("Wizard : Good morning sir.");
        DialogCell cell0 = new DialogCell(q0);
        dico.addDialogCell(cell0);

        QBlock q1 = new QBlock("Beautiful Princess, heh?");
        DialogCell cell1 = new DialogCell(q1);
        dico.addDialogCell(cell1);

        QBlock q2 = new QBlock("I can help you beat this abomination but it will cost your humanity.");
        ABlock a21 = new ABlock("OK, Let's do this !");
        ABlock a22 = new ABlock("No way I'm doing it.");
        DialogCell cell2 = new DialogCell(q2);
        cell2.addAnswer(a21);
        cell2.addAnswer(a22);
        dico.addDialogCell(cell2);

        QBlock q3 = new QBlock("You made the right decision my friend!", DBlock.DBLOCK_EFFECTS.LOSE_BODY);
        DialogCell cell3 = new DialogCell(q3);
        dico.addDialogCell(cell3);

        QBlock q4 = new QBlock("As you wish...");
        DialogCell cell4 = new DialogCell(q4);
        dico.addDialogCell(cell4);

        // UPDATE LINKS
        cell0.defaultSuccessorID = cell1.getID();
        cell1.defaultSuccessorID = cell2.getID();
        a21.successor_dcell_ID = cell3.getID();
        a22.successor_dcell_ID = cell4.getID();

        // SET STARTING CELL
        dico.setStartingCellFromID(cell0.getID());

        dico.finishDicoCreation();

        return dico;
    }

    public static NPCDialogDico princess()
    {
        NPCDialogDico dico = new NPCDialogDico();

        // CREATE CELLS
        QBlock q0 = new QBlock("Help meeeeeeee!");
        DialogCell cell0 = new DialogCell(q0);
        dico.addDialogCell(cell0);

        QBlock q1 = new QBlock("Someone please help me !!");
        DialogCell cell1 = new DialogCell(q1);
        dico.addDialogCell(cell1);

        QBlock q2 = new QBlock("", DBlock.DBLOCK_EFFECTS.NEXT_CINEMATIC_STEP);
        DialogCell cell2 = new DialogCell(q2);
        dico.addDialogCell(cell2);

        // UPDATE LINKS
        cell0.defaultSuccessorID = cell1.getID();
        cell1.defaultSuccessorID = cell2.getID();

        // SET STARTING CELL
        dico.setStartingCellFromID(cell0.getID());

        dico.finishDicoCreation();

        return dico;
    }

    public static NPCDialogDico endgameBad()
    {
        NPCDialogDico dico = new NPCDialogDico();

        // CREATE CELLS
        QBlock q0 = new QBlock("Look at yourself! You're not a hero!");
        DialogCell cell0 = new DialogCell(q0);
        dico.addDialogCell(cell0);

        QBlock q1 = new QBlock("You made it.. but at what cost?");
        DialogCell cell1 = new DialogCell(q1);
        dico.addDialogCell(cell1);

        // UPDATE LINKS
        cell0.defaultSuccessorID = cell1.getID();

        // SET STARTING CELL
        dico.setStartingCellFromID(cell0.getID());

        dico.finishDicoCreation();

        return dico;
    }

    public static NPCDialogDico endgameGood()
    {
        NPCDialogDico dico = new NPCDialogDico();

        // CREATE CELLS
        QBlock q0 = new QBlock("I shall be yours as you prove your valor.");
        DialogCell cell0 = new DialogCell(q0);
        dico.addDialogCell(cell0);

        QBlock q1 = new QBlock("You're a valourous knight!");
        DialogCell cell1 = new DialogCell(q1);
        dico.addDialogCell(cell1);

        // UPDATE LINKS
        cell0.defaultSuccessorID = cell1.getID();

        // SET STARTING CELL
        dico.setStartingCellFromID(cell0.getID());

        dico.finishDicoCreation();

        return dico;
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
