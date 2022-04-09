using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private AiState currentState;
    [SerializeField] private AiState remainState;

    public Transform Target { get; set; }
    public CharacterMovement characterMovement { get; set; }
    public CharacterWeapon characterWeapon { get; set; }
    public Path path { get; set; }

    private void Awake()
    {
        characterWeapon = GetComponent<CharacterWeapon>();
        characterMovement = GetComponent<CharacterMovement>();
        path = GetComponent<Path>();
    }
    private void Update()
    {
     //   Debug.Log(currentState + "currentstate");
        currentState.EvaluateState(this);
    }

    public void TransitionToState(AiState nextState)
    {
        if(nextState != remainState)
        {
            currentState = nextState;
        }
    }
    public void SetTarget(Transform target)
    {
        Target = target;
    }
}
