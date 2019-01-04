using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DialogController : MonoBehaviour
{
    // ATTRS
    public NPCDialogDico npcDialogDico { get; set; }
    public DialogCell activeDCell { get; set; }

    public DialogController(int iDialogID)
    {
        init(iDialogID);
    }
    public void init(int iDialogID)
    {
        NPCDialogDico loadDico = null;
        DialogBank.loadDicoFromID(iDialogID, out loadDico);
        npcDialogDico = loadDico;

        if (null == npcDialogDico)
            Debug.Log("wtf ? " + iDialogID);
        else
            activeDCell = npcDialogDico.startingCell;
    }

    public void changeResponse()
    {
        if (activeDCell!=null)
            activeDCell.changeActiveAnswer();
    }

    public void resetDialog()
    {
        activeDCell = npcDialogDico.startingCell;
    }

    public string getMessage()
    {

        string s = (activeDCell!=null) ? activeDCell.question.getMessage() : "no active dialog cell";
        return (s!=null)?s:"not found";
    }

    public string getSelectedAnswer()
    {
        if (activeDCell != null)
        {
            ABlock answer = activeDCell.getSelectedAnswer();
            if (answer != null)
            {
                string s = answer.getMessage();
                return (s != null) ? s : "not found";
            }
        }
        return "no answer found";
    }

    public DBlock.DBLOCK_EFFECTS getQuestionBlockEffect()
    {
        return (activeDCell != null ) ? activeDCell.question.blockEffect : DBlock.DBLOCK_EFFECTS.NOTHING;
    }
    public DBlock.DBLOCK_EFFECTS getResponseBlockEffect()
    {
        return (activeDCell != null) ? activeDCell.selectedAnswer.blockEffect : DBlock.DBLOCK_EFFECTS.NOTHING;
    }


    public List<string> getChoices()
    {
        List<string> choices = new List<string>();
        foreach (ABlock answer in activeDCell.answers)
            choices.Add(answer.getMessage());
        return choices;
    }
	
    public bool tryPursueDialog()
    {
        bool rc = true;
        if (activeDCell == null)
            rc = false;
        else if (activeDCell.isFinalBlock())
            rc = false;
        else 
        {
            DialogCell cellCopy = activeDCell;
            activeDCell = npcDialogDico.getNextDialogCellFromCurrentDCell(cellCopy);
            rc = (activeDCell != null);
        }
        return rc;
    }

    // UNITY
    void Start()
    {
    }

    void Update()
    {

    }
}
