using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Follow", fileName = "ActionFollow")]
public class ActionFollow : AiAction
{
    public float minDistanceToFollow = 1f;

    public override void Act(StateController controller)
    {
        FollowTarget(controller);
    }

    private void FollowTarget(StateController controller)
    {
        if (controller.Target == null)
        {
            return;
        }

        // Follow Horizontal
        if (controller.transform.position.x < controller.Target.position.x)
        {
            controller.characterMovement.SetHorizontal(1);
        }
        else
        {
            controller.characterMovement.SetHorizontal(-1);
        }

        // Follow Vertical
        if (controller.transform.position.y < controller.Target.position.y)
        {
            controller.characterMovement.SetVertical(1);
        }
        else
        {
            controller.characterMovement.SetVertical(-1);
        }

        // Stop if min distance reached (Horizontal)
        if (Mathf.Abs(controller.transform.position.x - controller.Target.position.x) < minDistanceToFollow)
        {
            controller.characterMovement.SetHorizontal(0);
        }

        // Stop if min distance reached (Vertical)
        if (Mathf.Abs(controller.transform.position.y - controller.Target.position.y) < minDistanceToFollow)
        {
            controller.characterMovement.SetVertical(0);
        }
    }
}
