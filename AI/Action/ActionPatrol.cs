using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Patrol" , fileName = "ActionPatrol")]
public class ActionPatrol : AiAction
{
    private Vector2 newDirection;

    public override void Act(StateController controller)
    {
        Patrol(controller);
    }
    private void Patrol(StateController controller)
    {
        newDirection = controller.path.CurrentPoint - controller.transform.position;
        newDirection = newDirection.normalized;

        controller.characterMovement.SetHorizontal(newDirection.x);
        controller.characterMovement.SetVertical(newDirection.y);
    }
}
