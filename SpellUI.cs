using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellUI : MonoBehaviour
{
    [SerializeField] private BulletBag bb;

    [SerializeField] public Bullet redBullet, homingBullet, yellowBullet;

    //public GameObject[] Spells;

    public TextMeshProUGUI[] spellCount;

    private void Start()
    {
        bb = GameObject.Find("WeaponHolder").GetComponent<BulletBag>();
    }

    private void Update()
    {
        if (bb.bulletsInfo[redBullet.id].amount > 0)
        {
            spellCount[0].text = bb.bulletsInfo[redBullet.id].amount.ToString();
        }
        else
        {
            spellCount[0].text = "0";
        }
        if (bb.bulletsInfo[homingBullet.id].amount > 0)
        {
            spellCount[1].text = bb.bulletsInfo[homingBullet.id].amount.ToString();

        }
        else
        {
            spellCount[1].text = "0";
        }
        if (bb.bulletsInfo[yellowBullet.id].amount > 0)
        {
            spellCount[2].text = bb.bulletsInfo[yellowBullet.id].amount.ToString();

        }
        else
        {
            spellCount[2].text = "0";
        }

        //spellCount[0].text = bb.bulletsInfo[homingBullet.id].amount.ToString();
    }
}
