using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IMPORTANT (MTN5): Taken/inspired from Unity GameKit 2D

public class PlayerInput : InputComponent {  //MonoBehavior through InputComponent

    public InputButton Pause = new InputButton(KeyCode.Escape, XboxControllerButtons.Menu);
    public InputButton Interact = new InputButton(KeyCode.E, XboxControllerButtons.Y);
    public InputButton MeleeAttack = new InputButton(KeyCode.K, XboxControllerButtons.X);
    public InputButton RangedAttack = new InputButton(KeyCode.O, XboxControllerButtons.B);
    public InputButton Jump = new InputButton(KeyCode.Space, XboxControllerButtons.A);
    public InputAxis Horizontal = new InputAxis(KeyCode.Q, KeyCode.A, XboxControllerAxes.LeftstickHorizontal);
    public InputAxis Vertical = new InputAxis(KeyCode.Z, KeyCode.S, XboxControllerAxes.LeftstickVertical);

    protected bool m_HaveControl = true;

    protected override void GetInputs(bool fixedUpdateHappened)
    {
        Pause.Get(fixedUpdateHappened, inputType);
        Interact.Get(fixedUpdateHappened, inputType);
        MeleeAttack.Get(fixedUpdateHappened, inputType);
        RangedAttack.Get(fixedUpdateHappened, inputType);
        Jump.Get(fixedUpdateHappened, inputType);
        Horizontal.Get(inputType);
        Vertical.Get(inputType);
    }

    public override void GainControl()
    {
        m_HaveControl = true;

        GainControl(Pause);
        GainControl(Interact);
        GainControl(MeleeAttack);
        GainControl(RangedAttack);
        GainControl(Jump);
        GainControl(Horizontal);
        GainControl(Vertical);
    }

    public override void ReleaseControl(bool resetValues = true)
    {
        m_HaveControl = false;

        ReleaseControl(Pause, resetValues);
        ReleaseControl(Interact, resetValues);
        ReleaseControl(MeleeAttack, resetValues);
        ReleaseControl(RangedAttack, resetValues);
        ReleaseControl(Jump, resetValues);
        ReleaseControl(Horizontal, resetValues);
        ReleaseControl(Vertical, resetValues);
    }
}
