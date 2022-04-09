using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterComponent
{
    [SerializeField] private float walkSpeed = 6f;
    public float MoveSpeed { get; set; }
    public bool IsSlow = false;
    private readonly int movingParameter = Animator.StringToHash("IsWalk");

    protected override void Start()
    {
        base.Start();
        MoveSpeed = walkSpeed;
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        MoveCharacter();
        UpdateAnimations();
    }
    private void MoveCharacter()
    {
        if(IsSlow == true)
        {
            StartCoroutine(getSlow());
            
        }
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        Vector2 moveInput = movement;
        Vector2 movementNormalized = movement.normalized;
        Vector2 movementSpeed = movementNormalized * MoveSpeed;
        controller.SetMovement(movementSpeed);
    }
    private void UpdateAnimations()
    {
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            if (character.CharacterAnimator != null && character.getCharType() == Character.CharacterTypes.Player)
            {
                character.CharacterAnimator.SetBool(movingParameter, true);
            }
        }
        else
        {
            if (character.CharacterAnimator != null && character.getCharType() == Character.CharacterTypes.Player)
            {
                character.CharacterAnimator.SetBool(movingParameter, false);
            }
        
        }
    }
    public void ResetSpeed()
    {
        MoveSpeed = walkSpeed;
    }
    public void SetHorizontal(float value)
    {
        horizontalInput = value;
    }
    public void SetVertical(float value)
    {
        verticalInput = value;
    }
    public void SlowDown()
    {
        MoveSpeed = walkSpeed / 2;
    }
    
    IEnumerator getSlow()
    {
        SlowDown();
        yield return new WaitForSeconds(1.0f);
        ResetSpeed();
        IsSlow = false;
    }
}
