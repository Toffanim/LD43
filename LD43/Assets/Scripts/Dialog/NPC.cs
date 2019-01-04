using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    // SETTABLE
    public int dialogID ;
    public bool resetDialog = true;
    public GameObject guardedDoor;
    public GameObject dialogUI;
    public GameObject relatedCinematic;

    // PU INTERNAL ATTR
    public DialogController dialogController { get; set; }
    public bool dialogStarted = false;
    public PlayerController capturedPlayerControlled { get; set; }

    // PV ATTR
    private UIDialogController uiDialogController;

    // CTOR
    public NPC( int iDialogRootId)
    {
        dialogID = iDialogRootId;
        //npcDialog = new DialogController(dialogID);
        gameObject.AddComponent<DialogController>();
        dialogController = GetComponent<DialogController>();
        dialogController.init(iDialogRootId);

        if (!!dialogUI)
            uiDialogController = dialogUI.GetComponentInChildren<UIDialogController>(true);

        dialogStarted = false;
    }

    // UNITY START
    void Start()
    {
        gameObject.AddComponent<DialogController>();
        dialogController = GetComponent<DialogController>();
        dialogController.init(dialogID);

        if (!!dialogUI)
        { 
            uiDialogController = dialogUI.GetComponentInChildren<UIDialogController>(true);

            dialogStarted = false;
        }
    }

    // UNITY UPDATE
    void Update () {
    }

    public void loadNewDialog(int iNewDialogID)
    {
        dialogID = iNewDialogID;
        dialogController = new DialogController(dialogID);
    }

    public void dialog()
    {
        //RESOLVE EFFECT OF THE NEW MESSAGE
        if (!!capturedPlayerControlled)
        {
            bool tryDialog = false;
            if (!dialogStarted)
            {
                if (dialogController != null)
                {
                    uiDialogController = dialogUI.GetComponentInChildren<UIDialogController>(true);
                    string newMessage = dialogController.getMessage();
                    if ((newMessage != null)&& (uiDialogController != null))
                    {
                        uiDialogController.message = newMessage;
                        if (!!uiDialogController)
                            uiDialogController.show(true);
                        dialogStarted = true;
                        tryDialog = true;
                    }
                }
            }
            else
            {
                if (dialogController != null)
                {
                    tryDialog = dialogController.tryPursueDialog();
                    if (!tryDialog)
                        exitDialog(); 
                    else // PURSUE DIALOG
                    {
                        string newMessage = dialogController.getMessage();
                        if ((newMessage != null) && (uiDialogController != null))
                        {
                            uiDialogController.message = newMessage;
                        }
                    
                    }
                }
            }
            if (dialogController!=null && uiDialogController!=null)
                uiDialogController.response = dialogController.getSelectedAnswer();

            // MUTILATE PLAYER
            PlayerState ps = capturedPlayerControlled.GetComponent<PlayerState>();
            if (!!ps && tryDialog)
            {
                DBlock.DBLOCK_EFFECTS q_effect = dialogController.getQuestionBlockEffect();
                DBlock.DBLOCK_EFFECTS a_effect = dialogController.getResponseBlockEffect();

                bool playerMutilated = ps.mutilate(q_effect) || ps.mutilate(a_effect) ;

                if (!!guardedDoor && !!playerMutilated)
                {
                    MagicDoorController mgc = guardedDoor.GetComponent<MagicDoorController>();
                    if (!!mgc)
                    { mgc.open(); disappear(); }

                }

                // CHECK FOR A NEXT CINEMATIC STEP
                if ( (q_effect == DBlock.DBLOCK_EFFECTS.NEXT_CINEMATIC_STEP) || (a_effect == DBlock.DBLOCK_EFFECTS.NEXT_CINEMATIC_STEP) )
                {
                    Cinematic c = GetComponent<Cinematic>();
                    if (!!c)
                    {
                        Debug.Log("NEXT CINEMATIC STAGE");
                        c.playCinematic();
                    }
                }
            }//ps && tryPlayer
        }//! captured player

    }//! dialog

    public void changeResponse()
    {
        if (dialogController!=null)
            dialogController.changeResponse();
        uiDialogController.response = dialogController.getSelectedAnswer();
    }

    public void exitDialog()
    {
        GameObject go = GameObject.Find("dialogGO");
        if (!!go)
            uiDialogController = go.GetComponentInChildren<UIDialogController>();
        if (uiDialogController != null && dialogUI!=null)
            uiDialogController.show(false);
        dialogStarted = false;
        if (!!resetDialog)
            dialogController.resetDialog();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
            capturedPlayerControlled = pc;
            pc.npcInRange = this;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
            capturedPlayerControlled = pc;
            pc.npcInRange = this;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
            capturedPlayerControlled = null;
            pc.npcInRange = null;
        }
        exitDialog();
    }

    void disappear()
    {
        Destroy(this);
    }
}
