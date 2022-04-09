using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    private Collider2D Barrier;
    private BulletBag bulletBag;
    [SerializeField] private Animator absorb;
    [SerializeField] private AudioSource AbsorbSound;
    // Start is called before the first frame update
    void Start()
    {
        Barrier = GetComponent<CircleCollider2D>();
        bulletBag = gameObject.GetComponentInParent<BulletBag>();
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }
    public void ToggleOnCollider()
    {
        Barrier.enabled = true;
        absorb.SetBool("IsAbsorb", true);
    }
    public void ToggleOffCollider()
    {
        Barrier.enabled = false;
        absorb.SetBool("IsAbsorb", false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet b = collision.gameObject.GetComponent<Bullet>();
        if (b)
        {
            bulletBag.KeepBullet(b);
            AbsorbSound.Play();

            Destroy(collision.gameObject);
        }
    }
}
