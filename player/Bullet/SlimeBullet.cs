using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBullet : Bullet
{
    private MonsterBehaviour monster;
    private CharacterMovement player;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            destroyBullet();


        }
        else if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("EnemyBullet"))
        {
            player = collision.GetComponent<CharacterMovement>();
            player.IsSlow = true;
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
            destroyBullet();
        }
        else if (collision.gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("PlayerBullet"))
        {
            monster = collision.GetComponent<MonsterBehaviour>();
            monster.IsSlow = true;
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
            destroyBullet();

        }
    }
}
