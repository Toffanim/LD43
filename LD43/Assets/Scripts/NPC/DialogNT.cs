using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNT : MonoBehaviour, INPCType {

    // INPCType ATTR
    public string typeName { get { return NPCTypeNames.dialog; } }
    public NPC attachedNPC { get { return _attachedNPC; } set { _attachedNPC = value; } }
    public bool isActive { get { return _isActive; } }

    protected bool _isActive;
    protected NPC _attachedNPC;

    // SETTABLE
    public int dialogID;
    public bool resetDialog = true;
    public GameObject dialogUI;

    // DialogNT ATTR
    public DialogController dialogController { get; set; }
    public bool dialogStarted = false;
    public PlayerController capturedPlayerControlled { get; set; }

    // PV ATTR
    private UIDialogController uiDialogController;

    // CTOR
    public void Init(NPC iAttachedNPC, GameObject iDialogUI, int iDialogRootId)
    {
        _attachedNPC = iAttachedNPC;
        dialogID = iDialogRootId;
        //npcDialog = new DialogController(dialogID);
        _attachedNPC.gameObject.AddComponent<DialogController>();
        dialogController = _attachedNPC.GetComponent<DialogController>();
        dialogController.init(iDialogRootId);

        dialogUI = iDialogUI;
        if (!!dialogUI)
            uiDialogController = dialogUI.GetComponentInChildren<UIDialogController>(true);

        dialogStarted = false;
    }

    // UNITY START
    void Start()
    {/*
        _attachedNPC.gameObject.AddComponent<DialogController>();
        dialogController = _attachedNPC.GetComponent<DialogController>();
        dialogController.init(dialogID);

        if (!!dialogUI)
        { 
            uiDialogController = dialogUI.GetComponentInChildren<UIDialogController>(true);

            dialogStarted = false;
        }
        */
    }

    // UNITY UPDATE
    void Update() {
    }

    public void loadNewDialog(int iNewDialogID)
    {
        dialogID = iNewDialogID;
        dialogController = new DialogController(dialogID);
    }

    // NPCTYPE
    // =======================================================
    public void action()
    {
        dialog(); _isActive = true;
        PlayerState ps = capturedPlayerControlled.GetComponent<PlayerState>();
        if (!!ps)
            ps.IsTalking = true;

    }

    public void action2()
    {
        changeResponse();
    }

    public void exit()
    {
        if (!!capturedPlayerControlled)
        {
            PlayerState ps = capturedPlayerControlled.GetComponent<PlayerState>();
            if (!!ps)
                ps.IsTalking = false;
        }
        exitDialog();
    }

    public void notifyPlayerPresence(PlayerController pc)
    {
        capturedPlayerControlled = pc;

    }

    public void notifyPlayerLeaving(PlayerController pc)
    {
        exit();
    }

    // DIALOG NT METHODS
    // =======================================================
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

                if (!!playerMutilated)
                {
                    List<INPCType> doorguards = _attachedNPC.getINTRefs(NPCTypeNames.doorguard);
                    foreach (INPCType doorguard in doorguards)
                    { doorguard.action2(); doorguard.action(); }
                }

                // CHECK FOR A NEXT CINEMATIC STEP
                if ( (q_effect == DBlock.DBLOCK_EFFECTS.NEXT_CINEMATIC_STEP) || (a_effect == DBlock.DBLOCK_EFFECTS.NEXT_CINEMATIC_STEP) )
                {
                    List<INPCType> cinematics = _attachedNPC.getINTRefs(NPCTypeNames.cinematic);
                    foreach (INPCType c in cinematics)
                    { c.action();  }
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

}
