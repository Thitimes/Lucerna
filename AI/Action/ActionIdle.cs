using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(menuName = "AI/Action/Idle",fileName = "ActionIdle")]
public class ActionIdle : AiAction
{
    public override void Act(StateController controller)
    {
        controller.characterMovement.SetHorizontal(0);
        controller.characterMovement.SetVertical(0);
    }
}
