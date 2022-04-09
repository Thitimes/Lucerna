using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     public string id = "bullet_blah";
    [SerializeField] private int maxAmmo = 10;
    [SerializeField] public int Damage;
    [SerializeField] private float speed = 100f;
    private BulletPool pool;
    public float acceleration = 0.1f;
    private Rigidbody2D rb;
    public bool isMoving;
    public bool FacingRight;
    public float Speed { get; set; }

    private Vector3 movement;
    private SpriteRenderer spriteRenderer;

   
  
    // Start is called before the first frame update
    void Start()
    {
        Initializiation();
    }

    void FixedUpdate()
    { 
        MoveBullet(); 
    }

    protected virtual void Initializiation()
    {
        Speed = speed;
        FacingRight = true;
        isMoving = true;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void MoveBullet()
    {
        if (isMoving == true)
        {
            movement = transform.right * Speed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);
            Speed += acceleration;
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Wall"))
        {
            destroyBullet();


        }
        else if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("EnemyBullet") )
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
            destroyBullet();
        }
        else if(collision.gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("PlayerBullet"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
            destroyBullet();

        }
    }
    public virtual void destroyBullet()
    {
        Destroy(gameObject);
    }

    public void FlipBullet()
    {
        Debug.Log(" sprite2 " + spriteRenderer);
        if (spriteRenderer != null)
        {
            
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    public void ResetBullet()
    {
        spriteRenderer.flipX = false;
    }

    public void SetBulletRotation(float rotation)
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
    }
}
