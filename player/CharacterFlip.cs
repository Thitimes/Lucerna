using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlip : CharacterComponent
{
    public enum FlipMode
    {
        MovementDirection,
        WeaponDirection
    }
    [SerializeField] private FlipMode flipmode = FlipMode.MovementDirection;
    [SerializeField] private float threshold = 0.1f;

    public bool FacingRight { get; set; }

    private void Awake()
    {
        FacingRight = true;
    }
        
    // Start is called before the first frame update
    protected override void HandleAbility()
    {
        base.HandleAbility(); 
        if(flipmode == FlipMode.MovementDirection)
        {
            FlipToMoveDirection();
        }
        else
        {
            FlipToWeaponDirection();
        }
    }

    private void FlipToMoveDirection()
    {
        if(controller.CurrentMovement.normalized.magnitude > threshold)
        {
            if(controller.CurrentMovement.normalized.x > 0)
            {
                FaceDirection(1);
            }
            else
            {
                FaceDirection(-1);
            }
        }
    }
    private void FlipToWeaponDirection()
    {
        if(characterWeapon != null)
        {
           
            float weaponAngle = characterWeapon.weaponAim.currentAimAngleAbsolute;
            if (character.getCharType() == Character.CharacterTypes.AI)
            {
               // Debug.Log("Angle" + weaponAngle);
            }
            if (weaponAngle > 90 || weaponAngle < -90)
            {
                FaceDirection(-1);
            }
            else
            {
                FaceDirection(1);
            }
        }
    }
    private void FaceDirection(int newDirection)
    {
        if(newDirection == 1)
        {
           character.CharacterSprite.transform.localScale = new Vector3(1, 1, 1);
            FacingRight = true;
        }
        else
        {
            character.CharacterSprite.transform.localScale = new Vector3(-1, 1, 1);
            FacingRight = false;
        }
    }
}
