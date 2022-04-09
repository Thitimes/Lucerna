using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBag : MonoBehaviour
{

    public class BulletInfo
    {
        public Bullet bullet;
        public int amount = 0;
        public bool IsInSlot = false;

        public BulletInfo(Bullet bullet, int amount, bool isInSlot)
        {
            this.bullet = bullet;
            this.amount = amount;
            IsInSlot = isInSlot;
        }
    }

    ///// <summary>
    ///// key is bullet id
    ///// value is all BulletInfo
    ///// </summary>
    ///
    public Dictionary<string, BulletInfo> bulletsInfo;

    private WeaponAim weaponAim;
    private Bullet equippingBullet;
    [SerializeField] private Transform bulletSpawnPoint;

    private Bullet tempBullet;

    // Start is called before the first frame update
    void Start()
    {
        weaponAim = GetComponent<WeaponAim>();
        bulletsInfo = new Dictionary<string, BulletInfo>();
    }



    public void KeepBullet(Bullet b)
    {

        if (!bulletsInfo.ContainsKey(b.id))
        {
            
            tempBullet = Instantiate(b, new Vector3(1000, 1000, 0), transform.rotation);
            tempBullet.tag = "PlayerBullet";
            tempBullet.isMoving = false;
            // TODO IsInSlot value = Is slot avaliable
            bulletsInfo.Add(b.id, new BulletInfo(tempBullet, 0, true));
        }
        else
        {
            tempBullet = bulletsInfo[b.id].bullet;
        }

        if (equippingBullet == null)
        {
            equippingBullet = tempBullet;
        }

        AddBulletCount(b);
        AddBulletCount(b);
        //AddBulletCount(b);
    }

    private void AddBulletCount(Bullet b)
    {
        bulletsInfo[b.id].amount += 1;
    }



    public void ShootBullet(Transform spawnPoint ,float rotation)

    {
       
        if (equippingBullet && bulletsInfo.ContainsKey(equippingBullet.id) && bulletsInfo[equippingBullet.id].amount > 0)
        {
            equippingBullet.isMoving = true;
            Bullet bullet = Instantiate(equippingBullet, spawnPoint.transform.position, Quaternion.identity).GetComponent<Bullet>();
            bullet.SetBulletRotation(rotation);
            
            // Vector3 newDirection = direction;
            // bullet.SetDirection(newDirection, rotation, gameObject.GetComponentInParent<CharacterFlip>().FacingRight);
            bulletsInfo[equippingBullet.id].amount -= 1;
            
        }
    }

    public void ChangeEquipBullet(int i)
    {
        // TODO check exceeding 
        int index = 0;
        foreach (string bulletId in bulletsInfo.Keys)
        {
            if (i == index)
            {
                equippingBullet = bulletsInfo[bulletId].bullet;
            }
            index += 1;
        }
    }
    
 
  }
