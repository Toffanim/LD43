using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCType
{

    string  typeName { get; }
    NPC     attachedNPC { get; set; }
    bool    isActive { get; }

    void action();
    void action2();
    void exit();
    void notifyPlayerPresence(PlayerController pc);
    void notifyPlayerLeaving(PlayerController pc);

}
