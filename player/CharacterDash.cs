using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash : CharacterComponent
{
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashDuration = 0.5f;

    private bool isDashing;
    private float dashTimer;
    private Vector2 dashOrigin;
    private Vector2 dashDestination;
    private Vector2 newPosition;

    [Range (0,1f)] public float cooldown;
    private float cooldownTimer = 0;
    protected override void HandleInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Dash();
        }
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        if (isDashing)
        {
            if(dashTimer < dashDuration)
            {
                newPosition = Vector2.Lerp(dashOrigin, dashDestination, dashTimer / dashDuration);
                controller.MovePosition(newPosition);
                dashTimer += Time.deltaTime;

            }
            else
            {
                stopDash();
            }
        }
    }
    private void Dash()
    {
        if (cooldownTimer <= 0)
        {
            character.CharacterAnimator.SetBool("IsDash", true);
            isDashing = true;
            dashTimer = 0f;
            controller.normalMovement = false;
            dashOrigin = transform.position;

            dashDestination = transform.position + (Vector3)controller.CurrentMovement.normalized * dashDistance;

            cooldownTimer = cooldown;
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }

        
    }
    private void stopDash()
    {
        character.CharacterAnimator.SetBool("IsDash", false);
        isDashing = false;
        controller.normalMovement = true;

    }
}
