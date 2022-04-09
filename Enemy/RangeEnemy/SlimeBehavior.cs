using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehavior : MonsterBehaviour
{
    public float speed;
    public float stopDistance;
    public float retreatDistance;
    public float detectDistance;
    private float angleToPlayer;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private Vector3 directionToPlayer;
    public Bullet bulletToShoot;
    private BulletPool pool;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Animator SlimeAnim;
    [SerializeField] private SpriteRenderer SlimeSprite;
    private Transform player;
    private Bullet newBullet;
    private Character character;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bulletToShoot.isMoving = true;
        timeBtwShots = startTimeBtwShots;
        character = GetComponent<Character>();
        Mspeed = speed;
        BaseSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (character.CharacterAnimator.GetBool("IsDead") != true)
        {
            checkPlayerDistance();
        }
        if (IsSlow == true)
        {
            StartCoroutine(getSlow());
            
        }

    }
    void checkPlayerDistance()
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
            SlimeAnim.SetBool("IsAttack", false);
        }
        if (timeBtwShots <= 0)
        {
            //  Instantiate(bulletProjectile, transform.position, Quaternion.identity);
            SlimeAnim.SetBool("IsAttack", true);
            timeBtwShots = startTimeBtwShots;
            newBullet = Instantiate(bulletToShoot, bulletSpawnPoint.position, Quaternion.identity).GetComponent<Bullet>();
            directionToPlayer = (player.transform.position - bulletSpawnPoint.position).normalized;
            angleToPlayer = Vector3.Angle(directionToPlayer, bulletSpawnPoint.right);
            if (directionToPlayer.x < 0)
            {
                SlimeSprite.flipX = true;
            }
            else
            {
                SlimeSprite.flipX = false;
            }
            if (FindPlayerPosition() > 0)
            {
                newBullet.SetBulletRotation(-angleToPlayer);
            }
            else
            {
                newBullet.SetBulletRotation(angleToPlayer);
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    float FindPlayerPosition()
    {
        float temp;
        temp = bulletSpawnPoint.position.y - player.position.y;
        return temp;
    }
    IEnumerator getSlow()
    {
        SlowDown();
        yield return new WaitForSeconds(1.0f);
        NormalSpeed();
        IsSlow = false;
    }
}
