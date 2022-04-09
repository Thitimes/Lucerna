using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGolem : MonsterBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    [SerializeField]
    private GameObject firebullet;

    [SerializeField]
    private GameObject homingBullet;

    [SerializeField] 
    private SpriteRenderer bossSprite;

    private Transform player;
    Rigidbody2D rb;
    private Vector2 bulletMoveDirection;
    private float radian;
    private float shootAngle;
    private float angle = 0f;
    public float cooldown = 10;
    public float cooldown2 = 7;
    private float cooldownTimer = 0;
    private float cooldownTimer2 = 0;
    public float speed;
    public float stopDistance;
    public float retreatDistance;
    public float detectDistance;
    private Vector3 directionToPlayer;
    private Character character;
    
    // Start is called before the first frame update
    void Start()
    {
        /* InvokeRepeating("CircleShoot", 0f, 7f);
         InvokeRepeating("ShootHoming", 0f, 10f);*/
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
        Mspeed = speed;
        BaseSpeed = speed;
    }

    public void Stage1()
    {

        //random between shooting in spiral and homing missile or both
        //when shooting spiral boss stop moving 
        // when player try to flee shoot homing 
        // after shoot spiral 3 time shoot both homing and spiral at the same time
        // have 5 sec between each shoot

        // transform.LookAt(player);
        /*
                if (Vector3.Distance(this.transform.position, player.position) >= minDist)
                {

                    transform.position += transform.forward * MoveSpeed * Time.deltaTime;



                    if (Vector3.Distance(transform.position, player.position) <= maxDist)
                    {

                       // transform.position = transform.position;
                        //Here Call any function U want Like Shoot at here or something
                        if (cooldownTimer <= 0)
                        {
                            CircleShoot();

                            cooldownTimer = cooldown;
                        }
                        else
                        {
                            cooldownTimer -= Time.deltaTime;
                        }
                        if (cooldownTimer2 <= 0)
                        {
                            ShootHoming();
                            cooldownTimer2 = cooldown2;
                        }
                        else
                        {
                            cooldownTimer2 -= Time.deltaTime;
                        }
                    }

                }*/
        if (character.CharacterAnimator.GetBool("IsDead") != true)
        {
            if (Vector2.Distance(transform.position, player.position) > detectDistance)
                return;
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, Mspeed * Time.deltaTime);

            }
            else if (Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;

            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -Mspeed * Time.deltaTime);
            }

            if (cooldownTimer <= 0)
            {
                CircleShoot();

                cooldownTimer = cooldown;
            }
            else
            {
                cooldownTimer -= Time.deltaTime;
            }
            if (cooldownTimer2 <= 0)
            {
                ShootHoming();
                cooldownTimer2 = cooldown2;
            }
            else
            {
                cooldownTimer2 -= Time.deltaTime;
            }
            directionToPlayer = (player.transform.position - transform.position).normalized;
            if (directionToPlayer.x < 0)
            {
                bossSprite.flipX = false;
            }
            else
            {
                bossSprite.flipX = true;
            }
        }
    }
    private void SpiralShoot()
    {

        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        GameObject bul = Instantiate(firebullet);
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        Debug.Log(angle);
        radian = Mathf.Atan2(bulDir.y, bulDir.x);
        shootAngle = radian * (180 / Mathf.PI);
        bul.GetComponent<Bullet>().SetBulletRotation(shootAngle);
        angle += 10f;
    }
    public void CircleShoot()
    {
         float angleStep = (endAngle - startAngle) / bulletsAmount;
         angle = startAngle;

        for(int i = 0; i < bulletsAmount; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;
            GameObject bul = Instantiate(firebullet);
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            radian = Mathf.Atan2(bulDir.y, bulDir.x);
            shootAngle = radian * (180 / Mathf.PI);
            bul.GetComponent<Bullet>().SetBulletRotation(shootAngle);


            angle += angleStep;
        }
    }
   public void ShootHoming()
    {
        angle = 0f;

        for (int i = 0; i < 4; i++)
        {
            GameObject bul = Instantiate(homingBullet);
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetBulletRotation(angle);

            angle += 90f;
        }
    }
    IEnumerator getSlow()
    {
        SlowDown();
        yield return new WaitForSeconds(1.0f);
        NormalSpeed();
        IsSlow = false;
    }
    public void bossSlow()
    {
        if (IsSlow == true)
        {
            StartCoroutine(getSlow());
            
        }
    }
}
