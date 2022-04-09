using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public bool keyHeld = false;
    [SerializeField] private GameObject brokenVase;
    [SerializeField] private GameObject keyUI;
    private SpriteRenderer vase;

    void Start()
    {
        PlayerPrefs.SetInt("KeyHeld", 0);
        brokenVase.SetActive(false);
        vase = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("KeyHeld", 0) == 0)
        {
            keyHeld = false;
        }

        if (keyHeld)
        {
            brokenVase.SetActive(true);
            keyUI.SetActive(true);
            vase.enabled = false;
        }
        else
        {
            keyUI.SetActive(false);
            vase.enabled = true;
            brokenVase.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerPrefs.GetInt("KeyHeld", 0) == 0)
        {
            keyHeld = true;
            PlayerPrefs.SetInt("KeyHeld", 1);
        }

        /*
        if ((collision.CompareTag("EnemyBullet") || collision.CompareTag("PlayerBullet")){

        }
        */
    }
}
