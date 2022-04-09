using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    [SerializeField] private GameObject reticlePrefabs;
    [SerializeField] private Transform bulletSpawnPoint;
    public float currentAimAngleAbsolute { get; set; }
    public float currentAimAngle { get; set; }
    private Camera maincamera;
    private GameObject reticle;
    private Weapon weapon;

    private Vector3 direction;
    private Vector3 mousePosition;
    private Vector3 reticlePosition;
    private Vector3 currentAim = Vector3.zero;
    private Vector3 currentAimAbsolute = Vector3.zero;
    private Quaternion initaialRotation;
    private Quaternion lookRotation;
    
    // Start is called before the first frame update
    
    void Start()
    {
        Cursor.visible = false;
        maincamera = Camera.main;
        weapon = GetComponent<Weapon>();
        reticle = Instantiate(reticlePrefabs);
        initaialRotation = transform.rotation;
    }

    // Update is called once per frame
   private void Update()
    {
        if (weapon.WeaponOwner.getCharType() == Character.CharacterTypes.Player)
        {
            getMousePosition();
        }
        else
        {
            EnemyAim();
        }
        moveReticle();
        rotateWeapon();
    }
        
    private void getMousePosition()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 5f;

        direction = maincamera.ScreenToWorldPoint(mousePosition);
        direction.z = transform.position.z;
        reticlePosition = direction;

        currentAimAbsolute = direction - transform.position;
        if (weapon.WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
        {
            currentAim = direction - transform.position;
        }
        else
        {
            currentAim = transform.position - direction;
        }
    }
    private void moveReticle()
    {
        if (weapon.WeaponOwner.getCharType() == Character.CharacterTypes.Player)
        {

            reticle.transform.rotation = Quaternion.identity;
            reticle.transform.position = reticlePosition;
        }

    }
    public void rotateWeapon()
    {
        if(currentAim != Vector3.zero && direction != Vector3.zero)
        {
            //get angle
            currentAimAngle = Mathf.Atan2(currentAim.y, currentAim.x) * Mathf.Rad2Deg;
            currentAimAngleAbsolute = Mathf.Atan2(currentAimAbsolute.y, currentAimAbsolute.x) * Mathf.Rad2Deg;
            // clamping our angle
            if (weapon.WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
            {
                currentAimAngle = Mathf.Clamp(currentAimAngle, -180, 180);
            }
            else
            {
                currentAimAngle = Mathf.Clamp(currentAimAngle, -180, 180);
            }
            //apply that angle
            lookRotation = Quaternion.Euler(currentAimAngle * Vector3.forward);
            transform.rotation = lookRotation;
        }
        else
        {
            currentAimAngle = 0f;
            transform.rotation = initaialRotation;
        }
    }
        
    public Transform GetBulletSpawnPoint()
    {
        return bulletSpawnPoint;
    }
    private void EnemyAim()
    {
        currentAimAbsolute = currentAim;
        currentAim = weapon.WeaponOwner.GetComponent<CharacterFlip>().FacingRight ? currentAim : -currentAim;
        direction = currentAim - transform.position;
    }
    public void SetAim(Vector2 newAim)
    {
        currentAim = newAim;
    }
}
