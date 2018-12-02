using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    // SETTABLE
    public int dialogID ;
    public bool resetDialog = true;
    public GameObject guardedDoor;
    public GameObject dialogUI;

    // INTERNAL
    public Dialog npcDialog { get; set; }
    bool inRangeOfPlayer;
    public bool dialogStarted = false;

    //PV ATTR
    private PlayerController capturedPlayerControlled;
    private UIDialogController uiDialogController;

    public NPC( int iDialogRootId)
    {
        dialogID = iDialogRootId;
        npcDialog = new Dialog(dialogID);
        //dialogUI = GameObject.Find("dialogGO");
        if (!!dialogUI)
            uiDialogController = dialogUI.GetComponentInChildren<UIDialogController>(true);
       /* if ( !!uiDialogController)
            uiDialogController.show(false);*/
        dialogStarted = false;
    }
    // Use this for initialization
    void Start()
    {
        inRangeOfPlayer = false;
        npcDialog = new Dialog(dialogID);
        //dialogUI = GameObject.Find("dialogGO");
        if (!!dialogUI)
        { 
            uiDialogController = dialogUI.GetComponentInChildren<UIDialogController>(true);
            /*
            if ( !!uiDialogController)
                uiDialogController.show(false);
*/
            dialogStarted = false;
        }
    }

    // Update is called once per frame
    void Update () {
    }

    public void dialog()
    {
        if (!dialogStarted)
        {
            if (npcDialog != null)
            {
                uiDialogController = dialogUI.GetComponentInChildren<UIDialogController>(true);
                string newMessage = npcDialog.getMessage();
                if ((newMessage != null)&& (uiDialogController != null))
                {
                    uiDialogController.message = newMessage;
                    if (!!uiDialogController)
                        uiDialogController.show(true);
                    dialogStarted = true;
                }
            }
        }
        else
        {
            if (npcDialog != null)
            {
                bool tryDialog = npcDialog.tryPursueDialog();
                if (!tryDialog)
                    exitDialog(); 
                else // PURSUE DIALOG
                {
                    string newMessage = npcDialog.getMessage();
                    if ((newMessage != null) && (uiDialogController != null))
                    {
                        uiDialogController.message = newMessage;
                    }
                    
                }
            }
        }
        if (npcDialog!=null && uiDialogController!=null)
            uiDialogController.response = npcDialog.getResponseKey();

        //RESOLVE EFFECT OF THE NEW MESSAGE
        if (!!capturedPlayerControlled)
        {
            PlayerState ps = capturedPlayerControlled.GetComponent<PlayerState>();
            if (!!ps)
            {
                bool playerMutilated = ps.mutilate(npcDialog.getBlockEffect());
                if (!!guardedDoor && !!playerMutilated)
                {
                    MagicDoorController mgc = guardedDoor.GetComponent<MagicDoorController>();
                    if (!!mgc)
                    { mgc.open(); disappear(); }

                }
            }
        }

    }//! dialog

    public void changeResponse()
    {
        if (npcDialog!=null)
            npcDialog.changeResponse();
        uiDialogController.response = npcDialog.getResponseKey();
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
            npcDialog.resetDialog();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
            capturedPlayerControlled = pc;
            inRangeOfPlayer = true;
            pc.npcInRange = this;
            Debug.Log("IN");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
            capturedPlayerControlled = null;
            inRangeOfPlayer = false;
            pc.npcInRange = null;
            Debug.Log("OUT");
        }
        exitDialog();
    }

    void disappear()
    {
        Destroy(this);
    }
}
