using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomimgBullet : Bullet
{
    private Transform target;
    [SerializeField] float rotateSpeed = 200f;
    [SerializeField] float HomingSpeed = 1f;
    
    private Rigidbody2D rbh;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.CompareTag("EnemyBullet"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            target = FindClosestEnemy().transform;
        }
        rbh = GetComponent<Rigidbody2D>();
    }
  
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);   
    }
    protected override void MoveBullet()
    {
        if (isMoving == true && target != null)
        {
           
            Vector2 direction = (Vector2)target.position - rbh.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            
            rbh.angularVelocity = -rotateAmount * rotateSpeed;

            rbh.velocity = transform.right * HomingSpeed;
            
        }
      
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

}
