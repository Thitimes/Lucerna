using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterWeapon : CharacterComponent
{
    [Header("Weapon Settings")]
    [SerializeField] private Transform weaponHolderPosition;
    [SerializeField] private Weapon WeaponToUse;
    
    float timeLeft = 0.0f;
    float cooldown = 0.0f;
    [Header("Absorb Settings (Only for player)")]   
    [SerializeField] private BulletBag bulletBag;
    [SerializeField] private float skillDurations = 1.0f;
    //[SerializeField] private float cooldownDurations = 1.0f;
    private barrier barrierScript;
    private bool DurationEnd = false;
    private bool timerStarted = false;

    public float absorbMeterMax;
    [HideInInspector] public float currentAbsorbLevel;
    private bool drainInitiation;
    [SerializeField] private float initialDrainAmount;

    public float drainMultiplier, rechargeMultiplier;


    public Weapon CurrentWeapon { get; set; }
    public WeaponAim weaponAim { get; set; }
    public Shotgun Shotgun { get; set; }


    protected override void Start()
    {
        base.Start();
        EquipWeapon(WeaponToUse, weaponHolderPosition);
        if(character.getCharType() == Character.CharacterTypes.Player) 
        { 
        barrierScript = GameObject.FindObjectOfType(typeof(barrier)) as barrier;
        }

        currentAbsorbLevel = absorbMeterMax;
    }


    protected override void HandleInput()
    {
        if (character.getCharType() == Character.CharacterTypes.Player)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }

            if (Input.GetMouseButton(1))
            {
                if (!drainInitiation)
                {
                    currentAbsorbLevel -= initialDrainAmount;
                    drainInitiation = true;
                }

                barrierScript.ToggleOnCollider();
                currentAbsorbLevel -= Time.deltaTime * drainMultiplier;

                if (currentAbsorbLevel < 0)
                {
                    barrierScript.ToggleOffCollider();
                    currentAbsorbLevel = 0;
                }
            }
            else
            {
                drainInitiation = false;
                barrierScript.ToggleOffCollider();
                if (currentAbsorbLevel < absorbMeterMax)
                {
                    currentAbsorbLevel += Time.deltaTime * rechargeMultiplier;
                }
                else
                {
                    currentAbsorbLevel = absorbMeterMax;
                }
            }

            /*
            if (Input.GetMouseButtonDown(1) && cooldown <= 0)
            {
                cooldown = cooldownDurations;
                timeLeft = skillDurations;
                timerStarted = true;
                barrierScript.ToggleOnCollider();
            }
            if (timerStarted)
            {
                Countdownfunction();
            }
            if (timeLeft < 0)
            {
                //barrierScript.ToggleOffCollider();
            }
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;


            }
            */
            ChangeBullet();

        }
    }
    public void Shoot()
    {
        if(CurrentWeapon == null)
        {
            return;
        }
        Vector3 newDirection = new Vector3(Mathf.Cos(weaponAim.currentAimAngleAbsolute * Mathf.Deg2Rad), Mathf.Sin(weaponAim.currentAimAngleAbsolute * Mathf.Deg2Rad), 0);
        float angle = weaponAim.currentAimAngleAbsolute;
        bulletBag.ShootBullet(weaponAim.GetBulletSpawnPoint(), angle);
    }
    public void EquipWeapon(Weapon weapon, Transform weaponPosition)
    {
        CurrentWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
        CurrentWeapon.transform.parent = weaponPosition;
        CurrentWeapon.SetOwner(character);
        
        weaponAim = CurrentWeapon.GetComponent<WeaponAim>();
        Shotgun = CurrentWeapon.GetComponent<Shotgun>();
    }
    void Countdownfunction()
    {
        timeLeft -= Time.deltaTime;
    }
    void ChangeBullet()
    {
        for(int i = 0; i < 5; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1+i))
            {
                bulletBag.ChangeEquipBullet(i);
            }
        }
    }
}