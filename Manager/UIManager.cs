using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : Singleton<UIManager>
{

    [Header("Settings")]
    [SerializeField] private Image healthBar;
  //  [SerializeField] private Image shieldBar;
    [SerializeField] private TextMeshProUGUI currentHealthTmp;
   // [SerializeField] private TextMeshProUGUI currentShieldTmp;

    private float playerCurrentHealth;
    private float playerMaxHealth;
 /*   private float playerCurrentShield;
    private float playerMaxShield;*/

    private void Update()
    {
        InternalUpdate();
    }
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        playerCurrentHealth = currentHealth;
        playerMaxHealth = maxHealth;
       // playerCurrentShield = currentShield;
       // playerMaxShield = maxShield;
    }

    private void InternalUpdate()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerCurrentHealth / playerMaxHealth, 10f * Time.deltaTime);
        currentHealthTmp.text = playerCurrentHealth.ToString() + "/" + playerMaxHealth.ToString();

        /*shieldBar.fillAmount = Mathf.Lerp(shieldBar.fillAmount, playerCurrentShield / playerMaxShield, 10f * Time.deltaTime);
        currentShieldTmp.text = playerCurrentShield.ToString() + "/" + playerMaxShield.ToString();*/
    }
    
}
