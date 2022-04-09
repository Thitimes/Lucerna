using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Detect Target", fileName = "DecisionDetect")]
public class DecisionDetect : AiDecision
{
    public float detectArea = 3f;
    public LayerMask targetMask;
    private Collider2D Targetcollider2D;
    public override bool Decide(StateController controller)
    {
        return CheckTarget(controller);
    }
    private bool CheckTarget(StateController controller)
    {
       
        Targetcollider2D = Physics2D.OverlapCircle(controller.transform.position,detectArea,targetMask);
        if(Targetcollider2D != null)
        {
            Debug.Log(controller.Target + "controller");
            controller.Target = Targetcollider2D.transform;
            return true;
        }
        return false;
    }
   
}
