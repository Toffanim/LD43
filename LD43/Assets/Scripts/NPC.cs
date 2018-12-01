using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    // SETTABLE
    public int dialogID = 2;
    public bool resetDialog = true;
    // INTERNAL
    public Dialog npcDialog { get; set; }
    bool inRangeOfPlayer;

    //PV ATTR
    private GameObject dialogUI;
    private UIDialogController uiDialogController;
    private bool __startDialog = false;

    public NPC( int iDialogRootId)
    {
        dialogID = iDialogRootId;
        npcDialog = new Dialog(dialogID);
        dialogUI = GameObject.Find("dialogGO");
        if (!!dialogUI)
            uiDialogController = dialogUI.GetComponentInChildren<UIDialogController>();
        dialogUI.SetActive(false);
        __startDialog = false;
    }
    // Use this for initialization
    void Start () {
        inRangeOfPlayer = false;
        npcDialog = new Dialog(dialogID);
        dialogUI = GameObject.Find("dialogGO");
        if (!!dialogUI)
            uiDialogController = dialogUI.GetComponentInChildren<UIDialogController>();
        dialogUI.SetActive(false);
        __startDialog = false;
    }

    // Update is called once per frame
    void Update () {
    }

    public void dialog()
    {
        if (!__startDialog)
        {
            if ((uiDialogController != null) && (npcDialog != null))
            {
                string newMessage = npcDialog.getMessage();
                if (newMessage != null)
                {
                    uiDialogController.message = newMessage;
                }
                dialogUI.SetActive(true);
                __startDialog = true;
            }
        }
        else
        {
            if (npcDialog != null)
            {
                bool tryDialog = npcDialog.tryPursueDialog(null);
                if (!tryDialog)
                    exitDialog(); 
                else
                {
                    string newMessage = npcDialog.getMessage();
                    if (newMessage != null)
                    {
                        uiDialogController.message = newMessage;
                    }
                }
            }
        }

    }//! dialog

    public void exitDialog()
    {
        GameObject go = GameObject.Find("dialogGO");
        if (!!go)
            uiDialogController = go.GetComponentInChildren<UIDialogController>();
        if (uiDialogController != null)
            dialogUI.SetActive(false);
        __startDialog = false;
        if (!!resetDialog)
            npcDialog.resetDialog();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
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
            inRangeOfPlayer = false;
            pc.npcInRange = null;
            Debug.Log("OUT");
        }
        exitDialog();
    }
}
