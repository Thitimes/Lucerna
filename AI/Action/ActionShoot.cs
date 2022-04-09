using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "AI/Action/Shoot", fileName = "ActionShoot")]
public class ActionShoot : AiAction
{
    [Header("Bullet To Shoot")]
    [SerializeField] private Bullet bulletToShoot;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float fireRate = 3f;
    private float angleToPlayer;
    private float nextFire;
    private Vector3 directionToPlayer;
    private Bullet newBullet;
    private Vector2 aimDirection;
    void Start()
    {
        nextFire = Time.time;
        bulletToShoot.isMoving = true;
    }
    public override void Act(StateController controller)
    {
        DeterminateAim(controller);
        ShootPlayer(controller);
    }
    private void ShootPlayer(StateController controller)
    {
        //stop enemy
        controller.characterMovement.SetHorizontal(0);
        controller.characterMovement.SetVertical(0);

        //Shoot
        if(controller.characterWeapon != null)
        {
            controller.characterWeapon.weaponAim.SetAim(aimDirection);
            controller.characterWeapon.weaponAim.rotateWeapon();
            controller.characterWeapon.Shotgun.shoot();
        }
    }
    private void DeterminateAim(StateController controller)
    {
        
        aimDirection = controller.Target.position - controller.transform.position;
        
    }
        
}