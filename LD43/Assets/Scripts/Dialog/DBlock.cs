using System.Collections.Generic;

public class DBlock {

    public enum     DBLOCK_EFFECTS  { NOTHING, LOSE_ARM, LOSE_LEG, LOSE_BODY, NEXT_CINEMATIC_STEP};
    public DBLOCK_EFFECTS blockEffect { get; set; }

    protected string message;

    // CTORS
    public DBlock(string iMessage, DBLOCK_EFFECTS iBlockEffect)
    {
        message = iMessage;
        blockEffect = iBlockEffect;
    }

    public DBlock(string iMessage)
    {
        message = iMessage;
        blockEffect = DBLOCK_EFFECTS.NOTHING;
    }

    // VIRTUAL
    public virtual string getMessage() { return message; }
    
}
