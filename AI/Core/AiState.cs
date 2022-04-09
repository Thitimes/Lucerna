using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/State")]
public class AiState : ScriptableObject
{
    public AiAction[] Actions;
    public AiTransition[] Transitions;

    public void EvaluateState(StateController controller)
    {
        
        DoActions(controller);
        EvaluateTransition(controller);
    } 
    public void DoActions(StateController controller)
    {
        foreach (AiAction action in Actions)
        {
            action.Act(controller);
        }
    }
    public void EvaluateTransition(StateController controller)
    {
        if(Transitions != null || Transitions.Length > 1) 
        {
            for (int i = 0; i < Transitions.Length; i++)
            {
                bool decisionResult = Transitions[i].Decision.Decide(controller);
                if (decisionResult)
                {
                    controller.TransitionToState(Transitions[i].TrueState);

                }
                else
                {
                    controller.TransitionToState(Transitions[i].FalseState);
                }
                        
            }

        }
    }
}
