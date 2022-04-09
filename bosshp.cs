using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bosshp : MonoBehaviour
{
    [SerializeField] Image img;



    //[SerializeField] private GameObject bossHP;
    //[SerializeField] private GameObject boss;
    [SerializeField] private Health health;

    private void Start()
    {
    }


    private void Update()
    {
        img.fillAmount = health.GetComponent<Health>().CurrentHealth/ health.GetComponent<Health>().maxHealth;
        Debug.Log(health.GetComponent<Health>().CurrentHealth);
    }
}
