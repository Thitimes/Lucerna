using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[Serializable]
public class AiTransition
{
    public AiDecision Decision;
    public AiState TrueState;
    public AiState FalseState;
}
