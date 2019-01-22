using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCell
{
    private string DCELL_UID;
    public string getID() { return DCELL_UID; }

    public string defaultSuccessorID { get; set; }

    public QBlock question { get; set; }

    public ABlock selectedAnswer { get; set; }
    public List<ABlock> answers { get; set; }
    private int selectedAnswerIndex;

    //CTOR
    public DialogCell(QBlock iCellDialog) : base()
    {
        question = iCellDialog;
        answers = new List<ABlock>();
        DCELL_UID = System.Guid.NewGuid().ToString();
        defaultSuccessorID = "";
        selectedAnswerIndex = 0;
    }

    public DialogCell(QBlock iCellDialog, string iDefaultSuccessorID)
    {
        question = iCellDialog;
        answers = new List<ABlock>();
        DCELL_UID = System.Guid.NewGuid().ToString();
        defaultSuccessorID = iDefaultSuccessorID;
        selectedAnswerIndex = 0;
    }

    public ABlock getSelectedAnswer()
    {
        if (selectedAnswer != null)
            return selectedAnswer;
        else if ((selectedAnswer == null) && (answers.Count > 0))
        { changeActiveAnswer(); return selectedAnswer; }
        else
        { answers.Add(new ABlock()); return answers[0]; }
    }

    public void changeActiveAnswer()
    {
        selectedAnswerIndex++;
        if (selectedAnswerIndex >= answers.Count)
            selectedAnswerIndex = 0;
        selectedAnswer = answers[selectedAnswerIndex];
    }

    public bool isFinalBlock()
    {
        return (answers.Count <= 0) && (defaultSuccessorID.Length <= 0);
    }

    public void addAnswer(ABlock iABlock)
    {
        answers.Add(iABlock);
    }


}
