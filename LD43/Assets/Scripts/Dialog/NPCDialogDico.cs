﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogDico : MonoBehaviour {

    public DialogCell startingCell { get; set; }
    public List<DialogCell> loadedCells { get; set; }


    //CTOR 
    public NPCDialogDico()
    {
        loadedCells = new List<DialogCell>();
    }

    public void addDialogCell(DialogCell iDCell)
    {
        if (loadedCells == null)
            loadedCells = new List<DialogCell>();
        loadedCells.Add(iDCell);
    }

    public void setStartingCellFromID(string iDCellID)
    {
        if (loadedCells!=null)
        {
            foreach (DialogCell dcell in loadedCells)
                if (dcell.getID() == iDCellID)
                    startingCell = dcell;
        }
    }

    public DialogCell getNextDialogCellFromCurrentDCell(DialogCell iDialogCell )
    {
        DialogCell nextCell = null;

        if (!!iDialogCell)
        {
            ABlock selectedAnswer = iDialogCell.selectedAnswer;
            string defaultSuccessorID = iDialogCell.defaultSuccessorID;
            string answerSuccessorID = ( selectedAnswer!=null ) ? selectedAnswer.successor_dcell_ID : "";
            string successorID = (answerSuccessorID.Length > 0) ? answerSuccessorID : defaultSuccessorID;

            Debug.Log(" SUCCESSOR ID " + successorID);

            if (successorID.Length <= 0) return null;

            foreach (DialogCell dcell in loadedCells )
            {    
                if ( dcell.getID() == successorID)
                {
                    nextCell = dcell;
                    break;
                }
            }//! foreach activeAnswer
           
        }
        return nextCell;
    }

    // CALL IT TO FILL UP GAPS IN GIVEN DCELLS 
    public void finishDicoCreation()
    {
        if (loadedCells == null)
            return;
        foreach( DialogCell dcell in loadedCells )
        {
            if ((dcell.answers == null) || (dcell.answers.Count==0))
            {
                dcell.answers = new List<ABlock>(1);
                dcell.answers.Add(new ABlock());
            }
        }//!foreach dcell
    }

    // UNITY
    void Start () {
        loadedCells = new List<DialogCell>();
    }

	void Update () {
		
	}
}
