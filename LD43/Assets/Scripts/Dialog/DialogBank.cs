using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBank {

    public const int ERROR_CODE = -1;
    public const string MONO_DIALOG = "mono";

    public static DBlock getDialogStartFromId(int iID)
    {
        DBlock retBlock = null;
        switch (iID)
        {
            case 1:
                Dictionary<string, DBlock> dico = new Dictionary<string, DBlock>();
                retBlock = new DBlock("HELLO THERE LIL NITE", dico );
                break;
            case 2:
                retBlock = testBank();
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

    public static DBlock testBank()
    {
        DBlock retBlock = null;
        Dictionary<string, DBlock> dicoA = new Dictionary<string, DBlock>();
        dicoA.Add( MONO_DIALOG, new DBlock("GOOD LUCK !"));
        retBlock = new DBlock("ALLLLPPNZY", dicoA);

        //retBlock = new DBlock("HELLO THERE LIL NITE", dico);
        //retBlock = new DBlock("HELLO THERE LIL NITE", dico);

        return retBlock;

    }

    public static DBlock getErrorBlock()
    {
        DBlock retval = DialogBank.getDialogStartFromId(ERROR_CODE);
        return retval;
    }
}
