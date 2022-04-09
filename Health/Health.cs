using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public float initialHealth = 10f;
    [SerializeField] public float maxHealth = 10f;

    [Header("Settings")]
    [SerializeField] private bool destroyObject;

    [Header("player Sprite")]
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Character character;
    private CharacterControl controller;
    private Collider2D collider2d;
    
    public float CurrentHealth { get; set; }

    public float CurrentShield { get; set; }
    private void Awake()
    {
        CurrentHealth = initialHealth;
        character = GetComponent<Character>();
        collider2d = GetComponent<Collider2D>();
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        controller = GetComponent<CharacterControl>();
        CurrentHealth = initialHealth;
        UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if(CurrentHealth <= 0)
        {
            return;
        }

        /*if(!shieldBroken && character != null)
         {
             CurrentShield -= damage;
             UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth);
             if (CurrentShield <= 0)
             {
                 shieldBroken = true;
             }
             return;      
         }*/
        StartCoroutine(ChangeColor());
        CurrentHealth -= damage;
        //put screen shake here for tata
        if (character.getCharType() == Character.CharacterTypes.Player)
        {
            UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth);
        }

        if(CurrentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(int h)
    {
        CurrentHealth += h;
        if(CurrentHealth > maxHealth)
        {
            CurrentHealth = maxHealth;
        }
        if (character.getCharType() == Character.CharacterTypes.Player)
        {
            UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth);
        }
    }
    private void Die()
    {
        if(character != null && character.getCharType() == Character.CharacterTypes.Player)
        {
            collider2d.enabled = false;
            spriteRenderer.enabled = false;
            character.enabled = false;
            controller.enabled = false;
            playerSprite.enabled = false;
            weaponHolder.SetActive(false);
            Debug.Log("Die");
        }
        if(character != null && character.getCharType() == Character.CharacterTypes.AI)
        {
            if (character.CharacterAnimator != null)
            {
                StartCoroutine(deadAnim());
            }
            //Destroy(this.gameObject);
        }
        if (destroyObject)
        {
            DestroyObject();
        }
    }
     public void Revive()
     {
        if (character != null)
        {
            if (character.getCharType() == Character.CharacterTypes.Player)
            {
                collider2d.enabled = true;
                spriteRenderer.enabled = true;
                character.enabled = true;
                controller.enabled = true;
                playerSprite.enabled = true;
                weaponHolder.SetActive(true);
            }
            
        }

        gameObject.SetActive(true);
        if (character.getCharType() == Character.CharacterTypes.Player)
        {
            CurrentHealth = initialHealth;
            UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth);
        }
    }
    private void DestroyObject()
    {
        if (character != null)
        {
            collider2d.enabled = false;
            spriteRenderer.enabled = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }
    }
    IEnumerator ChangeColor()
    {
        spriteRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material.color = Color.white;
        CameraShake.Instance.ShakeCamera(4f, .2f);
    }
    IEnumerator deadAnim()
    {
        character.CharacterAnimator.SetBool("IsDead", true);
        character.bossDead = character.CharacterAnimator.GetBool("IsDead");
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
