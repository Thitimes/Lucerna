using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstanse;

    [SerializeField]
    private GameObject poolBullet;
    private bool notEnoughBulletPool = true;
    
    private List<GameObject> bullets;

    private void Awake()
    {
        bulletPoolInstanse = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if(bullets.Count > 0)
        {
            for(int i = 0; i< bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughBulletPool)
        {
            GameObject bul = Instantiate(poolBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }
    public void removeBullet(GameObject bullet)
    {
         for (int i = 0; i < bullets.Count; i++) {
             if (bullet.name == bullets[i].name)
             {
                 bullets.RemoveAt(i);
             }         
           }
        bullets.Remove(bullet);
    }
    public GameObject addBullet()
    {
        GameObject bul = Instantiate(poolBullet);
        bul.SetActive(false);
        bullets.Add(bul);
        return bul;
    }
    public int getCount()
    {
        return bullets.Count;
    }
}
