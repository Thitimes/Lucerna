using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGolemRun : StateMachineBehaviour
{
    private BossGolem bossGolem;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerIndex)
    {

        bossGolem = animator.GetComponent<BossGolem>();
        
    }
  

    // OnStateUpdate is called on each update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        
        bossGolem.Stage1();
        bossGolem.bossSlow();
    }

    // onstateexit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        
    }

}
