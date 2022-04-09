using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum CharacterTypes {
        Player,
        AI
    }

  [SerializeField] private CharacterTypes ChracterType;
  [SerializeField] private GameObject characterSprite;
  [SerializeField] private Animator characterAnimator;
    public GameObject CharacterSprite => characterSprite;
    public Animator CharacterAnimator => characterAnimator;
    public bool bossDead;

   public CharacterTypes getCharType()
    {
        return ChracterType;
    }
}
