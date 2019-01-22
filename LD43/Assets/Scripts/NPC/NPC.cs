using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public List<INPCType> INTList { get; set; }
    public PlayerController capturedPlayerControlled { get; set; }

    // NPC TYPES
    // =======================================================
    public void interactAll()
    {
        foreach (INPCType nt in INTList)
            nt.action();
    }
    public void interactAll2()
    {
        foreach (INPCType nt in INTList)
            nt.action2();
    }

    public void interactWithType(string iNPCTypeName)
    { 
        foreach (INPCType nt in INTList)
            if (nt.typeName == iNPCTypeName)
                nt.action();
    }
    public void interactWithType2(string iNPCTypeName)
    {
        foreach (INPCType nt in INTList)
            if (nt.typeName == iNPCTypeName)
                nt.action2();
    }


    public void exitAll()
    {
        foreach (INPCType nt in INTList)
            nt.exit();
    }

    public void exitType(string iNPCTypeName)
    {
        foreach (INPCType nt in INTList)
            if (nt.typeName == iNPCTypeName)
                nt.exit();
    }

    public List<INPCType> getINTRefs(string iNPCTypeName)
    {
        List<INPCType> ntList = new List<INPCType>();
        foreach (INPCType nt in INTList)
            if (nt.typeName == iNPCTypeName)
                ntList.Add((INPCType)nt);
        return ntList;
    }

    private void notifyPlayerPresenceToAll(PlayerController pc)
    {
        List<INPCType> ntList = new List<INPCType>();
        foreach (INPCType nt in INTList)
            nt.notifyPlayerPresence(pc);
    }

    private void notifyPlayerLeavingToAll(PlayerController pc)
    {
        List<INPCType> ntList = new List<INPCType>();
        foreach (INPCType nt in INTList)
            nt.notifyPlayerLeaving(pc);
    }
    // UNITY
    // =======================================================

    void Start()
    {
        INTList = new List<INPCType>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
            capturedPlayerControlled = pc;
            notifyPlayerPresenceToAll(capturedPlayerControlled);
            pc.npcInRange = this;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
            capturedPlayerControlled = pc;
            notifyPlayerPresenceToAll(capturedPlayerControlled);
            pc.npcInRange = this;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
            if (!!pc)
            {
                notifyPlayerLeavingToAll(capturedPlayerControlled);
                capturedPlayerControlled = null;
                pc.npcInRange = null;
                exitAll();
            }
    }

    public void disappear()
    {
        Destroy(this);
    }
}
