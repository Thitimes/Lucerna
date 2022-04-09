using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemy : MonoBehaviour
{
    [Header("Bullet To Shoot")]
    [SerializeField] private Bullet bulletToShoot;
    [SerializeField] private Transform bulletSpawnPoint;
    [Header("Fire")]
    [SerializeField] private float fireRate = 3f;
    [SerializeField] private float fireDistance = 5f;
    [Header("Flip")]
    [SerializeField] private bool IsFlipSprite = false;
    private float nextFire;
    private GameObject player;
    private float angleToPlayer;
    private Vector3 directionToPlayer;
    private Bullet newBullet;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nextFire = Time.time;
        bulletToShoot.isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerDistance();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {

            newBullet = Instantiate(bulletToShoot, bulletSpawnPoint.position, Quaternion.identity).GetComponent<Bullet>();
            directionToPlayer = (player.transform.position - bulletSpawnPoint.position).normalized;
            angleToPlayer = Vector3.Angle(directionToPlayer, bulletSpawnPoint.right);
            if (!IsFlipSprite)
            {
                newBullet.SetBulletRotation(-angleToPlayer);
            }
            else
            {
                newBullet.SetBulletRotation(angleToPlayer);
            }

            nextFire = Time.time + fireRate;


        }
    }
    void checkPlayerDistance()
    {
        Vector3 playerDistance = (this.transform.position - player.transform.position);
        playerDistance.z = 0;
        if (playerDistance.magnitude < fireDistance)
        {
            CheckIfTimeToFire();
        }
    }//Test for sourcetree n00b
}
