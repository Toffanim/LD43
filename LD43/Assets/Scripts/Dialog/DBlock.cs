using System.Collections.Generic;

public class DBlock {

    public enum     DBLOCK_EFFECTS  { NOTHING, LOSE_ARM, LOSE_LEG, LOSE_BODY, NEXT_CINEMATIC_STEP};
    public DBLOCK_EFFECTS blockEffect { get; set; }
    public string predecessor;
    public List<string> successors;

    // CTORS
    public DBlock(string iMessage, DBLOCK_EFFECTS iBlockEffect)
    {
        predecessor = iMessage;
        successors = new List<string>();
        blockEffect = iBlockEffect;
    }

    public DBlock(string iMessage)
    {
        predecessor = iMessage;
        successors = new List<string>();
        blockEffect = DBLOCK_EFFECTS.NOTHING;
    }

    public DBlock(string iQuestion, string iAnswer)
    {
        predecessor = iQuestion;
        successors = new List<string>();
        successors.Add(iAnswer);
        blockEffect = DBLOCK_EFFECTS.NOTHING;
    }

    public DBlock(string iQuestion, string iAnswer, DBLOCK_EFFECTS iBlockEffect)
    {
        predecessor = iQuestion;
        successors = new List<string>();
        successors.Add(iAnswer);
        blockEffect = iBlockEffect;
    }

    public DBlock(string iQuestion, List<string> iResponses)
    {
        predecessor = iQuestion;
        successors = iResponses;
        blockEffect = DBLOCK_EFFECTS.NOTHING;
    }

    public DBlock(string iQuestion, List<string> iResponses, DBLOCK_EFFECTS iBlockEffect)
    {
        predecessor = iQuestion;
        successors = iResponses;
        blockEffect = iBlockEffect;
    }

    // VIRTUAL
    public virtual string getMessage() { return predecessor; }

    // UTILS
    public bool isFinalBlock()
    {
        return ((successors == null) || (successors.Count == 0));
    }
}
