using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogDico : MonoBehaviour {

    public List<QBlock> questions;
    private List<ABlock> answers;

    // PU METHODS
    public DBlock getNextDBlock( string iAnswer)
    {
        DBlock retblock = null;

        // Get corresponding ABlock
        ABlock answerBlock = null;
        foreach (ABlock a in answers)
            if (a.getMessage() == iAnswer)
            { answerBlock = a; break; }

        // Retrieve associated QBlock
        string wantedQuestion = answerBlock.getRelatedQuestion();
        foreach (QBlock q in questions)
            if ( q.getMessage() == wantedQuestion )
                { retblock = q; break; }

        return retblock;
    }


    // MANAGE DICO
    public void addQBlock( QBlock iBlock)
    {
        if (questions == null)
            questions = new List<QBlock>();
        questions.Add(iBlock);
    }
    public void buildAnswers()
    {
        foreach(QBlock question in questions)
        {
            foreach (string answer in question.successors)
                answers.Add(new ABlock(answer, question.getMessage()));
        }
    }

    // UNITY
    void Start () {
        questions   = new List<QBlock>();
        answers     = new List<ABlock>();
    }
	void Update () {
		
	}
}
