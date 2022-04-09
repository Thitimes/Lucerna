using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    protected float horizontalInput;
    protected float verticalInput;

    protected CharacterControl controller;
    protected CharacterMovement characterMovement;
    protected Animator animator;
    protected Character character;
    protected CharacterWeapon characterWeapon;
    protected virtual void Start()
    {
        controller = GetComponent<CharacterControl>();
        characterMovement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();
        characterWeapon = GetComponent<CharacterWeapon>();
        character = GetComponent<Character>();

    }
    protected virtual void Update()
    {
        HandleAbility();
    }


    protected virtual void HandleAbility()
    {
        InternalInput();
        HandleInput();
    }
    protected virtual void HandleInput()
    {

    }
    protected virtual void InternalInput()
    {
        if (character.getCharType() == Character.CharacterTypes.Player)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }
    }
}
