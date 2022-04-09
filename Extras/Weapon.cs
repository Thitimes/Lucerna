using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public Character WeaponOwner { get; set; }
    void Update()
    {
        rotateWeapon();

    }
    public void TriggerShoot()
    {
        Debug.Log("TriggerShooting");
    }
    private void StartShooting()
    {

    }
    public void SetOwner(Character owner)
    {
        WeaponOwner = owner;
        
    }
   private void rotateWeapon()
    {
     
        if (WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
